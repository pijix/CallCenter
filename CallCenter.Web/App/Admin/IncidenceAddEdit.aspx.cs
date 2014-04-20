using System;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CallCenter.Application;
using CallCenter.CORE.Domain;
using CallCenter.CORE.Domain.Enums;
using CallCenter.DAL;

namespace CallCenter.Web.App.Admin
{
    public partial class IncidenceAddEdit : Page
    {

        private DBContext _dbContext;
        private IncidenceService _service;
        private EquipmentService _equipmentService;
        private MessageService _messageService;
        private Guid _userId;

        protected void Page_Load(object sender, EventArgs e)
        {
            _dbContext = new DBContext();
            _service = new IncidenceService(_dbContext);
            _equipmentService = new EquipmentService(_dbContext);
            _messageService = new MessageService(_dbContext);

            // Recuperamos el id de Usuario
            //Cogemos la información del usuario actual, en userId cogeremos su id o un guid vacio si no esta logueado
            var user = Membership.GetUser();
            if (user != null && user.ProviderUserKey != null)
                _userId = (Guid)user.ProviderUserKey;
            else
                _userId = Guid.Empty;

            // Si es PostBack no hacemos nada, solo quando carga la página
            if (Page.IsPostBack) return;

            // Activamos los controles, por defecto estado Add
            Add.Visible = true;
            Update.Visible = false;
            Remove.Visible = false;
            lblResult.Visible = false;
            txtMessage.Visible = false;
            AddMessage.Visible = false;
            lblMessage.Visible = false;
            // Carga los Equipos en el combo
            LoadListsData();
            // Carga los Usuarios en el combo
            LoadListUsers();

            // Miramos si Editamos (Pasamos Id por GET) o bien Añadimos una incidencia
            var incidenceId = Request.QueryString["Id"];

            if (string.IsNullOrWhiteSpace(incidenceId)) return;

            // EDITAMOS                     
            var incidence = _service.GetById(new Guid(incidenceId));
            if (incidence != null)
            {
                // Activamos controles en modo edicion
                Add.Visible = false;
                Update.Visible = true;
                Remove.Visible = true;
                txtMessage.Visible = true;
                AddMessage.Visible = true;
                lblMessage.Visible = true;

                // Llenamos los campos con la info de la Incidencia
                guidIncidence.Value = incidenceId;
                txtTitle.Text = incidence.IncidenceTitle;
                cmbPriority.SelectedValue = incidence.Priority.ToString();
                cmbStatus.SelectedValue = incidence.Status.ToString();
                cmbEquipment.SelectedValue = incidence.Equipment != null ? incidence.Equipment.Id.ToString() : "";
                cmdUsuario.SelectedValue = incidence.UserId.ToString();
                // Muestra los mensajes de la Incidencia
                LoadMessageList();
            }
            else
            {
                lblResult.Text = "Incidencia no encontrada para editar";
                lblResult.Visible = true;
            }
        }

        protected void AddIncidence(object sender, EventArgs e)
        {
            try
            {

                var newIncidence = new Incidence
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid(cmdUsuario.SelectedValue),
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
                Response.Redirect("~/App/Admin/IncidenceList.aspx");
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
                lblResult.Visible = true;
            }
        }

        protected void UpdateIncidence(object sender, EventArgs e)
        {
            try
            {

                var exists = _service.GetById(new Guid(guidIncidence.Value));
                if (exists == null) throw new Exception("Incidencia no encontrada, no puede editarse");
                exists.IncidenceTitle = txtTitle.Text;
                exists.Priority = (EnumIncidencePriority)Enum.Parse(typeof(EnumIncidencePriority), cmbPriority.SelectedItem.Text);
                exists.Status = (EnumIncidenceStatus)Enum.Parse(typeof(EnumIncidenceStatus), cmbStatus.SelectedItem.Text);
                exists.UserId = new Guid(cmdUsuario.SelectedValue);

                var equipment = _equipmentService.GetById(new Guid(cmbEquipment.SelectedValue));
                if (equipment != null)
                    exists.Equipment = equipment;

                _dbContext.SaveChanges();
                Response.Redirect("~/App/Admin/IncidenceList.aspx");
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
                lblResult.Visible = true;
            }
        }

        protected void DelteIncidence(object sender, EventArgs e)
        {
            try
            {
                if (_service.Delete(new Guid(guidIncidence.ToString())))
                    throw new Exception("No ha sido posible borrar la Incidencia");

                _dbContext.SaveChanges();
                Response.Redirect("~/App/Admin/EquipmentList.aspx");
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
                lblResult.Visible = true;
            }

        }
        private void LoadListUsers()
        {
            var users = Membership.GetAllUsers();
            foreach (MembershipUser user in users)
            {
                if (user.ProviderUserKey == null) continue;
                var li = new ListItem(user.UserName, user.ProviderUserKey.ToString());
                cmdUsuario.Items.Add(li);
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

        private void LoadMessageList()
        {
            try
            {
                var messagesList = _messageService.GetByIncidence(new Guid(guidIncidence.Value)).OrderByDescending(a => a.CreatedDate).ToList();
                ListMessages.DataSource = messagesList;
                ListMessages.DataBind();
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
                lblResult.Visible = true;
            }

        }

        protected void AddNewMessage(object sender, EventArgs e)
        {
            var currentUser = Membership.GetUser();

            if (string.IsNullOrWhiteSpace(txtMessage.Text) || string.IsNullOrWhiteSpace(guidIncidence.Value)
                || currentUser == null || currentUser.ProviderUserKey == null) return;

            try
            {
                var newMessage = new Message
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    Text = txtMessage.Text,
                    IncidenceId = new Guid(guidIncidence.Value),
                    UserId = new Guid(currentUser.ProviderUserKey.ToString()),
                    UserName = currentUser.UserName
                };

                _messageService.Add(newMessage);
                LoadMessageList();
            }

            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
                lblResult.Visible = true;
            }

        }
    }

}