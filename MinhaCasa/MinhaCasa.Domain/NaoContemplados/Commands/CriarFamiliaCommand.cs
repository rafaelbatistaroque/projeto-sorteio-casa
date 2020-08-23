using Flunt.Notifications;
using Flunt.Validations;
using MinhaCasa.Domain.Enums;
using MinhaCasa.Domain.NaoContemplados.Contracts;
using MinhaCasa.Domain.NaoContemplados.ValuesObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhaCasa.Domain.NaoContemplados.Commands
{
    public class CriarFamiliaCommand : Notifiable, IBaseCommand
    {
        public string Nome { get; set; }
        public ETipoVinculoFamiliar TipoVinculoFamiliar { get; set; }
        public ECategoriaDependente CategoriaDependente { get; set; }
        public ECategoriaRenda CategoriaRenda { get; set; }
        public ECategoriaIdadePretendente CategoriaIdadePretendente { get; set; }
        public DateTime DataNascimento { get; set; }
        public decimal Renda { get; set; }

        public void Validar()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(Nome, 2, nameof(Nome),"O Nome deve ter no mínimo 2 caracteres.")
                .HasMaxLen(Nome, 60, nameof(Nome), "O Nome deve ter no máximo 60 caracteres.")
                .IsNotNull(TipoVinculoFamiliar,nameof(TipoVinculoFamiliar), "Tipo de vinculo familiar não pode ser nulo")
                .IsLowerThan(DataNascimento, DateTime.Now,nameof(DataNascimento),"A Data de Nascimento de ser menor que a data atual")
                .IsGreaterOrEqualsThan(Renda, 0, nameof(Renda), "A renda deve ser maior ou igual a 0"));
        }
    }
}
