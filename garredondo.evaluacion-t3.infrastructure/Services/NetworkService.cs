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
                Connections = new List<Connection<T>>()
            };
        }
        #endregion

        #region Implementation
        public void AddConnection(int id1, int id2)
        {
            if (!IsValidMap())
                return;

            if (id1 == id2)
                return;

            /// Si la conexión existe, no agrega la nueva conexión
            if (ConnectionExists(id1, id2))
                return;

            /// Buscamos los nodos con ID = id1, ID = id2
            var node1 = _network!.Nodes!.SingleOrDefault(x => x.ID == id1);
            var node2 = _network!.Nodes!.SingleOrDefault(x => x.ID == id2);

            if (node1 == null || node2 == null)
                return;

            var newConnection = new Connection<T>()
            {
                Node1 = node1,
                Node2 = node2
            };

            _network.Connections!.Add(newConnection);
        }

        public void AddNode(T node)
        {
            if (!IsValidMap())
                return;

            _network!.Nodes!.Add(node);
        }

        public bool ConnectionExists(int id1, int id2)
        {
            if (!IsValidMap())
                return false;

            var connectionExists = _network.Connections!.Any(x =>
                (x.Node1!.ID == id1 && x.Node2!.ID == id2) ||
                (x.Node1!.ID == id2 && x.Node2!.ID == id1));

            return connectionExists;
        }

        public IEnumerable<T>? GetAdjacentNodesByID(int id)
        {
            if (!IsValidMap())
                return null;

            var matches = new List<T>();

            /// Buscamos y agregamos conexiones donde esté del lado "Node1"
            var matches1 = _network.Connections!.Where(x => x.Node1?.ID == id).Select(x => x.Node2);
            if (matches1 != null)
                matches.AddRange(matches1!);

            /// Buscamos y agregamos conexiones donde esté del lado "Node2"
            var matches2 = _network.Connections!.Where(x => x.Node2?.ID == id).Select(x => x.Node1);
            if (matches2 != null)
                matches.AddRange(matches2!);

            /// Devuelve la lista de matches unida
            return matches;
        }
        #endregion

        #region Utils
        /// <summary>
        /// Hace una validación básica del atributo "_network".
        /// </summary>
        /// <returns>Devuelve true si es válido; false, en caso contrario.</returns>
        private bool IsValidMap()
        {
            if (_network == null)
                return false;

            if (_network.Nodes == null)
                return false;

            if (_network.Connections == null)
                return false;

            return true;
        }
        #endregion
    }
}
