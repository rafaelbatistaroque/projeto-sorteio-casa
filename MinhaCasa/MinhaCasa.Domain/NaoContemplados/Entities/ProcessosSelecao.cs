using System;

namespace MinhaCasa.Domain.NaoContemplados.Entities
{
    public class ProcessosSelecao : Entity
    {
        public Guid FamiliaId { get; private set; }
        public Familia Familia { get; private set; }

        public ProcessosSelecao(Guid familiaId)
        {
            FamiliaId = familiaId;
        }
    }
}
