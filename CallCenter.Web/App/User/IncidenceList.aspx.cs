using System;
using System.Linq;
using System.Web.Security;
using CallCenter.Application;
using CallCenter.DAL;

namespace CallCenter.Web.App.User
{
    public partial class IncidencetList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Se crea el contexto y el servicio de datos
            var dbcontext = new DBContext();
            var incidenceService = new IncidenceService(dbcontext);

            // Cogemos el Id del usuario actual, si no está logeado sera vacio
            var user = Membership.GetUser();
            Guid userId;
            if (user != null && user.ProviderUserKey != null)
                userId = (Guid) user.ProviderUserKey;
            else
                userId = Guid.Empty;

            // Consultamos todas las incidencias y las mostramos por pantalla ordenadas               
            ListIncidence.DataSource = incidenceService.GetByUserId(userId).OrderBy(a=>a.Priority).ThenBy(a=>a.DateCreation);
            ListIncidence.DataBind();

        }
    }
}