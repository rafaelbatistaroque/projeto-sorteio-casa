using MinhaCasa.Domain.Enums;
using MinhaCasa.Domain.NaoContemplados.ValuesObjects;
using System;

namespace MinhaCasa.Domain.NaoContemplados.Entities
{
    public class Pessoa : Entity
    {
        public string Nome { get; private set; }
        public ETipoVinculoFamiliar TipoVinculoFamiliar { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Renda Renda { get; private set; }
        public Guid FamiliaId { get; private set; }

        public Familia Familia { get; private set; }

        protected Pessoa() { }

        public Pessoa(string nome, ETipoVinculoFamiliar tipoVinculoFamiliar, DateTime dataNascimento, decimal renda, Guid familiaId)
        {
            Nome = nome;
            TipoVinculoFamiliar = tipoVinculoFamiliar;
            DataNascimento = dataNascimento;
            Renda = new Renda(renda);
            FamiliaId = familiaId;
        }

        public void AtualizarRenda(decimal renda)
        {
            new Renda(renda);
        }
    }
}