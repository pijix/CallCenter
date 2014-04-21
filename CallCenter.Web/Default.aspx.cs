using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CallCenter.Application;
using CallCenter.CORE.Domain;
using CallCenter.DAL;

namespace CallCenter.Web
{
    public partial class Default : Page
    {
        private DBContext _dbContext;
        private IncidenceService _incidenceService;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            // Se crea el contexto y el servicio de datos
            _dbContext = new DBContext();
            _incidenceService = new IncidenceService(_dbContext);

            // Consultamos todas las incidencias y las mostramos por pantalla ordenadas               
            ListIncidence.DataSource = _incidenceService.GetAll().OrderBy(a => a.Priority).ThenBy(a => a.DateCreation);
            ListIncidence.DataBind();

            // Consultamos el total de incidencias por usuario y Equipo, para avisar si se acumulan + de 3
            UserTotalIncidences.DataSource = _incidenceService.TotalIncidencesByUser();
            UserTotalIncidences.DataBind();
            
            EquipmentTotalIncidences.DataSource = _incidenceService.TotalIncidencesByEquipment();
            EquipmentTotalIncidences.DataBind();
        }

    }
}