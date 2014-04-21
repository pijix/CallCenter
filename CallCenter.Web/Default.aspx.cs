using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CallCenter.Application;
using CallCenter.CORE.Domain;
using CallCenter.CORE.Domain.Enums;
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




            if (!Page.IsPostBack)
            {
                LoadIncidences();
            }
        }


        protected void LoadFilterIncidences(object sender, EventArgs e)
        {
            LoadIncidences(false);

        }

        protected void LoadAllIncidences(object sender, EventArgs e)
        {
            LoadIncidences();
        }

        private void LoadIncidences(bool onlyActive = true)
        {
            // Carga todas las incidencias, teniendo en cuenta su estado
            var queryIncidences = _incidenceService.GetAll().ToList();
            if (onlyActive)
                queryIncidences = queryIncidences.Where(a => a.Status != EnumIncidenceStatus.Cerrada).ToList();
            ListIncidence.DataSource = queryIncidences.OrderBy(a => a.Priority).ThenBy(a => a.DateCreation);
            ListIncidence.DataBind();
        }

        protected void SearchIncidences(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text)) return;

            var t = txtBuscar.Text;
            ListIncidence.DataSource = _incidenceService.GetAll()
                .Where(a =>  a.Equipment.Name.ToUpper().Contains(t.ToUpper()) || a.UserName.Contains(t) || a.IncidenceTitle.Contains(t));
            ListIncidence.DataBind();
        }
    }
}