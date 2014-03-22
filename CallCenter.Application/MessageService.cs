using System;
using System.Collections.Generic;
using CallCenter.CORE.Domain;
using CallCenter.DAL;

namespace CallCenter.Application
{
    internal class MessageService
    {

        private DBContext _dbContext;

        public MessageService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Método que retorna todos los mensajes
        /// </summary>
        /// <returns>Lista de Mensajes</returns>
        public List<Message> GetAll()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Método que retorna un mensaje según Id
        /// </summary>
        /// <returns>Mensaje</returns>
        public Message GetById()
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// Método que retorna todos los mensajes de un usuario
        /// </summary>
        /// <param name="userId">Id de Usuario</param>
        /// <returns>Lista de Mensajes</returns>
        public List<Message> GetByUser(Guid userId)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Método para añadir un mensaje
        /// </summary>
        /// <param name="message">entidad</param>
        /// <returns>Deveuelve el mensage añadido</returns>
        public Message Add(Message message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método para editar un mensaje
        /// </summary>
        /// <param name="message">enditdad</param>
        /// <returns>Mensaje Editado</returns>
        public Message Update(Message message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método que elimina un mensaje
        /// </summary>
        /// <param name="messageId">Id de Cliente</param>
        /// <returns>Si correcto o no la eliminación</returns>
        public bool Delete(Guid messageId)
        {
            throw new NotImplementedException();
        }

       


    }
}
