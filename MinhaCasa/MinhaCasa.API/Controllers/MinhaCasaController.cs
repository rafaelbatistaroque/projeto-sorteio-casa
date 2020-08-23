using Microsoft.AspNetCore.Mvc;
using MinhaCasa.Domain.NaoContemplados.Commands;
using MinhaCasa.Domain.NaoContemplados.Handlers;
using MinhaCasa.Domain.NaoContemplados.Interfaces;
using MinhaCasa.Domain.NaoContemplados.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MinhaCasa.API.Controllers
{
    [ApiController]
    [Route("v1/minha-casa")]
    public class MinhaCasaController : ControllerBase
    {
        [HttpGet("familias/{quantidade}")]
        public IActionResult Obter(int quantidade, [FromServices] FiltroNaoContempladosHandler handler, [FromServices] INaoContempladosRepository repositorio)
        {
            var familias = repositorio.Obter(quantidade);
            var resultados = new List<ResultadoCommand>();

            familias.ToList().ForEach(familia =>
            {
                resultados.Add(handler.Tratar(new FiltrarPorCriterioRendaTotalCommand(familia.Id, familia.RendaTotal, familia.CategoriaRenda)) as ResultadoCommand);
                resultados.Add(handler.Tratar(new FiltrarPorCriterioPretendenteCommand(familia.Id, familia.Pessoas, familia.CategoriaIdadePretendente)) as ResultadoCommand);
                resultados.Add(handler.Tratar(new FiltrarPorCriterioDependenteCommand(familia.Id, familia.Pessoas, familia.CategoriaDependente)) as ResultadoCommand);

                familia.AdicionarPontuacao(resultados.Sum(r => r.Pontuacao));
                familia.AdicionarQuantidadeCriteriosAtendidos(resultados.Sum(r => r.QuantidadeCriteriosAtendidos));

                resultados.Clear();
            });

            return Ok(familias);
        }

        [HttpPost("criar")]
        public IResultadoCommand CriarFamilia(CriarFamiliaCommand command, [FromServices] CRUDNaoContempladosHandler handler)
        {
            return (ResultadoCommand)handler.Tratar(command);
        }
    }
}
