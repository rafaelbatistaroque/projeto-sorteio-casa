namespace MinhaCasa.Domain.NaoContemplados.ValuesObjects
{
    public class Renda
    {
        public decimal Valor { get; private set; }

        private Renda() { }

        public Renda(decimal valor)
        {
            Valor = valor;
        }
    }
}