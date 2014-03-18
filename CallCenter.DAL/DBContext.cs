using System.Data.Entity;
using CallCenter.CORE.Domain;

namespace CallCenter.DAL
{
    /// 
    /// Contexto de datos
    /// 
    public class DBContext : DbContext
    {
        /// 
        /// Constructor que recibe el nombre de la cadena de conexión o la cadena de conexión
        /// 
        public DBContext(string nameOrConnectionString = "DefaultConnection") : base(nameOrConnectionString)
        {
        }

        /// 
        /// Colección de entidades
        /// 
        public IDbSet<Incidence> Incidences { get; set; }
        public IDbSet<Equipment> Equipments { get; set; }
        public IDbSet<Message> Messages { get; set; }
        public IDbSet<Client> Clients  { get; set; } 

    }

}
