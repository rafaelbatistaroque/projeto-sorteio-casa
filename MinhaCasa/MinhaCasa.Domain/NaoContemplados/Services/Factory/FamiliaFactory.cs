using MinhaCasa.Domain.Enums;
using MinhaCasa.Domain.NaoContemplados.Commands;
using MinhaCasa.Domain.NaoContemplados.Entities;
using System;
using System.Collections.Generic;

namespace MinhaCasa.Domain.NaoContemplados.Services.Factory
{
    public static class FamiliaFactory
    {
        public static Familia Criar(CriarFamiliaCommand criarFamilia)
        {
            var tipoVinculoFamiliar = new Dictionary<ETipoVinculoFamiliar, Func<CriarFamiliaCommand, Familia>>
            {
                {ETipoVinculoFamiliar.Pretendente, CriarComCategoriaDependente },
                {ETipoVinculoFamiliar.Dependente, CriarComCategoriaPretendente },
                {ETipoVinculoFamiliar.Conjuge, CriarComTipoVinculoConjuge }
            };

            return tipoVinculoFamiliar[criarFamilia.TipoVinculoFamiliar].Invoke(criarFamilia);
        }

        private static Familia CriarComCategoriaDependente(CriarFamiliaCommand criarFamilia)
        {
            return new Familia(EStatusFamilia.CadastroValido, criarFamilia.CategoriaRenda, criarFamilia.CategoriaDependente);
        }

        private static Familia CriarComCategoriaPretendente(CriarFamiliaCommand criarFamilia)
        {
            return new Familia(EStatusFamilia.CadastroValido, criarFamilia.CategoriaRenda, criarFamilia.CategoriaIdadePretendente);
        }

        private static Familia CriarComTipoVinculoConjuge(CriarFamiliaCommand criarFamilia)
        {
            return new Familia(EStatusFamilia.CadastroValido, criarFamilia.CategoriaRenda);
        }
    }
}
