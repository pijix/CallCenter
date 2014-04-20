<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EquipmentAddEdit.aspx.cs" Inherits="CallCenter.Web.App.Shared.EquipmentAddEddit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<!-- Mensaje de Error -->
<div id="mensaje-error" style="overflow: hidden; margin:10px 0; padding:15px 0">
    <asp:Label ID="lblResult" runat="server" Text="" CssClass="alert alert-danger" Visible="False">Atención: </asp:Label>
</div>    
 
<!-- Formulario y Mensajes -->
<div class="well form-horizontal">
  <fieldset>
      <legend>Equipamiento</legend>
    <div class="form-group">
      <label  class="col-lg-2 control-label">Nombre</label>
      <div class="col-lg-10">
         <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="txtName" CssClass="help-block text-danger" SetFocusOnError="True"></asp:RequiredFieldValidator>
      </div>
    </div>
    <div class="form-group">
      <label class="col-lg-2 control-label">Descripción</label>
      <div class="col-lg-10">
         <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"></asp:TextBox><br/>
      </div>
    </div>
    <div class="form-group">
      <div class="col-lg-10 col-lg-offset-2">
        <asp:HiddenField ID="txtId" runat="server" />
        <asp:Button ID="Add" runat="server" Text="Añadir" OnClick="AddEquipment" CssClass="btn btn-success" />
        <asp:Button ID="Update" runat="server" Text="Modificar" OnClick="UpdateEquipment" CssClass="btn btn-success"/>
        <asp:Button ID="Remove" runat="server" Text="Eliminar" OnClick="DeleteEquipment" CssClass="btn btn-danger"/>
        <asp:Button ID="Cancel" runat="server" Text="Cancelar" PostBackUrl="~/App/Shared/EquipmentList.aspx"  CausesValidation="False" CssClass="btn btn-primary"/>
      </div>
    </div>
  </fieldset>
</div>    
</asp:Content>
