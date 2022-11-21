using garredondo.evaluacion_t3.core.Behavior;

namespace garredondo.evaluacion_t3.core.Entities
{
    public class Connection<T> where T : IEntityWithID
    {
        public T? Node1 { get; set; }
        public T? Node2 { get; set; }
    }
}
