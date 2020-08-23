using MinhaCasa.Domain.Enums;
using MinhaCasa.Domain.NaoContemplados.Commands;
using MinhaCasa.Domain.NaoContemplados.Interfaces;
using System;

namespace MinhaCasa.Domain.NaoContemplados.Contracts
{
    public interface IPretendenteCriterio : IService
    {
        IResultadoCommand TratarIdadeIgualOuAcima45Anos(ResultadoCommand resultado);
        IResultadoCommand TratarIdadeEntre30AE44Anos(ResultadoCommand resultado);
        IResultadoCommand TratarIdadeAbaixo30Anos(ResultadoCommand resultado);
    }
}
