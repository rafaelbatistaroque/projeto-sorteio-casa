using MinhaCasa.Domain.NaoContemplados.Entities;

namespace MinhaCasa.Domain.NaoContemplados.ValuesObjects
{
    public class Renda
    {
        public decimal Valor { get; private set; }
        public Pessoa Pessoa { get; private set; }


        private Renda() { }

        public Renda(decimal valor)
        {
            Valor = valor;
        }
    }
}