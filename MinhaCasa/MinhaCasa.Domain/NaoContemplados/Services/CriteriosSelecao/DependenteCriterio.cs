using MinhaCasa.Domain.Enums;
using MinhaCasa.Domain.NaoContemplados.Commands;
using MinhaCasa.Domain.NaoContemplados.Contracts;
using MinhaCasa.Domain.NaoContemplados.Entities;
using MinhaCasa.Domain.NaoContemplados.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinhaCasa.Domain.NaoContemplados.Services.CriteriosSelecao
{
    public class DependenteCriterio : IDependenteCriterio
    {
        const int DEZOITO_ANOS = 18;
        const int TRES_DEPENDENTES = 3;

        public ECategoriaDependente ObterCategoriaDependente(IEnumerable<Pessoa> dependentes)
        {
            return dependentes.Count(x => EhMenorIdade(x.DataNascimento)) < TRES_DEPENDENTES ? ECategoriaDependente.UmOuDois : ECategoriaDependente.TresOuMais;
        }

        public ICommandResult TratarTresOuMaisDependentes(ResultadoCriterioCommand resultado)
        {
            resultado.Pontuacao = (int)ETipoPontuacao.TresPontos;
            resultado.QuantidadeCriteriosAtendidos++;

            return resultado;
        }

        public ICommandResult TratarUmOuDoisDependentes(ResultadoCriterioCommand resultado)
        {
            resultado.Pontuacao = (int)ETipoPontuacao.DoisPontos;
            resultado.QuantidadeCriteriosAtendidos++;

            return resultado;
        }

        private bool EhMenorIdade(DateTime dataNascimento)
        {
            return (DateTime.Now.Year - dataNascimento.Year) < DEZOITO_ANOS;
        }
    }
}
