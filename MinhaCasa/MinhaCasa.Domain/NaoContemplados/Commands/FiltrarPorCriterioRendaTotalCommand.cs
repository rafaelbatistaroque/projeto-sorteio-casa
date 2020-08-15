using Flunt.Notifications;
using Flunt.Validations;
using MinhaCasa.Domain.NaoContemplados.Contracts;
using MinhaCasa.Domain.NaoContemplados.ValuesObjects;
using System;

namespace MinhaCasa.Domain.NaoContemplados.Commands
{
    public class FiltrarPorCriterioRendaTotalCommand : Notifiable, ICommandBase
    {
        public Guid Id { get; set; }
        public decimal RendaTotal { get; set; }
        public int Pontuacao { get; set; }
        public int QuantidadeCriteriosAtendidos { get; set; }

        public FiltrarPorCriterioRendaTotalCommand(){}

        public FiltrarPorCriterioRendaTotalCommand(Guid id, decimal rendaTotal, int pontuacao, int quantidadeCriteriosAtendidos)
        {
            Id = id;
            RendaTotal = rendaTotal;
            Pontuacao = pontuacao;
            QuantidadeCriteriosAtendidos = quantidadeCriteriosAtendidos;
        }

        public void Validar()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsGreaterOrEqualsThan(RendaTotal, 0, nameof(RendaTotal), "O Total da renda não pode ser valor meno que zero."));
        }
    }
}
