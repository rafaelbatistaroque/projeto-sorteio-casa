using MinhaCasa.Domain.NaoContemplados.Interfaces;

namespace MinhaCasa.Domain.NaoContemplados.Contracts
{
    public interface IHandler<T> where T : IBaseCommand
    {
        IResultadoCommand Tratar(T command);
    }
}