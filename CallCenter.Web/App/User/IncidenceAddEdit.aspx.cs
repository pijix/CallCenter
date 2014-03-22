using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using CallCenter.Application;
using CallCenter.CORE.Domain;
using CallCenter.CORE.Domain.Enums;
using CallCenter.DAL;

namespace CallCenter.Web.App.User
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        private DBContext _dbContext;
        private IncidenceService _service;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            _dbContext = new DBContext();
            _service = new IncidenceService(_dbContext);

            // Si es PostBack no hacemos nada, solo quando carga la página
            if (Page.IsPostBack) return;

            // Activamos los botones, por defecto estado Add
            Add.Visible = true;
            Update.Visible = false;
            Remove.Visible = true;
            
            // Miramos si Editamos (Pasamos Id por GET) o bien Añadimos una incidencia
            var incidenceId = Request.QueryString["Id"];
            
            if (!string.IsNullOrWhiteSpace(incidenceId))
            {
                // EDITAMOS
                var incidence = _service.GetById(new Guid(incidenceId));
                if (incidence != null)
                {
                    Add.Visible = false;
                    Update.Visible = true;   

                    // Llenamos los campos con la info de la Incidencia
                    txtTitle.Text = incidence.IncidenceTitle;
                    txtPriority.Text = incidence.Priority.ToString();
                    txtStatus.Text = incidence.Status.ToString();
                    txtEquipment.Text = incidence.Equipment != null ? incidence.Equipment.Description : "";
                }
                else
                {
                    //todo: Message no se encuetnra la incidenia
                }
            }
            else
            {
                //todo: añadimos
            }
            

        }

        protected void AddIncidence(object sender, EventArgs e)
        {
            try
            {
                var newIncidence = new Incidence
                {
                    Id = Guid.NewGuid(),
                    DateCreation = DateTime.Today.Date,
                    IncidenceTitle = txtTitle.Text,
                    Priority = EnumIncidencePriority.Normal,
                };

                _service.Add(newIncidence);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }            
        }

        protected void UpdateIncidence(object sender, EventArgs e)
        {
            try
            {
                var newIncidence = new Incidence
                {
                    Id = Guid.NewGuid(),
                    DateCreation = DateTime.Today.Date,
                    IncidenceTitle = txtTitle.Text,
                    Priority = EnumIncidencePriority.Normal,
                };

                _service.Add(newIncidence);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        protected void DelteIncidence(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}