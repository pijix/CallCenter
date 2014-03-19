using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CallCenter.CORE.Domain;
using CallCenter.DAL;

namespace CallCenter.Application
{
    class ClientService
    {

        private DBContext _dbContext;

        public ClientService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }


        /// <summary>
        /// Método que retorna todos los clientes
        /// </summary>
        /// <returns>Lista de clientes</returns>
        public List<Client> GetAll()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Método que retorna una cliente
        /// </summary>
        /// <param name="clientId">identificador del cliente</param>
        /// <returns>Equipo</returns>
        public Client GetById(Guid clientId)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Permite añdir un cliente
        /// </summary>
        /// <param name="client">equipo</param> 
        /// <returns>El equipo añadido</returns>
        public Client Add(Client client)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Permite editar un cliente
        /// </summary>
        /// <param name="client">cliente</param>    
        /// <returns>El cliente añadido</returns>
        public Client Update(Client client)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Permite eliminar un cliente
        /// </summary>
        /// <param name="clientId">identificador del cliente</param>     
        /// <returns>true o false por si se elimino correctamente</returns>
        public bool Delete(Guid clientId)
        {
            throw new NotImplementedException();
        }

    }
}
