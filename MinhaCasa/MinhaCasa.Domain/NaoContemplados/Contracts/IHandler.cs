using System.Threading.Tasks;

namespace MinhaCasa.Domain.NaoContemplados.Contracts
{
    public interface IHandler<T> where T : ICommandBase 
    {
        ICommandResult CalcularCriterio(T command);
    }
}
