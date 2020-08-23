using MinhaCasa.Domain.Enums;
using MinhaCasa.Domain.NaoContemplados.Commands;
using MinhaCasa.Domain.NaoContemplados.Contracts;
using MinhaCasa.Domain.NaoContemplados.Interfaces;

namespace MinhaCasa.Domain.NaoContemplados.Services.CriteriosSelecao
{
    public class RendaTotalCriterio : IRendaTotalCriterio
    {
        public IResultadoCommand TratarRendaFamiliarAte900Reais(ResultadoCommand resultado)
        {
            resultado.Pontuacao += (int)ETipoPontuacao.CincoPontos;
            resultado.QuantidadeCriteriosAtendidos++;

            return resultado;
        }

        public IResultadoCommand TratarRendaFamiliarEntre901A1500Reais(ResultadoCommand resultado)
        {
            resultado.Pontuacao += (int)ETipoPontuacao.TresPontos;
            resultado.QuantidadeCriteriosAtendidos++;

            return resultado;
        }

        public IResultadoCommand TratarRendaFamiliarEntre1501A2000Reais(ResultadoCommand resultado)
        {
            resultado.Pontuacao += (int)ETipoPontuacao.UmPonto;
            resultado.QuantidadeCriteriosAtendidos++;

            return resultado;
        }
    }
}