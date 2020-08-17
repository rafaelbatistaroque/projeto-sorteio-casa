using MinhaCasa.Domain.Enums;
using MinhaCasa.Domain.NaoContemplados.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MinhaCasa.Domain.NaoContemplados.Entities
{
    public class Familia : Entity, IAggregateRoot
    {
        private readonly IList<Pessoa> _pessoas;
        private readonly IList<ProcessosSelecao> _processoSelecao;

        public int Pontuacao { get; private set; }
        public int QuantidadeCriteriosAtendidos { get; private set; }
        public decimal RendaTotal => CalcularRendaTotal();
        public ECategoriaDependente CategoriaDependente { get; private set; }
        public ECategoriaRenda CategoriaRenda { get; private set; }
        public ECategoriaIdadePretendente CategoriaIdadePretendente { get; private set; }
        public EStatusFamilia Status { get; private set; }

        public virtual IReadOnlyCollection<Pessoa> Pessoas => _pessoas.ToArray();
        public virtual IReadOnlyCollection<ProcessosSelecao> ProcessosSelecao => _processoSelecao.ToArray();

        public Familia(EStatusFamilia status, int pontuacao, int quantidadeCriteriosAtendidos, ECategoriaRenda categoriaRenda, ECategoriaIdadePretendente categoriaIdadePretendente, ECategoriaDependente categoriaDependente)
        {
            Status = status;
            Pontuacao = pontuacao;
            QuantidadeCriteriosAtendidos = quantidadeCriteriosAtendidos;
            CategoriaRenda = categoriaRenda;
            CategoriaIdadePretendente = categoriaIdadePretendente;
            CategoriaDependente = categoriaDependente;
            _pessoas = new List<Pessoa>();
            _processoSelecao = new List<ProcessosSelecao>();
        }

        public void AdicionarPontuacao(int pontuacao)
        {
            Pontuacao += pontuacao;
        }

        public void AdicionarQuantidadeCriteriosAtendidos(int quantidadeCriterios)
        {
            QuantidadeCriteriosAtendidos += quantidadeCriterios;
        }

        public void AdicionarMembroFamiliar(Pessoa pessoa)
        {
            _pessoas.Add(pessoa);
        }

        public void AdicionarProcessoSelecao(ProcessosSelecao processo)
        {
            _processoSelecao.Add(processo);
        }

        public decimal CalcularRendaTotal()
        {
            return _pessoas.Sum(x => x.Renda.Valor);
        }
    }
}