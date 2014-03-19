using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CallCenter.CORE.Domain;
using CallCenter.DAL;

namespace CallCenter.Application
{
    internal class ClientService
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
            return _dbContext.Clients.Include(e=> e.Equipments).ToList();
        }


        /// <summary>
        /// Método que retorna una cliente
        /// </summary>
        /// <param name="clientId">identificador del cliente</param>
        /// <returns>Cliete</returns>
        public Client GetById(Guid clientId)
        {
            return _dbContext.Clients.Include(e=> e.Equipments).FirstOrDefault(a => a.Id == clientId);
        }

        /// <summary>
        /// Método que busca clientes
        /// </summary>
        /// <param name="name">texto a buscar</param>
        /// <returns>Lista de clientes</returns>
        public List<Client> GetByName(string name)
        {
            return _dbContext.Clients.Include(e => e.Equipments).Where(a => a.Name.Contains(name)).ToList();
        }

        /// <summary>
        /// Permite añdir un cliente
        /// </summary>
        /// <param name="client">equipo</param> 
        /// <returns>El equipo añadido</returns>
        public Client Add(Client client)
        {
            try
            {
                var newClient = _dbContext.Clients.Add(client);
                _dbContext.SaveChanges();
                return newClient;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al añadir el Cliente " + ex.Message);
            }
        }


        /// <summary>
        /// Permite editar un cliente
        /// </summary>
        /// <param name="client">cliente</param>    
        /// <returns>El cliente añadido</returns>
        public Client Update(Client client)
        {
            try
            {
                var clientExist = GetById(client.Id);
                if (clientExist == null) throw new Exception("Cliente inexistente, no se puede editar...");
                clientExist.Mail = client.Mail;
                clientExist.Name = client.Name;
                clientExist.Equipments = client.Equipments;
                _dbContext.SaveChanges();
                return client;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Editando el Cliente " + ex.Message);
            }
        }

        /// <summary>
        /// Permite eliminar un cliente
        /// </summary>
        /// <param name="clientId">identificador del cliente</param>     
        /// <returns>true o false por si se elimino correctamente</returns>
        public bool Delete(Guid clientId)
        {
            try
            {
                var clientExist = GetById(clientId);
                if (clientExist == null) throw new Exception("Cliente inexistente, no se puede eliminar...");
                _dbContext.Clients.Remove(clientExist);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error eliminando Cliente " + ex.Message);
            }

        }

    }

}
