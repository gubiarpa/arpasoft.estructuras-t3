using garredondo.evaluacion_t3.core.Behavior;
using garredondo.evaluacion_t3.core.Entities;
using garredondo.evaluacion_t3.core.Services;

namespace garredondo.evaluacion_t3.infrastructure.Services
{
    public class NetworkService<T> : INetworkService<T> where T : IEntityWithID
    {
        #region Map
        private readonly Network<T> _network;

        public NetworkService()
        {
            _network = new Network<T>()
            {
                Nodes = new List<T>(),
                Edges = new List<Connection<T>>()
            };
        }
        #endregion

        #region Implementation
        public void AddConnection(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        public void AddNode(T node)
        {
            throw new NotImplementedException();
        }

        public bool ConnectionExists(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T>? GetAdjacentNodesByID(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
