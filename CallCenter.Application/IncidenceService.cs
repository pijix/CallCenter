﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CallCenter.CORE.Domain;
using CallCenter.CORE.Domain.Enums;
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
        public IQueryable<Incidence> GetAll()
        {
            return _dbContext.Incidences.Include(a => a.Equipment);
        }

        /// <summary>
        /// Método que retorna una incidencia
        /// </summary>
        /// <param name="incidenceId">identificador del usuario</param>
        /// <returns>Una incidencia</returns>
        public Incidence GetById(Guid incidenceId)
        {
            return _dbContext.Incidences.FirstOrDefault(i=>i.Id == incidenceId);
        }

        /// <summary>
        /// Método que retorna una lista de incidencias por usuario
        /// </summary>
        /// <param name="userId">identificador del usuario</param>
        /// <returns>Lista de incidencias</returns>
        public IQueryable<Incidence> GetByUserId(Guid userId)
        {
            return _dbContext.Incidences.Select(a=>a).Where(u=>u.UserId == userId);
        }

        /// <summary>
        /// Método que retorna una lista de incidencias por equipo
        /// </summary>
        /// <param name="equipmentId">identificador del equipo</param>
        /// <returns>Lista de incidencias</returns>
        public IQueryable<Incidence> GetByEquipment(Guid equipmentId)
        {
            return _dbContext.Incidences.Select(a => a).Where(e => e.Equipment.Id == equipmentId);
        }

       
        /// <summary>
        /// Permite añdir una Incidencia
        /// </summary>
        /// <param name="incidence">entidad incidence</param>       
        /// <returns>La incidencia añadida</returns>
        public Incidence Add(Incidence incidence)
        {
            try
            {
                var newClient = _dbContext.Incidences.Add(incidence);
                _dbContext.SaveChanges();
                return newClient;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al añadir la Incidencia: " + ex.InnerException.Message);
            }
        }


        /// <summary>
        /// Permite editar una Incidencia
        /// </summary>
        /// <param name="incidence">entidad</param>    
        /// <returns>La incidencia editada</returns>
        public Incidence Update(Incidence incidence)
        {
            try
            {
                var editIncidence = _dbContext.Incidences.FirstOrDefault(i => i.Id == incidence.Id);
                if(editIncidence == null) throw new Exception("Incidencia no encontrada");
                editIncidence.IncidenceTitle = incidence.IncidenceTitle;
                editIncidence.Equipment = incidence.Equipment;
                editIncidence.Priority = incidence.Priority;
                editIncidence.Status = incidence.Status;
                editIncidence.UserId = incidence.UserId;
                editIncidence.UserName = incidence.UserName;
                _dbContext.SaveChanges();
                return editIncidence;
            }

            catch (Exception ex)
            {              
                throw new Exception("Error al Editar la Incidencia: " + ex.InnerException.Message);
            }
        
        }

        /// <summary>
        /// Permite eliminar una Incidencia
        /// </summary>
        /// <param name="incidenceId">identificador de la incidencia</param>     
        /// <returns>true o false por si se elimino correctamente</returns>
        public bool Delete(Guid incidenceId)
        {
            try
            {
                var exists = _dbContext.Incidences.FirstOrDefault(i => i.Id == incidenceId);
                if(exists == null ) throw new Exception("La Incidencia a eliminar no Existe");
                _dbContext.Incidences.Remove(exists);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Eliminar la Incidencia: " + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Retorna incidencias agrupadas por usuario, mas de 2
        /// </summary>
        /// <returns>Objeto con Usuario y Total Incidencias</returns>
        public Object TotalIncidencesByUser()
        {
            try
            {
                return _dbContext.Incidences.Where(a=>a.Status != EnumIncidenceStatus.Cerrada).GroupBy(a => a.UserId).Where(a => a.Count()>2).Select(a => new { a.FirstOrDefault().UserName, IncidencesCount = a.Count()}).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al calular incidencias: " + ex.Message);
            }
        }

        /// <summary>
        /// Retorna incidencias agrupadas por equipo, mas de 2
        /// </summary>
        /// <returns>Objeto con Equipo y Total Incidencias</returns>
        public Object TotalIncidencesByEquipment()
        {
            try
            {
                return _dbContext.Incidences.Where(a=>a.Status != EnumIncidenceStatus.Cerrada).GroupBy(a=>a.Equipment.Id).Where(a => a.Count()>2).Select(a => new { EquipmentName = a.FirstOrDefault().Equipment.Name, IncidencesCount = a.Count() }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al calular incidencias: " + ex.InnerException.Message);
            }
        }
    }
}
