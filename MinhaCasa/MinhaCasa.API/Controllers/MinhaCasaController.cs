using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MinhaCasa.Domain.Contemplados.Entities;

namespace MinhaCasa.API.Controllers
{
    [ApiController]
    [Route("v1/selecao-minha-casa")]
    public class MinhaCasaController : ControllerBase
    {
        public MinhaCasaController()
        {

        }

        [HttpGet("familias")]
        public IEnumerable<Familia> Obter()
        {
            return null;
        }
    }
}
