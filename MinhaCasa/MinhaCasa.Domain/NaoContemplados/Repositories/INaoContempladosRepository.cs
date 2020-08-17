using MinhaCasa.Domain.NaoContemplados.Entities;
using System.Linq;

namespace MinhaCasa.Domain.NaoContemplados.Repositories
{
    public interface INaoContempladosRepository
    {
        IQueryable<Familia> Obter();
        IQueryable<Familia> Obter(int quantidadeContemplados);
    }
}