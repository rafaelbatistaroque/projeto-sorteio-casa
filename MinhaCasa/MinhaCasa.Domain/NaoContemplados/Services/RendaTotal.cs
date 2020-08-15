using MinhaCasa.Domain.NaoContemplados.Commands;
using MinhaCasa.Domain.NaoContemplados.Contracts;
using MinhaCasa.Shared.Enums;

namespace MinhaCasa.Domain.NaoContemplados.Services
{
    public class RendaTotal : IRendaTotal
    {
        const decimal NOVECENTOS_REAIS = 900;
        const decimal NOVECENTOS_E_UM_REAIS = 901;
        const decimal MIL_E_QUINHENTOS_REAIS = 1500;
        const decimal MIL_QUINHENTOS_E_UM_REAIS = 1501;
        const decimal DOIS_MIL_REAIS = 2000;

        public void TratarRendaFamiliarAte900Reais(ResultadoCriterioCommand resultado, decimal rendaTotal)
        {
            if (rendaTotal <= NOVECENTOS_REAIS)
            {
                resultado.Pontuacao += (int)ETipoPontuacao.CincoPontos;
                resultado.QuantidadeCriteriosAtendidos++;
            }
        }

        public void TratarRendaFamiliarEntre901A1500Reais(ResultadoCriterioCommand resultado, decimal rendaTotal)
        {
            if (rendaTotal >= NOVECENTOS_E_UM_REAIS && rendaTotal <= MIL_E_QUINHENTOS_REAIS)
            {
                resultado.Pontuacao += (int)ETipoPontuacao.TresPontos;
                resultado.QuantidadeCriteriosAtendidos++;
            }
        }

        public void TratarRendaFamiliarEntre1501A2000Reais(ResultadoCriterioCommand resultado, decimal rendaTotal)
        {
            if (rendaTotal >= MIL_QUINHENTOS_E_UM_REAIS && rendaTotal <= DOIS_MIL_REAIS)
            {
                resultado.Pontuacao += (int)ETipoPontuacao.UmPonto;
                resultado.QuantidadeCriteriosAtendidos++;
            }
        }
    }
}
