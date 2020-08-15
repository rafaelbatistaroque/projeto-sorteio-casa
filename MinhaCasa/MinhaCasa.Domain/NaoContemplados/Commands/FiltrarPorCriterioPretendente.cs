using MinhaCasa.Domain.NaoContemplados.Contracts;
using MinhaCasa.Domain.NaoContemplados.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace MinhaCasa.Domain.NaoContemplados.Commands
{
    public class FiltrarPorCriterioPretendente :  ICommandBase
    {
        public Guid Id { get; set; }
        public int Pontuacao { get; set; }
        public int QuantidadeCriteriosAtendidos { get; set; }
        public IEnumerable<Pessoa> Pessoas { get; set; }
        public FiltrarPorCriterioPretendente(){}

        public FiltrarPorCriterioPretendente(Guid id, IEnumerable<Pessoa> pessoas)
        {
            Id = id;
            Pessoas = pessoas;
        }
    }
}
