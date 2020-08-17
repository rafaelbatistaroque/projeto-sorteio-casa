using MinhaCasa.Domain.Enums;
using MinhaCasa.Domain.NaoContemplados.Entities;
using System;
using System.Linq.Expressions;

namespace MinhaCasa.Domain.NaoContemplados.Queries
{
    public static class NaoContempladosQuery
    {
        public static Expression<Func<Familia, bool>> ObterFamiliasAptasParaSelecao()
        {
            return familia => familia.Status == EStatusFamilia.CadastroValido && familia.ProcessosSelecao.Count == 1;
        }
    }
}
