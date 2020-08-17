using MinhaCasa.Domain.Enums;
using MinhaCasa.Domain.NaoContemplados.Commands;
using MinhaCasa.Domain.NaoContemplados.Contracts;
using MinhaCasa.Domain.NaoContemplados.Interfaces;
using System;

namespace MinhaCasa.Domain.NaoContemplados.Services.CriteriosSelecao
{
    public class PretendenteCriterio : IPretendenteCriterio
    {
        const int _30_ANOS = 30;
        const int _45_ANOS = 45;

        public ECategoriaIdadePretendente ObterCategoriaIdadePretendente(DateTime dataNascimento)
        {
            int idade = DateTime.Now.Year - dataNascimento.Year;
            if (idade < _30_ANOS)
                return ECategoriaIdadePretendente.IdadeAbaixo30Anos;
            if (idade >= _30_ANOS && idade < _45_ANOS)
                return ECategoriaIdadePretendente.IdadeEntre30E44Anos;

            return ECategoriaIdadePretendente.IdadeIgualOuMaior45Anos;
        }

        public ICommandResult TratarIdadeAbaixo30Anos(ResultadoCriterioCommand resultado)
        {
            resultado.Pontuacao = (int)ETipoPontuacao.UmPonto;
            resultado.QuantidadeCriteriosAtendidos++;

            return resultado;
        }

        public ICommandResult TratarIdadeEntre30AE44Anos(ResultadoCriterioCommand resultado)
        {
            resultado.Pontuacao = (int)ETipoPontuacao.DoisPontos;
            resultado.QuantidadeCriteriosAtendidos++;

            return resultado;
        }

        public ICommandResult TratarIdadeIgualOuAcima45Anos(ResultadoCriterioCommand resultado)
        {
            resultado.Pontuacao = (int)ETipoPontuacao.TresPontos;
            resultado.QuantidadeCriteriosAtendidos++;

            return resultado;
        }
    }
}