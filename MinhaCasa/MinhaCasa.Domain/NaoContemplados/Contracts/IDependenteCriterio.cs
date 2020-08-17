using MinhaCasa.Domain.Enums;
using MinhaCasa.Domain.NaoContemplados.Commands;
using MinhaCasa.Domain.NaoContemplados.Entities;
using MinhaCasa.Domain.NaoContemplados.Interfaces;
using System.Collections.Generic;

namespace MinhaCasa.Domain.NaoContemplados.Contracts
{
    public interface IDependenteCriterio : ICriterio
    {
        ICommandResult TratarTresOuMaisDependentes(ResultadoCriterioCommand resultado);
        ICommandResult TratarUmOuDoisDependentes(ResultadoCriterioCommand resultado);

        ECategoriaDependente ObterCategoriaDependente(IEnumerable<Pessoa> pessoas);
    }
}
