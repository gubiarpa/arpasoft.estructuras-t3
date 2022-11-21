using garredondo.evaluacion_t3.console.Entities;
using garredondo.evaluacion_t3.core.Services;
using garredondo.evaluacion_t3.infrastructure.Services;
using System.Text;

namespace garredondo.evaluacion_t3.console.Utils
{
    public class Loader
    {
        #region Networking
        private readonly INetworkService<Person> _networkingService;

        public Loader(INetworkService<Person> networkingService)
        {
            _networkingService = networkingService;
        }
        #endregion

        #region Loading
        /// <summary>
        /// Carga la lista de personas
        /// </summary>
        public void LoadPersons()
        {
            _networkingService.AddNode(new Person(2) { DNI = GenerateRandomDNI(), FullName = "Juan" });
            _networkingService.AddNode(new Person(1) { DNI = GenerateRandomDNI(), FullName = "Billy" });
            _networkingService.AddNode(new Person(3) { DNI = GenerateRandomDNI(), FullName = "Gianfranco" });
            _networkingService.AddNode(new Person(4) { DNI = GenerateRandomDNI(), FullName = "Rosa" });
            _networkingService.AddNode(new Person(5) { DNI = GenerateRandomDNI(), FullName = "Gabriel" });
            _networkingService.AddNode(new Person(6) { DNI = GenerateRandomDNI(), FullName = "Lourdes" });
            _networkingService.AddNode(new Person(7) { DNI = GenerateRandomDNI(), FullName = "Ana" });
            _networkingService.AddNode(new Person(8) { DNI = GenerateRandomDNI(), FullName = "Cristobal" });
            _networkingService.AddNode(new Person(9) { DNI = GenerateRandomDNI(), FullName = "Blanca" });
            _networkingService.AddNode(new Person(10) { DNI = GenerateRandomDNI(), FullName = "Greta" });
        }

        /// <summary>
        /// Carga la lista de conexiones.
        /// </summary>
        public void LoadConnections()
        {
            _networkingService.AddConnection(1, 2);
            _networkingService.AddConnection(1, 3);
            _networkingService.AddConnection(2, 3);
            _networkingService.AddConnection(3, 4);
            _networkingService.AddConnection(3, 5);
            _networkingService.AddConnection(4, 6);
            _networkingService.AddConnection(5, 6);
            _networkingService.AddConnection(4, 10);
            _networkingService.AddConnection(6, 10);
            _networkingService.AddConnection(6, 7);
            _networkingService.AddConnection(7, 8);
            _networkingService.AddConnection(8, 9);
            _networkingService.AddConnection(9, 6);
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Genera un DNI de 8 aleatoriamente.
        /// </summary>
        /// <returns>Devuelve el DNI.</returns>
        private static string GenerateRandomDNI()
        {
            var random = new Random();
            
            var dni = new StringBuilder();

            for (int i = 0; i < 8; i++)
                dni.Append(random.Next(0, 10).ToString());

            return dni.ToString();
        }
        #endregion
    }
}
