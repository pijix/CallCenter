using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CallCenter.CORE.Domain;
using CallCenter.DAL;

namespace CallCenter.Application
{
    public class MessageService
    {

        private DBContext _dbContext;

        public MessageService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

    /// <summary>
        /// Método que retorna todos los mensajes de un usuario
        /// </summary>
        /// <param name="incidenceId">Id de Usuario</param>
        /// <returns>Lista de Mensajes</returns>
        public IQueryable<Message> GetByIncidence(Guid incidenceId)
        {
            return _dbContext.Messages.Where(a=>a.IncidenceId == incidenceId);
        }


        /// <summary>
        /// Método para añadir un mensaje
        /// </summary>
        /// <param name="message">entidad</param>
        /// <returns>Deveuelve el mensage añadido</returns>
        public Message Add(Message message)
        {
            try
            {
                var newMessage = _dbContext.Messages.Add(message);
                _dbContext.SaveChanges();
                return newMessage;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al añadir el Mensaje: " + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Elimina todos los mensajes de una incidencia
        /// </summary>
        /// <param name="incidenceId">entidad</param>
        public bool DeleleMessages(Guid incidenceId)
        {
            try
            {
                var messages = GetByIncidence(incidenceId).ToList();
                foreach (var message in messages)
                {
                    _dbContext.Messages.Remove(message);
                }
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al añadir el Mensaje: " + ex.InnerException.Message);
            }
        }
    }
}
