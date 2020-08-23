using MinhaCasa.Domain.Enums;
using MinhaCasa.Domain.NaoContemplados.Commands;
using MinhaCasa.Domain.NaoContemplados.Contracts;
using MinhaCasa.Domain.NaoContemplados.Interfaces;
using System;

namespace MinhaCasa.Domain.NaoContemplados.Services.CriteriosSelecao
{
    public class PretendenteCriterio : IPretendenteCriterio
    {
        public IResultadoCommand TratarIdadeAbaixo30Anos(ResultadoCommand resultado)
        {
            resultado.Pontuacao = (int)ETipoPontuacao.UmPonto;
            resultado.QuantidadeCriteriosAtendidos++;

            return resultado;
        }

        public IResultadoCommand TratarIdadeEntre30AE44Anos(ResultadoCommand resultado)
        {
            resultado.Pontuacao = (int)ETipoPontuacao.DoisPontos;
            resultado.QuantidadeCriteriosAtendidos++;

            return resultado;
        }

        public IResultadoCommand TratarIdadeIgualOuAcima45Anos(ResultadoCommand resultado)
        {
            resultado.Pontuacao = (int)ETipoPontuacao.TresPontos;
            resultado.QuantidadeCriteriosAtendidos++;

            return resultado;
        }
    }
}