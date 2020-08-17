using MinhaCasa.Domain.Enums;
using MinhaCasa.Domain.NaoContemplados.Commands;
using MinhaCasa.Domain.NaoContemplados.Contracts;
using MinhaCasa.Domain.NaoContemplados.Interfaces;

namespace MinhaCasa.Domain.NaoContemplados.Services.CriteriosSelecao
{
    public class RendaTotalCriterio : IRendaTotalCriterio
    {
        const decimal NOVECENTOS_REAIS = 900;
        const decimal MIL_E_QUINHENTOS_REAIS = 1500;

        public ECategoriaRenda ObterCategoriaRenda(decimal rendaTotal)
        {
            if (rendaTotal <= NOVECENTOS_REAIS)
                return ECategoriaRenda.RendaAte900;
            if (rendaTotal > NOVECENTOS_REAIS && rendaTotal <= MIL_E_QUINHENTOS_REAIS)
                return ECategoriaRenda.RendaEntre901A1500;

            return ECategoriaRenda.RendaEntre1501A2000;
        }

        public ICommandResult TratarRendaFamiliarAte900Reais(ResultadoCriterioCommand resultado)
        {
            resultado.Pontuacao += (int)ETipoPontuacao.CincoPontos;
            resultado.QuantidadeCriteriosAtendidos++;

            return resultado;
        }

        public ICommandResult TratarRendaFamiliarEntre901A1500Reais(ResultadoCriterioCommand resultado)
        {
            resultado.Pontuacao += (int)ETipoPontuacao.TresPontos;
            resultado.QuantidadeCriteriosAtendidos++;

            return resultado;
        }

        public ICommandResult TratarRendaFamiliarEntre1501A2000Reais(ResultadoCriterioCommand resultado)
        {
            resultado.Pontuacao += (int)ETipoPontuacao.UmPonto;
            resultado.QuantidadeCriteriosAtendidos++;

            return resultado;
        }
    }
}