using System;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using CallCenter.Application;
using CallCenter.DAL;

namespace CallCenter.Web.App.Shared
{
    public partial class EquipmentList : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Se crea el contexto y el servicio de datos
            var dbcontext = new DBContext();
            var equipmentService = new EquipmentService(dbcontext);

            //Cogemos la información del usuario actual, en userId cogeremos su id o un guid vacio si no esta logueado
            var user = Membership.GetUser();
            Guid userId;
            if (user != null && user.ProviderUserKey != null)
                userId = (Guid) user.ProviderUserKey;
            else
                userId = Guid.Empty;

            // Consultamos todas las incidencias y las mostramos por pantalla ordenadas               
            ListEquipment.DataSource = equipmentService.GetAll().OrderBy(o=>o.Name).ToList();
            ListEquipment.DataBind();

        }
    }
}