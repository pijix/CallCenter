using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CallCenter.CORE.Domain
{
    public class Equipment
    {
        /// <summary>
        /// Identificador único del equipo
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nombre del equipo
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descripción del tipo de equipo
        /// </summary>
        public string Description { get; set; }


    }
}
