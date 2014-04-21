<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CallCenter.Web.Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
   
    <!-- Control Avisos por Usuario i Equipo -->
    <div class="row">
        <div class="col-lg-6">
        <p class="label label-danger">Usuarios con Incidencias Acumuladas</p>
                        <asp:ListView ID="UserTotalIncidences" runat="server">
                <LayoutTemplate>
                   <ul class="list-group">
                            <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                   </ul>
                </LayoutTemplate>
                <ItemTemplate>
                     <li class="list-group-item">
                         <span class="badge"><asp:Literal ID="TotalUserIncidence" runat="server" Text='<%# Eval("IncidencesCount") %>'/></span>
                         <asp:Literal ID="IncidenceUserName" runat="server" Text='<%# Eval("UserName") %>'/>
                    </li>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div class="col-lg-6">
        <p class="label label-danger">Equipos con Incidencias Acumuladas</p>
            <asp:ListView ID="EquipmentTotalIncidences" runat="server">
                <LayoutTemplate>
                   <ul class="list-group">
                            <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                   </ul>
                </LayoutTemplate>
                <ItemTemplate>
                     <li class="list-group-item">
                         <span class="badge"><asp:Literal ID="TotalUserIncidence" runat="server" Text='<%# Eval("IncidencesCount") %>'/></span>
                         <asp:Literal ID="IncidenceUserName" runat="server" Text='<%# Eval("EquipmentName") %>'/>
                    </li>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
     
    
    <!-- Lista de Incidencias -->
        <h4 class="alert alert-info">Listado Incidencias</h4>
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
    </asp:Content>
