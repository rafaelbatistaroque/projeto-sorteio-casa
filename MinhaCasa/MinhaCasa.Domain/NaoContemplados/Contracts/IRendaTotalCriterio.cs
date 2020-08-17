using MinhaCasa.Domain.Enums;
using MinhaCasa.Domain.NaoContemplados.Commands;
using MinhaCasa.Domain.NaoContemplados.Interfaces;

namespace MinhaCasa.Domain.NaoContemplados.Contracts
{
    public interface IRendaTotalCriterio : ICriterio
    {
        ICommandResult TratarRendaFamiliarAte900Reais(ResultadoCriterioCommand resultado);
        ICommandResult TratarRendaFamiliarEntre901A1500Reais(ResultadoCriterioCommand resultado);
        ICommandResult TratarRendaFamiliarEntre1501A2000Reais(ResultadoCriterioCommand resultado);

        ECategoriaRenda ObterCategoriaRenda(decimal rendaTotal);
    }
}