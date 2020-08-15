using MinhaCasa.Domain.NaoContemplados.ValuesObjects;
using MinhaCasa.Shared.Enums;
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

        public virtual Familia Familia { get; private set; }

        public Pessoa(string nome, ETipoVinculoFamiliar tipoVinculoFamiliar, DateTime dataNascimento, Renda renda, Guid familiaId)
        {
            Nome = nome;
            TipoVinculoFamiliar = tipoVinculoFamiliar;
            DataNascimento = dataNascimento;
            Renda = renda;
            FamiliaId = familiaId;
        }
    }
}