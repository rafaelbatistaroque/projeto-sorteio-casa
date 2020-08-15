using MinhaCasa.Domain.NaoContemplados.Commands;
using MinhaCasa.Domain.NaoContemplados.Contracts;
using System;

namespace MinhaCasa.Domain.NaoContemplados.Handlers
{
    public class MinhaCasaHandler :
        IHandler<FiltrarPorCriterioRendaTotalCommand>
    {
        private readonly IRendaTotal _rendaTotalCriterio;

        public MinhaCasaHandler(IRendaTotal rendaCriterio)
        {
            _rendaTotalCriterio = rendaCriterio;
        }

        public ICommandResult CalcularCriterio(FiltrarPorCriterioRendaTotalCommand command)
        {
            command.Validar();
            if (command.Invalid)
                return new ResultadoCriterioCommand(0, 0, false, "Familia não atendeu aos criterios de participação do serteio.");

            try
            {
                var resultado = new ResultadoCriterioCommand();

                _rendaTotalCriterio.TratarRendaFamiliarAte900Reais(resultado, command.RendaTotal);
                _rendaTotalCriterio.TratarRendaFamiliarEntre1501A2000Reais(resultado, command.RendaTotal);
                _rendaTotalCriterio.TratarRendaFamiliarEntre901A1500Reais(resultado, command.RendaTotal);

                resultado.Sucesso = true;

                return resultado;
            }
            catch (Exception)
            {
                return new ResultadoCriterioCommand(0, 0, false, "Não foi possivel realizar as validações de Renda Total");
            }
        }
    }
}
