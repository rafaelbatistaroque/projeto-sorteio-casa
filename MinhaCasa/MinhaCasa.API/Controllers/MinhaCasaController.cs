using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaCasa.Domain.NaoContemplados.Commands;
using MinhaCasa.Domain.NaoContemplados.Entities;
using MinhaCasa.Domain.NaoContemplados.Handlers;
using MinhaCasa.Domain.NaoContemplados.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MinhaCasa.API.Controllers
{
    [ApiController]
    [Route("v1/minha-casa")]
    public class MinhaCasaController : ControllerBase
    {
        public MinhaCasaController()
        {

        }

        [HttpGet("familias")]
        public IEnumerable<Familia> Obter([FromServices] FiltroNaoContempladosHandler handler, [FromServices] INaoContempladosRepository repositorio)
        {
            var familias = repositorio.Obter(2);
            var resultados = new List<ResultadoCriterioCommand>();
            familias.ForEachAsync(familia =>
            {
                resultados.Add(handler.Tratar(new FiltrarPorCriterioRendaTotalCommand(familia.Id, familia.RendaTotal, familia.CategoriaRenda)) as ResultadoCriterioCommand);
                resultados.Add(handler.Tratar(new FiltrarPorCriterioPretendente(familia.Id, familia.Pessoas, familia.CategoriaIdadePretendente)) as ResultadoCriterioCommand);
                resultados.Add(handler.Tratar(new FiltrarPorCriterioDependente(familia.Id, familia.Pessoas, familia.CategoriaDependente)) as ResultadoCriterioCommand);

                familia.AdicionarPontuacao(resultados.Sum(r => r.Pontuacao));
                familia.AdicionarQuantidadeCriteriosAtendidos(resultados.Sum(r => r.QuantidadeCriteriosAtendidos));
            });

            return familias;
        }
    }
}
