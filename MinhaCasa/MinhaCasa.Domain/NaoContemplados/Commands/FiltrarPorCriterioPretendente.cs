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
    public class FiltrarPorCriterioPretendente : Notifiable, ICommandBase
    {
        public Guid Id { get; set; }
        public ECategoriaIdadePretendente CategoriaIdadePretendente { get; set; }
        public IEnumerable<Pessoa> Pessoas { get; set; }

        public FiltrarPorCriterioPretendente() { }

        public FiltrarPorCriterioPretendente(Guid id, IEnumerable<Pessoa> pessoas, ECategoriaIdadePretendente categoriaIdadePretendente)
        {
            Id = id;
            Pessoas = pessoas;
            CategoriaIdadePretendente = categoriaIdadePretendente;
        }

        public void Validar()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsTrue(ExistePretendente(), nameof(Pessoas), "Não existe pretendente nesta familiares."));
        }

        private bool ExistePretendente()
        {
            return Pessoas.Any(x => x.TipoVinculoFamiliar.Equals(ETipoVinculoFamiliar.Pretendente));
        }
    }
}
