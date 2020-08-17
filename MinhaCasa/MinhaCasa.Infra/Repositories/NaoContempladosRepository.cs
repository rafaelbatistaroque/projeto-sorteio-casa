using MinhaCasa.Domain.NaoContemplados.Entities;
using MinhaCasa.Domain.NaoContemplados.Repositories;
using System;
using System.Linq;

namespace MinhaCasa.Infra.Repositories
{
    public class NaoContempladosRepository : INaoContempladosRepository
    {
        public IQueryable<Familia> Obter(int quantidadeContemplados)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Familia> Obter()
        {
            throw new NotImplementedException();
        }
    }
}
