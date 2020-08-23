using MinhaCasa.Domain.Enums;
using MinhaCasa.Domain.NaoContemplados.Commands;
using MinhaCasa.Domain.NaoContemplados.Contracts;
using MinhaCasa.Domain.NaoContemplados.Entities;
using MinhaCasa.Domain.NaoContemplados.Interfaces;
using MinhaCasa.Domain.NaoContemplados.Repositories;
using MinhaCasa.Domain.NaoContemplados.Services.Factory;
using MinhaCasa.Domain.NaoContemplados.ValuesObjects;
using System;
using System.Collections.Generic;

namespace MinhaCasa.Domain.NaoContemplados.Handlers
{
    public class CRUDNaoContempladosHandler : IHandler<CriarFamiliaCommand>
    {
        private readonly ICategoria _categoria;
        private readonly INaoContempladosRepository _repositorio;

        public CRUDNaoContempladosHandler(ICategoria categoria, INaoContempladosRepository repositorio)
        {
            _categoria = categoria;
            _repositorio = repositorio;
        }

        public IResultadoCommand Tratar(CriarFamiliaCommand command)
        {
            command.Validar();
            if (command.Invalid)
                return new ResultadoCommand(0, 0, false, command.Notifications);

            var tratamentoVinculosFamiliares = new Dictionary<ETipoVinculoFamiliar, Action<CriarFamiliaCommand>>()
            {
                { ETipoVinculoFamiliar.Pretendente, _categoria.ObterCategoriaIdadePretendente },
                { ETipoVinculoFamiliar.Dependente, _categoria.ObterCategoriaDependente }
            };
            try
            {
                command.CategoriaRenda = _categoria.ObterCategoriaRenda(command);

                if (tratamentoVinculosFamiliares.ContainsKey(command.TipoVinculoFamiliar))
                    tratamentoVinculosFamiliares[command.TipoVinculoFamiliar].Invoke(command);

                var novaFamilia = FamiliaFactory.Criar(command);
                var novoMembroFamilia = new Pessoa(command.Nome, command.TipoVinculoFamiliar, command.DataNascimento, command.Renda, novaFamilia.Id);

                novaFamilia.AdicionarMembroFamiliar(novoMembroFamilia);

                _repositorio.CriarFamilia(novaFamilia);

                return new ResultadoCommand(0, 0, true);
            }
            catch (Exception)
            {
                return new ResultadoCommand(0, 0, false, "Ocorreu um erro inesperado ao criar uma família.");
            }
           
        }
    }
}
