using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CallCenter.Application;
using CallCenter.DAL;

namespace CallCenter.Web
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            // Se crea el contexto y el servicio de datos
            var dbcontext = new DBContext();
            var incidenceService = new IncidenceService(dbcontext);

            // Consultamos todas las incidencias y las mostramos por pantalla ordenadas               
            ListIncidence.DataSource = incidenceService.GetAll().OrderBy(a => a.Priority).ThenBy(a => a.DateCreation);
            ListIncidence.DataBind();

        }
    }
}