<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IncidenceAddEdit.aspx.cs" Inherits="CallCenter.Web.App.User.IncidenceAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Mensaje de Error -->
<div id="mensaje-error" style="overflow: hidden; margin:10px 0; padding:15px 0">
    <asp:Label ID="lblResult" runat="server" Text="" CssClass="alert alert-danger" Visible="False">Atención: </asp:Label>
</div>
<!-- Formulario y Mensajes -->
<div class="well form-horizontal">
  <fieldset>
      <legend>Incidencia</legend>
    <div class="form-group">
      <label  class="col-lg-2 control-label">Título</label>
      <div class="col-lg-10">
         <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox><br/>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Es obligatorio informar el título" CssClass="text-danger" ControlToValidate="txtTitle" Display="Dynamic"></asp:RequiredFieldValidator>
      </div>
    </div>
    <div class="form-group">
      <label class="col-lg-2 control-label">Prioridad</label>
      <div class="col-lg-10">
           <asp:DropDownList ID="cmbPriority" runat="server" CssClass="form-control">
           </asp:DropDownList>
      </div>
    </div>
    <div class="form-group">
      <label class="col-lg-2 control-label">Estado</label>
      <div class="col-lg-10">
        <asp:DropDownList ID="cmbStatus" runat="server" CssClass="form-control">
        </asp:DropDownList>
      </div>
    </div>
    <div class="form-group">
      <label class="col-lg-2 control-label">Equipo</label>
      <div class="col-lg-10">
        <asp:DropDownList ID="cmbEquipment" runat="server" CssClass="form-control">
        </asp:DropDownList>
      </div>
    </div>
    <div class="form-group">
      <div class="col-lg-10 col-lg-offset-2">
        <asp:HiddenField ID="guidIncidence" runat="server" />
        <asp:Button ID="Add" runat="server" Text="Añadir" OnClick="AddIncidence" CssClass="btn btn-success" />
        <asp:Button ID="Update" runat="server" Text="Modificar" OnClick="UpdateIncidence" CssClass="btn btn-success"/>
        <asp:Button ID="Remove" runat="server" Text="Eliminar" OnClick="DelteIncidence" CssClass="btn btn-danger"/>
        <asp:Button ID="CancelActions" runat="server" Text="Cancelar" PostBackUrl="IncidenceList.aspx"  CausesValidation="False" CssClass="btn btn-primary"/>
      </div>
    </div>
  </fieldset>
</div>    
    
    
    <div class="form-group">
      <h4><asp:Label runat="server" ID="lblMessage">Mensajes</asp:Label></h4>
      <div class="input-group">
        <asp:TextBox runat="server" ID="txtMessage" CssClass="form-control" Rows="3"></asp:TextBox>
        <span class="input-group-btn">
        <asp:Button ID="AddMessage" runat="server" Text="Añadir" OnClick="AddNewMessage" CssClass="btn btn-success" />
        </span>
      </div>
    </div>
    
    <asp:ListView ID="ListMessages" runat="server">
        <LayoutTemplate>
            <div class="list-group">
                     <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="list-group-item">
                <h4 class="list-group-item-heading"><strong><asp:Literal ID="User" runat="server" Text='<%# Eval("UserName") %>'/></strong> | <span class="h6"><asp:Literal ID="MessageDate" runat="server" Text='<%# Eval("CreatedDate") %>'></asp:Literal><span></span></h4>
                <p class="list-group-item-text"><asp:Literal ID="MessageText" runat="server" Text='<%# Eval("Text") %>'></asp:Literal></p>
            </div>
        </ItemTemplate>
    </asp:ListView> 

</asp:Content>
