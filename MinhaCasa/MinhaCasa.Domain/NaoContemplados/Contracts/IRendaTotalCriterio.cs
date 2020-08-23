using MinhaCasa.Domain.Enums;
using MinhaCasa.Domain.NaoContemplados.Commands;
using MinhaCasa.Domain.NaoContemplados.Interfaces;

namespace MinhaCasa.Domain.NaoContemplados.Contracts
{
    public interface IRendaTotalCriterio : IService
    {
        IResultadoCommand TratarRendaFamiliarAte900Reais(ResultadoCommand resultado);
        IResultadoCommand TratarRendaFamiliarEntre901A1500Reais(ResultadoCommand resultado);
        IResultadoCommand TratarRendaFamiliarEntre1501A2000Reais(ResultadoCommand resultado);
    }
}