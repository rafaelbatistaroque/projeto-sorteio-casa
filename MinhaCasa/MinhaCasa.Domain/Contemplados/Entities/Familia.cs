using System;
using System.Collections.Generic;
using System.Text;

namespace MinhaCasa.Domain.Contemplados.Entities
{
    public class Familia
    {
        public Guid Id { get; private set; }
        public int QuantidadeCriteriosAtendidos { get; private set; }
        public int PontuacaoTotal { get; private set; }
        public DateTime DataSelecao { get; private set; }
        
        public Familia(Guid id, int quantidadeCriteriosAtendidos, int pontuacaoTotal)
        {
            Id = id;
            QuantidadeCriteriosAtendidos = quantidadeCriteriosAtendidos;
            PontuacaoTotal = pontuacaoTotal;
            DataSelecao = DateTime.Now;
        }
    }
}
