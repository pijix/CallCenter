using System;
using System.Collections.Generic;

namespace CallCenter.CORE.Domain
{
    public class Client
    {
        /// <summary>
        /// Identificador único del cliente
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nombre del Cliente
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Mail del Cliente
        /// </summary>
        public string Mail { get; set; }

        /// <summary>
        /// Equipos que tiene un cliente
        /// </summary>
        public ICollection<Equipment> Equipments { get; set; }
    }
}
