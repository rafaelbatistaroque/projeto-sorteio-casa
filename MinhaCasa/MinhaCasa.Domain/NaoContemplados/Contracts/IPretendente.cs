using System.Threading.Tasks;

namespace MinhaCasa.Domain.NaoContemplados.Contracts
{
    public interface IPretendente : ICriterio
    {
        Task<bool> TemIdadeIgualOuAcima45Anos(ICommandBase command);
        Task<bool> TemIdadeEntre30AE4Anos(ICommandBase command);
        Task<bool> TemIdadeAbaixo30Anos(ICommandBase command);
    }
}
