using Microsoft.EntityFrameworkCore;
using MinhaCasa.Domain.NaoContemplados.Entities;
using MinhaCasa.Domain.NaoContemplados.Queries;
using MinhaCasa.Domain.NaoContemplados.Repositories;
using MinhaCasa.Infra.Context;
using System.Collections.Generic;
using System.Linq;

namespace MinhaCasa.Infra.Repositories
{
    public class NaoContempladosRepository : INaoContempladosRepository
    {
        private readonly IList<Familia> _familias;
        private readonly DataContext _context;

        public NaoContempladosRepository(DataContext context)
        {
            _context = context;
            //_familias = new List<Familia> {
            //    new Familia(EStatusFamilia.CadastroValido, ECategoriaRenda.RendaAte900,ECategoriaIdadePretendente.IdadeAbaixo30Anos, ECategoriaDependente.TresOuMais),
            //    new Familia(EStatusFamilia.JaPossuiCasa, ECategoriaRenda.RendaAte900,ECategoriaIdadePretendente.IdadeEntre30E44Anos, ECategoriaDependente.UmOuDois),
            //    new Familia(EStatusFamilia.CadastroIncompleto, ECategoriaRenda.RendaAte900,ECategoriaIdadePretendente.IdadeIgualOuMaior45Anos, ECategoriaDependente.TresOuMais),
            //    new Familia(EStatusFamilia.CadastroValido, ECategoriaRenda.RendaAte900,ECategoriaIdadePretendente.IdadeAbaixo30Anos, ECategoriaDependente.TresOuMais),
            //    new Familia(EStatusFamilia.CadastroValido, ECategoriaRenda.RendaEntre901A1500,ECategoriaIdadePretendente.IdadeEntre30E44Anos, ECategoriaDependente.UmOuDois),
            //    new Familia(EStatusFamilia.CadastroValido, ECategoriaRenda.RendaEntre1501A2000,ECategoriaIdadePretendente.IdadeAbaixo30Anos, ECategoriaDependente.TresOuMais),
            //    new Familia(EStatusFamilia.CadastroValido, ECategoriaRenda.RendaAte900,ECategoriaIdadePretendente.IdadeAbaixo30Anos, ECategoriaDependente.TresOuMais),
            //    new Familia(EStatusFamilia.SelecionadoEmOutroProcessoDeSelecao, ECategoriaRenda.RendaAte900,ECategoriaIdadePretendente.IdadeAbaixo30Anos, ECategoriaDependente.UmOuDois),
            //    new Familia(EStatusFamilia.CadastroValido, ECategoriaRenda.RendaAte900,ECategoriaIdadePretendente.IdadeEntre30E44Anos, ECategoriaDependente.TresOuMais),
            //    new Familia(EStatusFamilia.CadastroValido, ECategoriaRenda.RendaEntre901A1500,ECategoriaIdadePretendente.IdadeIgualOuMaior45Anos, ECategoriaDependente.TresOuMais),
            //    new Familia(EStatusFamilia.JaPossuiCasa, ECategoriaRenda.RendaAte900,ECategoriaIdadePretendente.IdadeAbaixo30Anos, ECategoriaDependente.TresOuMais),
            //    new Familia(EStatusFamilia.CadastroValido, ECategoriaRenda.RendaEntre1501A2000,ECategoriaIdadePretendente.IdadeEntre30E44Anos, ECategoriaDependente.UmOuDois),
            //    new Familia(EStatusFamilia.CadastroIncompleto, ECategoriaRenda.RendaAte900,ECategoriaIdadePretendente.IdadeAbaixo30Anos, ECategoriaDependente.TresOuMais),
            //    new Familia(EStatusFamilia.CadastroValido, ECategoriaRenda.RendaAte900,ECategoriaIdadePretendente.IdadeIgualOuMaior45Anos, ECategoriaDependente.UmOuDois),
            //    new Familia(EStatusFamilia.CadastroValido, ECategoriaRenda.RendaEntre901A1500,ECategoriaIdadePretendente.IdadeAbaixo30Anos, ECategoriaDependente.TresOuMais),
            //    new Familia(EStatusFamilia.CadastroValido, ECategoriaRenda.RendaEntre1501A2000,ECategoriaIdadePretendente.IdadeIgualOuMaior45Anos, ECategoriaDependente.UmOuDois)
            //};

            //_familias = new List<Familia> {
            //    new Familia(EStatusFamilia.CadastroValido, ECategoriaRenda.RendaEntre901A1500,ECategoriaIdadePretendente.IdadeIgualOuMaior45Anos, ECategoriaDependente.UmOuDois)
            //};

            //var _50anos = DateTime.Parse("30/12/1970");
            //var _30anos = DateTime.Parse("30/12/1990");
            //var _15anos = DateTime.Parse("30/12/2005");
            //var _10anos = DateTime.Parse("30/12/2010");

            //_familias.ToList().ForEach(familia => familia.AdicionarMembroFamiliar(
            //    new Pessoa($"Pedro1-{familia.Id.ToString().Replace("-", "").Substring(0, 5).ToUpper()}", ETipoVinculoFamiliar.Dependente, _15anos, 0, familia.Id)
            //));

            //_familias.ToList().ForEach(familia => familia.AdicionarMembroFamiliar(
            //    new Pessoa($"Pedro2-{familia.Id.ToString().Replace("-", "").Substring(0, 5).ToUpper()}", ETipoVinculoFamiliar.Dependente, _15anos, 0, familia.Id)
            //));

            //_familias.ToList().ForEach(familia => familia.AdicionarMembroFamiliar(
            //    new Pessoa($"Pedro3-{familia.Id.ToString().Replace("-", "").Substring(0, 5).ToUpper()}", ETipoVinculoFamiliar.Dependente, _10anos, 0, familia.Id)
            //));

            //_familias.ToList().ForEach(familia => familia.AdicionarMembroFamiliar(
            //    new Pessoa($"Maria-{familia.Id.ToString().Replace("-", "").Substring(0, 5).ToUpper()}", ETipoVinculoFamiliar.Pretendente, _50anos, 0, familia.Id)
            //));

            //_familias.ToList().ForEach(familia => familia.AdicionarMembroFamiliar(
            //    new Pessoa($"João-{familia.Id.ToString().Replace("-", "").Substring(0, 5).ToUpper()}", ETipoVinculoFamiliar.Conjuge, _50anos, 900, familia.Id)
            //));
        }

        public void CriarFamilia(Familia familia)
        {
            _context.Add(familia);
            _context.SaveChanges();
        }

        public IQueryable<Familia> Obter(int quantidadeContemplados)
        {
            var resultado = _context.Familias.Include(x=>x.Pessoas).Where(NaoContempladosQuery.ObterFamiliasAptasParaSelecao()).AsQueryable();//.Take(quantidadeContemplados);

            return resultado;
        }

        public IQueryable<Familia> Obter()
        {
            return _context.Familias.AsQueryable().Where(NaoContempladosQuery.ObterFamiliasAptasParaSelecao());
            //return _familias.AsQueryable().Where(NaoContempladosQuery.ObterFamiliasAptasParaSelecao());
        }
    }
}
