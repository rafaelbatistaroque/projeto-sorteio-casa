using System;

namespace MinhaCasa.Domain.NaoContemplados.ValuesObjects
{
    public class Renda
    {
        public decimal Valor { get; private set; }

        public Renda(decimal valor)
        {
            Valor = valor;
        }
    }
}