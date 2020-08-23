using Flunt.Notifications;
using Flunt.Validations;
using MinhaCasa.Domain.Enums;
using MinhaCasa.Domain.NaoContemplados.Contracts;
using MinhaCasa.Domain.NaoContemplados.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinhaCasa.Domain.NaoContemplados.Commands
{
    public class FiltrarPorCriterioDependenteCommand : Notifiable, IBaseCommand
    {
        public Guid Id { get; set; }
        public ECategoriaDependente CategoriaDependente { get; set; }
        public IEnumerable<Pessoa> Pessoas { get; set; }

        public FiltrarPorCriterioDependenteCommand() { }

        public FiltrarPorCriterioDependenteCommand(Guid id, IEnumerable<Pessoa> pessoas, ECategoriaDependente categoriaDependente)
        {
            Id = id;
            Pessoas = pessoas;
            CategoriaDependente = categoriaDependente;
        }

        public void Validar()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsTrue(ExisteDependente(), nameof(Pessoas), "Não existem dependentes nesta família."));
        }

        private bool ExisteDependente()
        {
            return Pessoas
                .Any(x => x.TipoVinculoFamiliar.Equals(ETipoVinculoFamiliar.Dependente));
        }
    }
}
