using garredondo.evaluacion_t3.core.Behavior;

namespace garredondo.evaluacion_t3.core.Services
{
    public interface INetworkService<T> where T : IEntityWithID
    {
        /// <summary>
        /// Agrega un nodo
        /// </summary>
        /// <param name="node">Datos del nodo</param>
        void AddNode(T node);

        /// <summary>
        /// Agrega una conexión entre dos nodos
        /// </summary>
        /// <param name="id1">ID del nodo 1</param>
        /// <param name="id2">ID del nodo 2</param>
        void AddConnection(int id1, int id2);

        /// <summary>
        /// Devuelve true si existe la conexión entre dos nodos
        /// </summary>
        /// <param name="id1">ID del nodo 1</param>
        /// <param name="id2">ID del nodo 2</param>
        /// <returns></returns>
        bool ConnectionExists(int id1, int id2);

        /// <summary>
        /// Devuelve true si los nodos id1, id2 tienen una conexión en común con el nodo idCommon.
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <param name="idCommon"></param>
        /// <returns></returns>
        bool HaveSpecificMutualConnection(int id1, int id2, int idCommon);
    }
}
