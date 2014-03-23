using System;
using System.Web.Security;
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
    public partial class IncidenceAddEdit : Page
    {

        private DBContext _dbContext;
        private IncidenceService _service;
        private EquipmentService _equipmentService;
        private Guid _userId;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            _dbContext = new DBContext();
            _service = new IncidenceService(_dbContext);
            _equipmentService = new EquipmentService(_dbContext);

            // Recuperamos el id de Usuario
            //Cogemos la información del usuario actual, en userId cogeremos su id o un guid vacio si no esta logueado
            var user = Membership.GetUser();
            if (user != null && user.ProviderUserKey != null)
                _userId = (Guid)user.ProviderUserKey;
            else
                _userId = Guid.Empty;

            // Si es PostBack no hacemos nada, solo quando carga la página
            if (Page.IsPostBack) return;

            // Activamos los botones, por defecto estado Add
            Add.Visible = true;
            Update.Visible = false;
            Remove.Visible = true;
            
            // Carga los Equipos en el combo
            LoadListsData();
            
            // Miramos si Editamos (Pasamos Id por GET) o bien Añadimos una incidencia
            var incidenceId = Request.QueryString["Id"];

            if (string.IsNullOrWhiteSpace(incidenceId)) return;
            
            // EDITAMOS
            var incidence = _service.GetById(new Guid(incidenceId));
            if (incidence != null)
            {
                Add.Visible = false;
                Update.Visible = true;   

                // Llenamos los campos con la info de la Incidencia
                txtId.Value = incidenceId;
                txtTitle.Text = incidence.IncidenceTitle;
                cmbPriority.SelectedValue = incidence.Priority.ToString();
                cmbStatus.SelectedValue = incidence.Status.ToString();
                cmbEquipment.SelectedValue = incidence.Equipment != null ? incidence.Equipment.Id.ToString() : "";
            }
            else
            {
                lblResult.Text = "Incidencia no encontrada para editar";
            }
        }

        protected void AddIncidence(object sender, EventArgs e)
        {
            try
            {
              
                var newIncidence = new Incidence
                {
                    Id = Guid.NewGuid(),
                    UserId = _userId,
                    DateCreation = DateTime.Today.Date,
                    IncidenceTitle = txtTitle.Text,
                    Priority = (EnumIncidencePriority)Enum.Parse(typeof(EnumIncidencePriority), cmbPriority.SelectedItem.Text),
                    Status = (EnumIncidenceStatus)Enum.Parse(typeof(EnumIncidenceStatus), cmbStatus.SelectedItem.Text)
                };
                

                var equipment = _equipmentService.GetById(new Guid(cmbEquipment.SelectedValue));
                if (equipment != null)
                    newIncidence.Equipment = equipment;
                
                _service.Add(newIncidence);
                _dbContext.SaveChanges();
                Response.Redirect("IncidenceList.aspx");
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
            }            
        }

        protected void UpdateIncidence(object sender, EventArgs e)
        {
            try
            {

                var exists = _service.GetById(new Guid(txtId.Value));
                if(exists == null) throw new Exception("Incidencia no encontrada, no puede editarse");
                exists.IncidenceTitle = txtTitle.Text;
                exists.Priority = (EnumIncidencePriority) Enum.Parse(typeof (EnumIncidencePriority), cmbPriority.SelectedItem.Text);
                exists.Status = (EnumIncidenceStatus) Enum.Parse(typeof (EnumIncidenceStatus), cmbStatus.SelectedItem.Text);
                
                var equipment = _equipmentService.GetById(new Guid(cmbEquipment.SelectedValue));
                if (equipment != null)
                    exists.Equipment = equipment;

                _dbContext.SaveChanges();
                Response.Redirect("IncidenceList.aspx");
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
            }
        }

        protected void DelteIncidence(object sender, EventArgs e)
        {
            try
            {
                if(_service.Delete(new Guid(txtId.ToString())))
                    throw new Exception("No ha sido posible borrar la Incidencia");
                
                _dbContext.SaveChanges();
                Response.Redirect("EquipmentList.aspx");
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
            }

        }

        private void LoadListsData()
        {

            // cargamos la info de los equipos
            var equipments = _equipmentService.GetAll();
            foreach (var equipment in equipments)
            {
                var li = new ListItem(equipment.Name, equipment.Id.ToString());
                cmbEquipment.Items.Add(li);
            }

            // cargamos info de prioridad
            cmbPriority.Items.Add(EnumIncidencePriority.Baja.ToString());
            cmbPriority.Items.Add(EnumIncidencePriority.Normal.ToString());
            cmbPriority.Items.Add(EnumIncidencePriority.Urgente.ToString());
            cmbPriority.Items.Add(EnumIncidencePriority.Inmediata.ToString());
            
            // cargamos info de estado
            cmbStatus.Items.Add(EnumIncidenceStatus.Abierta.ToString());
            cmbStatus.Items.Add(EnumIncidenceStatus.EnProceso.ToString());
            cmbStatus.Items.Add(EnumIncidenceStatus.Cerrada.ToString());
        }

    }
}