using MinhaCasa.Domain.NaoContemplados.Contracts;
using MinhaCasa.Shared.Enums;
using System.Collections.Generic;
using System.Linq;

namespace MinhaCasa.Domain.NaoContemplados.Entities
{
    public class Familia : Entity, IAggregateRoot
    {
        private readonly IList<Pessoa> _pessoas;

        public EStatusFamilia Status { get; private set; }
        public int Pontuacao { get; private set; }
        public int QuantidadeCriteriosAtendidos { get; private set; }
        public decimal RendaTotal => CalcularRendaTotal();
        public virtual IReadOnlyCollection<Pessoa> Pessoas => _pessoas.ToArray();

        public Familia(EStatusFamilia status, int pontuacao, int quantidadeCriteriosAtendidos)
        {
            Status = status;
            Pontuacao = pontuacao;
            QuantidadeCriteriosAtendidos = quantidadeCriteriosAtendidos;
            _pessoas = new List<Pessoa>();
        }

        public void AdicionarPontuacao(ETipoPontuacao pontuacao)
        {
            Pontuacao += (int)pontuacao;
        }

        public void AdicionarMembroFamiliar(Pessoa pessoa)
        {
            _pessoas.Add(pessoa);
        }

        public decimal CalcularRendaTotal()
        {
            return _pessoas.Sum(x => x.Renda.Valor);
        }
    }
}
