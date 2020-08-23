using MinhaCasa.Domain.Enums;
using MinhaCasa.Domain.NaoContemplados.Commands;
using MinhaCasa.Domain.NaoContemplados.Entities;
using MinhaCasa.Domain.NaoContemplados.Interfaces;
using System.Collections.Generic;

namespace MinhaCasa.Domain.NaoContemplados.Contracts
{
    public interface IDependenteCriterio : IService
    {
        IResultadoCommand TratarTresOuMaisDependentes(ResultadoCommand resultado);
        IResultadoCommand TratarUmOuDoisDependentes(ResultadoCommand resultado);
    }
}
