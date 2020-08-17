using MinhaCasa.Domain.Enums;
using MinhaCasa.Domain.NaoContemplados.Commands;
using MinhaCasa.Domain.NaoContemplados.Interfaces;
using System;

namespace MinhaCasa.Domain.NaoContemplados.Contracts
{
    public interface IPretendenteCriterio : ICriterio
    {
        ICommandResult TratarIdadeIgualOuAcima45Anos(ResultadoCriterioCommand resultado);
        ICommandResult TratarIdadeEntre30AE44Anos(ResultadoCriterioCommand resultado);
        ICommandResult TratarIdadeAbaixo30Anos(ResultadoCriterioCommand resultado);

        ECategoriaIdadePretendente ObterCategoriaIdadePretendente(DateTime dataNascimento);
    }
}
