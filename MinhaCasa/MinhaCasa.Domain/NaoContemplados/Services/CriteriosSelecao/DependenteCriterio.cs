using MinhaCasa.Domain.Enums;
using MinhaCasa.Domain.NaoContemplados.Commands;
using MinhaCasa.Domain.NaoContemplados.Contracts;
using MinhaCasa.Domain.NaoContemplados.Interfaces;

namespace MinhaCasa.Domain.NaoContemplados.Services.CriteriosSelecao
{
    public class DependenteCriterio : IDependenteCriterio
    {
        public IResultadoCommand TratarTresOuMaisDependentes(ResultadoCommand resultado)
        {
            resultado.Pontuacao = (int)ETipoPontuacao.TresPontos;
            resultado.QuantidadeCriteriosAtendidos++;

            return resultado;
        }

        public IResultadoCommand TratarUmOuDoisDependentes(ResultadoCommand resultado)
        {
            resultado.Pontuacao = (int)ETipoPontuacao.DoisPontos;
            resultado.QuantidadeCriteriosAtendidos++;

            return resultado;
        }
    }
}
