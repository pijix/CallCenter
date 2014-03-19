using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using CallCenter.CORE.Domain;
using CallCenter.DAL;

namespace CallCenter.Application
{
    public class IncidenceService
    {
        private DBContext _dbContext;

        public IncidenceService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }



        /// <summary>
        /// Método que retorna todas las incidencias
        /// </summary>
        /// <returns>Lista de incidencias</returns>
        public List<Incidence> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método que retorna una incidencia
        /// </summary>
        /// <param name="incidenceId">identificador del usuario</param>
        /// <returns>Una incidencia</returns>
        public Incidence GetById(Guid incidenceId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método que retorna una lista de incidencias por usuario
        /// </summary>
        /// <param name="userId">identificador del usuario</param>
        /// <returns>Lista de incidencias</returns>
        public List<Incidence> GetByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método que retorna una lista de incidencias por equipo
        /// </summary>
        /// <param name="equipmentId">identificador del equipo</param>
        /// <returns>Lista de incidencias</returns>
        public List<Incidence> GetByEquipment(Guid equipmentId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método que retorna una lista de incidencias por cliente
        /// </summary>
        /// <param name="clientId">identificador del cliente</param>
        /// <returns>Lista de incidencias</returns>
        public List<Incidence> GetByClient(Guid clientId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Permite añdir una Incidencia
        /// </summary>
        /// <param name="incidence">entidad incidence</param>       
        /// <returns>La incidencia añadida</returns>
        public Incidence Add(Incidence incidence)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Permite editar una Incidencia
        /// </summary>
        /// <param name="incidence">entidad</param>    
        /// <returns>La incidencia editada</returns>
        public Incidence Update(Incidence incidence)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Permite eliminar una Incidencia
        /// </summary>
        /// <param name="incidenceId">identificador de la incidencia</param>     
        /// <returns>true o false por si se elimino correctamente</returns>
        public bool Delete(Guid incidenceId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Permite cambiar el estado de una incidencia
        /// </summary>
        /// <param name="status">identificador de la incidencia</param>     
        public void ChangeStatus(IncidenceStatus status)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retorna todos los mensajes de una incidencia
        /// </summary>
        /// <param name="incidenceId">identificador de la incidencia</param>     
        /// <returns>Lista de mensajes</returns>
        public List<Message> GetMessages(Guid incidenceId)
        {
            throw new NotImplementedException();
        }

    }
}
