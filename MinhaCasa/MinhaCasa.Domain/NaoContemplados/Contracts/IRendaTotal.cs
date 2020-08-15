using MinhaCasa.Domain.NaoContemplados.Commands;
using System.Threading.Tasks;

namespace MinhaCasa.Domain.NaoContemplados.Contracts
{
    public interface IRendaTotal : ICriterio
    {
        void TratarRendaFamiliarAte900Reais(ResultadoCriterioCommand resultado, decimal rendaTotal);
        void TratarRendaFamiliarEntre901A1500Reais(ResultadoCriterioCommand resultado, decimal rendaTotal);
        void TratarRendaFamiliarEntre1501A2000Reais(ResultadoCriterioCommand resultado, decimal rendaTotal);
    }
}
