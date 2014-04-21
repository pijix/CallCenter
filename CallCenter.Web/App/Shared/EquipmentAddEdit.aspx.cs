using System;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Windows.Forms;
using CallCenter.Application;
using CallCenter.CORE.Domain;
using CallCenter.CORE.Domain.Enums;
using CallCenter.DAL;

namespace CallCenter.Web.App.Shared
{
    public partial class EquipmentAddEddit : System.Web.UI.Page
    {

        private DBContext _dbContext;
        private EquipmentService _service;

        protected void Page_Load(object sender, EventArgs e)
        {
            _dbContext = new DBContext();
            _service = new EquipmentService(_dbContext);

            // Si es PostBack no hacemos nada, solo quando carga la página
            if (Page.IsPostBack) return;

            // Activamos los botones, por defecto estado Add
            Add.Visible = true;
            Update.Visible = false;
            Remove.Visible = false;
            Cancel.Visible = true;
            
            // Miramos si Editamos (Pasamos Id por GET) o bien Añadimos una incidencia
            var equipmentId = Request.QueryString["Id"];

            // AÑADIR - no hace falta hacer nada
            if (string.IsNullOrWhiteSpace(equipmentId)) return;

            // EDITA
            var equipment = _service.GetById(new Guid(equipmentId));
            if (equipment != null)
            {
                Add.Visible = false;
                Update.Visible = true;
                Remove.Visible = true;
                Cancel.Visible = true;

                // Llenamos los campos con la info de la Incidencia
                txtId.Value = equipmentId;
                txtName.Text = equipment.Name;
                txtDescription.Text = equipment.Description;
            }
            else
            {
                lblResult.Text = "No se ha encontrado el registro para editar";
                lblResult.Visible = true;
            }
        }

        protected void AddEquipment(object sender, EventArgs e)
        {
            try
            {
                var newEquipment = new Equipment
                {
                    Id = Guid.NewGuid(),
                    Name = txtName.Text,
                    Description = txtDescription.Text
                };

                _service.Add(newEquipment);
                // Una vez insertado el registro redirigimos al listado
                Response.Redirect("EquipmentList.aspx");
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
                lblResult.Visible = true;
            }            
        }

        protected void UpdateEquipment(object sender, EventArgs e)
        {
            try
            {
                var equipment = new Equipment
                {
                    Id = new Guid(txtId.Value),
                    Name = txtName.Text,
                    Description = txtDescription.Text
                };
                _service.Update(equipment);
                // Una vez editado el registro redirigimos al listado
                Response.Redirect("EquipmentList.aspx");
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
                lblResult.Visible = true;
            }
        }

        protected void DeleteEquipment(object sender, EventArgs e)
        {
            try
            {
                if (_service.Delete(new Guid(txtId.Value)))
                    // Una vez insertado el registro redirigimos al listado
                    Response.Redirect("EquipmentList.aspx");
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
                lblResult.Visible = true;
            }
        }

    }
}