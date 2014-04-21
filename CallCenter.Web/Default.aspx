<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CallCenter.Web.Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
 
    <!-- Lista de Incidencias -->
    <div class="row">
        <div class="col-lg-12">
            <h3 class="text-info">Listado Incidencias</h3>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-3">
            <!-- caja de texto busqueda -->
            <div class="form-group">
              <div class="input-group">
                  <asp:TextBox runat="server" CssClass="form-control" ID="txtBuscar"></asp:TextBox>
                <span class="input-group-btn">
                    <asp:Button runat="server" CssClass="btn btn-default" ID="btnBuscar" Text="Buscar" OnClick="SearchIncidences"/>
                </span>
              </div>
            </div>
        </div>
        <div class="col-lg-4 col-lg-offset-5 pull-right">
              <div class="btn-group pull-right">
                  <asp:Button runat="server" CssClass="btn btn-info btn-sm" Text="Activas" ID="btnFilterIncidences" OnClick="LoadAllIncidences"/>
                  <asp:Button runat="server" CssClass="btn btn-info btn-sm" Text="Todas" ID="btnAllIncidences" OnClick="LoadFilterIncidences"/>
              </div>        
        </div>
    </div>
    
    <div class="row">
        <div class="col-lg-12">
        <asp:ListView ID="ListIncidence" runat="server">
        <LayoutTemplate>
            <table class="table table-striped table-hover">
                <thead>
                    <tr>
                        <th>Fecha Creación</th>                       
                        <th>Título</th>
                        <th>Estado</th>
                        <th>Usuario</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                </tbody>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr> 
                <td><asp:Literal ID="FechaCreacion" runat="server" Text='<%# Eval("DateCreation") %>'></asp:Literal></td>
                 <td><asp:Literal ID="Titulo" runat="server" Text='<%# Eval("IncidenceTitle") %>'></asp:Literal></td>
                <td><asp:Literal ID="Estado" runat="server" Text='<%# Eval("Status") %>'></asp:Literal></td>
                <td><asp:Literal ID="Literal1" runat="server" Text='<%# Eval("UserName") %>'></asp:Literal></td>

            </tr>
        </ItemTemplate>
    </asp:ListView>
            </div>
    </div>
    </asp:Content>
