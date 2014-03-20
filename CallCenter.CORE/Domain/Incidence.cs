using System;
using System.Collections.Generic;
using CallCenter.CORE.Domain.Enums;

namespace CallCenter.CORE.Domain
{
    public class Incidence
    {
        /// <summary>
        /// Identificador único de la incidencia
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Identificador del usuario que ha creado la incidencia
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Título de la Incidencia
        /// </summary>
        public string IncidenceTitle { get; set; }

        /// <summary>
        /// Fecha de creacion de la incidencia
        /// </summary>
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// Prioridad de la incidencia
        /// </summary>
        public  EnumIncidencePriority Priority { get; set; }

        /// <summary>
        /// Equipo al que se refiere la incidencia
        /// </summary>
        public Equipment Equipment { get; set; }

        /// <summary>
        /// Estado en el que se encuentra la incidencia
        /// </summary>
        public EnumIncidenceStatus Status { get; set; }

        /// <summary>
        /// Lista de mensajes que tiene la incidencia
        /// </summary>
        public ICollection<Message> Messages { get; set; }
    }
}
