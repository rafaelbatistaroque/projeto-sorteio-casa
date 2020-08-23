using MinhaCasa.Domain.Enums;
using MinhaCasa.Domain.NaoContemplados.Commands;
using MinhaCasa.Domain.NaoContemplados.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MinhaCasa.Domain.NaoContemplados.Entities
{
    public class Familia : Entity, IRoot
    {
        private readonly List<Pessoa> _pessoas;
        private readonly List<ProcessosSelecao> _processoSelecao;

        public int Pontuacao { get; private set; }
        public int QuantidadeCriteriosAtendidos { get; private set; }
        public decimal RendaTotal => CalcularRendaTotal();
        public ECategoriaDependente CategoriaDependente { get; private set; }
        public ECategoriaRenda CategoriaRenda { get; private set; }
        public ECategoriaIdadePretendente CategoriaIdadePretendente { get; private set; }
        public EStatusFamilia Status { get; private set; }

        public IReadOnlyCollection<Pessoa> Pessoas => _pessoas.ToHashSet();
        public IReadOnlyCollection<ProcessosSelecao> ProcessosSelecao => _processoSelecao.ToHashSet();
        
        public Familia(EStatusFamilia status, ECategoriaRenda categoriaRenda)
        {
            Status = status;
            CategoriaRenda = categoriaRenda;
            _pessoas ??= new List<Pessoa>();
            _processoSelecao ??= new List<ProcessosSelecao>();
        }

        public Familia(EStatusFamilia status, ECategoriaRenda categoriaRenda, ECategoriaIdadePretendente categoriaIdadePretendente)
            : this(status, categoriaRenda)
        {
            CategoriaIdadePretendente = categoriaIdadePretendente;
            _pessoas ??= new List<Pessoa>();
            _processoSelecao ??= new List<ProcessosSelecao>();
        }

        public Familia(EStatusFamilia status, ECategoriaRenda categoriaRenda, ECategoriaDependente categoriaDependente)
            : this(status, categoriaRenda)
        {
            CategoriaDependente = categoriaDependente;
            _pessoas ??= new List<Pessoa>();
            _processoSelecao ??= new List<ProcessosSelecao>();
        }

        public void AtualizarCategoriaDependente(ECategoriaDependente novoValor)
        {
            CategoriaDependente = novoValor;
        }

        public void AtualizarCategoriaPretendente(ECategoriaIdadePretendente novoValor)
        {
            CategoriaIdadePretendente = novoValor;
        }

        public void AtualizarCategoriaRenda(ECategoriaRenda novoValor)
        {
            CategoriaRenda = novoValor;
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