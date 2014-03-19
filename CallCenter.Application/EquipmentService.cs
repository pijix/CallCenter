using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using CallCenter.CORE.Domain;
using CallCenter.DAL;

namespace CallCenter.Application
{
    class EquipmentService
    {

        private DBContext _dbContext;
        public EquipmentService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }


        /// <summary>
        /// Método que retorna todos los Equipos
        /// </summary>
        /// <returns>Lista de equipos</returns>
        public List<Equipment> GetAll()
        {
            throw new NotImplementedException();
        }

       
        /// <summary>
        /// Método que retorna una equipo
        /// </summary>
        /// <param name="equipmentId">identificador del equipo</param>
        /// <returns>Equipo</returns>
        public Equipment GetById(Guid equipmentId)
        {
            throw new NotImplementedException();
        }

       
        /// <summary>
        /// Permite añdir un equipo
        /// </summary>
        /// <param name="equipment">equipo</param> 
        /// <returns>El equipo añadido</returns>
        public Equipment Add(Equipment equipment)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Permite editar un equipo
        /// </summary>
        /// <param name="equipment">equipo</param>    
        /// <returns>El equipo añadido</returns>
        public Equipment Update(Equipment equipment)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Permite eliminar un equipo
        /// </summary>
        /// <param name="equipmentId">identificador del equipo</param>     
        /// <returns>true o false por si se elimino correctamente</returns>
        public bool Delete(Guid equipmentId)
        {
            throw new NotImplementedException();
        }



    }
}
