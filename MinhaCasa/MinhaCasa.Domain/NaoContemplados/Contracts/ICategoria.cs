using MinhaCasa.Domain.Enums;
using MinhaCasa.Domain.NaoContemplados.Commands;
using MinhaCasa.Domain.NaoContemplados.Entities;
using MinhaCasa.Domain.NaoContemplados.Interfaces;
using System.Collections.Generic;

namespace MinhaCasa.Domain.NaoContemplados.Contracts
{
    public interface ICategoria : IService
    {
        ECategoriaDependente ObterCategoriaDependentes(IEnumerable<Pessoa> pessoas);
        void ObterCategoriaDependente(CriarFamiliaCommand criarFamilia);
        ECategoriaRenda ObterCategoriaRenda(CriarFamiliaCommand criarFamilia);
        void ObterCategoriaIdadePretendente(CriarFamiliaCommand criarFamilia);
    }
}
