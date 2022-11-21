using garredondo.evaluacion_t3.core.Behavior;

namespace garredondo.evaluacion_t3.core.Entities
{
    public class Network<T> where T : IEntityWithID
    {
        public List<T>? Nodes { get; set; }
        public List<Connection<T>>? Edges { get; set; }
    }
}
