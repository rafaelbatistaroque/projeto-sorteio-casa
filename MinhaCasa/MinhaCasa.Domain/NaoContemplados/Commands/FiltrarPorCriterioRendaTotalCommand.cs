using Flunt.Notifications;
using Flunt.Validations;
using MinhaCasa.Domain.Enums;
using MinhaCasa.Domain.NaoContemplados.Contracts;
using System;

namespace MinhaCasa.Domain.NaoContemplados.Commands
{
    public class FiltrarPorCriterioRendaTotalCommand : Notifiable, IBaseCommand
    {
        public Guid Id { get; set; }
        public decimal RendaTotal { get; set; }
        public ECategoriaRenda CategoriaRenda { get; set; }

        public FiltrarPorCriterioRendaTotalCommand() { }

        public FiltrarPorCriterioRendaTotalCommand(Guid id, decimal rendaTotal, ECategoriaRenda categoriaRenda)
        {
            Id = id;
            RendaTotal = rendaTotal;
            CategoriaRenda = categoriaRenda;
        }

        public void Validar()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsGreaterOrEqualsThan(RendaTotal, 0, nameof(RendaTotal), "O Total da renda não pode ser valor meno que zero.")
                .IsLowerOrEqualsThan(RendaTotal, 2000, nameof(RendaTotal), "O Total da renda não pode ser maior que R$2000,00 reais."));
        }
    }
}
