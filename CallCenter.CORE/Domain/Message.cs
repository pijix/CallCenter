using System;
using System.Web.Security;

namespace CallCenter.CORE.Domain
{
    public class Message
    {
        /// <summary>
        /// Identificador único del mensaje
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Identificador del usuario que crea o responde el mensaje
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Nombre del usuario que redacta el mensaje
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Incidencia relacionada con el mensaje
        /// </summary>
        public Guid IncidenceId { get; set; }

        /// <summary>
        /// Texto del mensaje
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Fecha de creación del mensaje
        /// </summary>
        public DateTime CreatedDate { get; set; }

    }
}
