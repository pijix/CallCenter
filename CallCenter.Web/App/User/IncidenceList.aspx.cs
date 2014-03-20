using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CallCenter.Application;
using CallCenter.DAL;

namespace CallCenter.Web.App.User
{
    public partial class ListClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Se crea el contexto y el servicio de datos
            var dbcontext = new DBContext();
            var incidenceService = new IncidenceService(dbcontext);

            //Cogemos la información del usuario actual, en userId cogeremos su id o un guid vacio si no esta logueado
            /*var user = Membership.GetUser();
            var userId = user == null ? Guid.Empty : (Guid)user.ProviderUserKey;*/

            // Consultamos todas las incidencias y las mostramos por pantalla ordenadas               
            ListView1.DataSource = incidenceService.GetAll().OrderBy(i => i.Priority).ThenBy(i => i.DateCreation);
            ListView1.DataBind();
        }
    }
}