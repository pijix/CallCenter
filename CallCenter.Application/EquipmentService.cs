using System;
using System.Collections.Generic;
using System.Linq;
using CallCenter.CORE.Domain;
using CallCenter.DAL;

namespace CallCenter.Application
{
    public class EquipmentService
    {

        private readonly DBContext _dbContext;

        public EquipmentService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }


        /// <summary>
        /// Develve todos los equipos
        /// </summary>
        /// <returns>Lista de equipos</returns>
        public List<Equipment> GetAll()
        {
            return _dbContext.Equipments.ToList();
        }


        /// <summary>
        /// Devuelve un único equipo
        /// </summary>
        /// <param name="equipmentId">identificador del equipo</param>
        /// <returns>Equipo</returns>
        public Equipment GetById(Guid equipmentId)
        {
            return _dbContext.Equipments.FirstOrDefault(e => e.Id == equipmentId);
        }


        /// <summary>
        /// Permite añdir un equipo
        /// </summary>
        /// <param name="equipment">equipo</param> 
        /// <returns>El equipo añadido</returns>
        public Equipment Add(Equipment equipment)
        {
            try
            {
                var newEquipment = new Equipment
                {
                    Id = Guid.NewGuid(),
                    Name = equipment.Name,
                    Description = equipment.Description
                };
                _dbContext.Equipments.Add(newEquipment);
                _dbContext.SaveChanges();
                return new Equipment();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }


        /// <summary>
        /// Permite editar un equipo
        /// </summary>
        /// <param name="equipment">equipo</param>    
        /// <returns>El equipo añadido</returns>
        public Equipment Update(Equipment equipment)
        {
            try
            {
                var exists = _dbContext.Equipments.FirstOrDefault(e => e.Id == equipment.Id);
                // Si no encontramos el equpio para modificar, lanzamos una excepción...
                if (exists == null) throw new Exception("No se encontró el Equipo a Editar");
                // Editamos
                exists.Name = equipment.Name;
                exists.Description = equipment.Description;
                _dbContext.SaveChanges();
                return new Equipment();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Permite eliminar un equipo
        /// </summary>
        /// <param name="equipmentId">identificador del equipo</param>     
        /// <returns>true o false por si se elimino correctamente</returns>
        public bool Delete(Guid equipmentId)
        {
            var exists = _dbContext.Equipments.FirstOrDefault(e => e.Id == equipmentId);
            if(exists == null) throw new Exception("No se encontró el Equipo a Eliminar");
            _dbContext.Equipments.Remove(exists);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
