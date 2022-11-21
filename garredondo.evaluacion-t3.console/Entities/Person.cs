using garredondo.evaluacion_t3.core.Behavior;

namespace garredondo.evaluacion_t3.console.Entities
{
    public class Person : IEntityWithID
    {
        #region ID
        private readonly int _id;
        public int ID { get => _id; }
        #endregion

        #region Contructor
        public Person(int id)
        {
            _id = id;
        }
        #endregion

        #region Data
        public string? DNI { get; set; }
        public string? FullName { get; set; }
        #endregion
    }
}
