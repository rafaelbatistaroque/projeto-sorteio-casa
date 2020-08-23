using MinhaCasa.Domain.Enums;
using MinhaCasa.Domain.NaoContemplados.Commands;
using MinhaCasa.Domain.NaoContemplados.Contracts;
using MinhaCasa.Domain.NaoContemplados.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinhaCasa.Domain.NaoContemplados.Services.TipoCategorias
{
    public class Categoria : ICategoria
    {
        const int DEZOITO_ANOS = 18;
        const int TRES_DEPENDENTES = 3;

        const int _30_ANOS = 30;
        const int _45_ANOS = 45;

        const decimal NOVECENTOS_REAIS = 900;
        const decimal MIL_E_QUINHENTOS_REAIS = 1500;

        public ECategoriaDependente ObterCategoriaDependentes(IEnumerable<Pessoa> dependentes)
        {
            return dependentes.Count(x => EhMenorIdade(x.DataNascimento)) < TRES_DEPENDENTES ? ECategoriaDependente.UmOuDois : ECategoriaDependente.TresOuMais;
        }

        public void ObterCategoriaDependente(CriarFamiliaCommand criarFamilia)
        {
            if (EhMenorIdade(criarFamilia.DataNascimento))
                criarFamilia.CategoriaDependente = ECategoriaDependente.UmOuDois;
        }

        public void ObterCategoriaIdadePretendente(CriarFamiliaCommand criarFamilia)
        {
            criarFamilia.CategoriaIdadePretendente = ECategoriaIdadePretendente.IdadeIgualOuMaior45Anos;
            var timeSpan = DateTime.Today - criarFamilia.DataNascimento;
            var idade = (new DateTime() + timeSpan).AddYears(-1).AddDays(-1);

            if (idade.Year < _30_ANOS)
                criarFamilia.CategoriaIdadePretendente = ECategoriaIdadePretendente.IdadeAbaixo30Anos;

            if (idade.Year >= _30_ANOS && idade.Year < _45_ANOS)
                criarFamilia.CategoriaIdadePretendente = ECategoriaIdadePretendente.IdadeEntre30E44Anos;
        }

        public ECategoriaRenda ObterCategoriaRenda(CriarFamiliaCommand criarFamilia)
        {
            if (criarFamilia.Renda <= NOVECENTOS_REAIS)
                return ECategoriaRenda.RendaAte900;

            if (criarFamilia.Renda > NOVECENTOS_REAIS && criarFamilia.Renda <= MIL_E_QUINHENTOS_REAIS)
                return ECategoriaRenda.RendaEntre901A1500;
            
            return  ECategoriaRenda.RendaEntre1501A2000;
        }

        private bool EhMenorIdade(DateTime dataNascimento)
        {
            return DateTime.Now < dataNascimento.AddYears(DEZOITO_ANOS);
        }
    }
}
