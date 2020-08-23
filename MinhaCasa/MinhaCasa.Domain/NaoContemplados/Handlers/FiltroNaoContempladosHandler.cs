using MinhaCasa.Domain.Enums;
using MinhaCasa.Domain.NaoContemplados.Commands;
using MinhaCasa.Domain.NaoContemplados.Contracts;
using MinhaCasa.Domain.NaoContemplados.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinhaCasa.Domain.NaoContemplados.Handlers
{
    public class FiltroNaoContempladosHandler :
        IHandler<FiltrarPorCriterioRendaTotalCommand>,
        IHandler<FiltrarPorCriterioPretendenteCommand>,
        IHandler<FiltrarPorCriterioDependenteCommand>
    {
        private readonly IRendaTotalCriterio _rendaTotalCriterio;
        private readonly IPretendenteCriterio _pretendenteCriterio;
        private readonly IDependenteCriterio _dependendeCriterio;

        public FiltroNaoContempladosHandler(IRendaTotalCriterio rendaCriterio, IPretendenteCriterio pretendenteCriterio, IDependenteCriterio dependendeCriterio)
        {
            _rendaTotalCriterio = rendaCriterio;
            _pretendenteCriterio = pretendenteCriterio;
            _dependendeCriterio = dependendeCriterio;
        }

        public IResultadoCommand Tratar(FiltrarPorCriterioRendaTotalCommand command)
        {
            command.Validar();
            if (command.Invalid)
                return new ResultadoCommand(0, 0, false, command.Notifications);

            var tratamentoCriterios = new Dictionary<ECategoriaRenda, Func<ResultadoCommand, IResultadoCommand>>()
            {
                { ECategoriaRenda.RendaAte900, _rendaTotalCriterio.TratarRendaFamiliarAte900Reais },
                { ECategoriaRenda.RendaEntre901A1500, _rendaTotalCriterio.TratarRendaFamiliarEntre1501A2000Reais},
                { ECategoriaRenda.RendaEntre1501A2000, _rendaTotalCriterio.TratarRendaFamiliarEntre901A1500Reais }
            };

            //command.CategoriaRenda = _rendaTotalCriterio.ObterCategoriaRenda(command.RendaTotal);
            var resultado = (ResultadoCommand)tratamentoCriterios[command.CategoriaRenda].Invoke(new ResultadoCommand());

            resultado.Sucesso = true;

            return resultado;
        }

        public IResultadoCommand Tratar(FiltrarPorCriterioPretendenteCommand command)
        {
            command.Validar();
            if (command.Invalid)
                return new ResultadoCommand(0, 0, false, command.Notifications);

            var tratamentoCriterios = new Dictionary<ECategoriaIdadePretendente, Func<ResultadoCommand, IResultadoCommand>>()
            {
                { ECategoriaIdadePretendente.IdadeAbaixo30Anos, _pretendenteCriterio.TratarIdadeAbaixo30Anos },
                { ECategoriaIdadePretendente.IdadeEntre30E44Anos, _pretendenteCriterio.TratarIdadeEntre30AE44Anos },
                { ECategoriaIdadePretendente.IdadeIgualOuMaior45Anos, _pretendenteCriterio.TratarIdadeIgualOuAcima45Anos }
            };

            //var pretendente = command.Pessoas.SingleOrDefault(p => p.TipoVinculoFamiliar.Equals(ETipoVinculoFamiliar.Pretendente));
            //command.CategoriaIdadePretendente = _pretendenteCriterio.ObterCategoriaIdadePretendente(pretendente.DataNascimento);

            var resultado = (ResultadoCommand)tratamentoCriterios[command.CategoriaIdadePretendente].Invoke(new ResultadoCommand());
            resultado.Sucesso = true;

            return resultado;
        }

        public IResultadoCommand Tratar(FiltrarPorCriterioDependenteCommand command)
        {
            command.Validar();
            if (command.Invalid)
                return new ResultadoCommand(0, 0, false, command.Notifications);

            var tratamentoCriterios = new Dictionary<ECategoriaDependente, Func<ResultadoCommand, IResultadoCommand>>()
            {
                { ECategoriaDependente.UmOuDois, _dependendeCriterio.TratarUmOuDoisDependentes },
                { ECategoriaDependente.TresOuMais, _dependendeCriterio.TratarTresOuMaisDependentes },
            };

            //var dependentes = command.Pessoas.Where(x => x.TipoVinculoFamiliar.Equals(ETipoVinculoFamiliar.Dependente));
            //command.CategoriaDependente = _dependendeCriterio.ObterCategoriaDependente(dependentes);

            var resultado = (ResultadoCommand)tratamentoCriterios[command.CategoriaDependente].Invoke(new ResultadoCommand());

            return resultado;
        }
    }
}