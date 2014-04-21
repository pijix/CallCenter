<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IncidenceList.aspx.cs" Inherits="CallCenter.Web.App.Admin.IncidencetList" %>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
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
    
    <asp:Button runat="server" PostBackUrl="IncidenceAddEdit.aspx" Text="Añadir Incidencia" CssClass="btn btn-info"></asp:Button>
    <asp:ListView ID="ListIncidence" runat="server">
        <LayoutTemplate>
            <table class="table table-striped table-hover">
                <thead>
                    <tr>
                        <th>Título</th>
                        <th>Fecha Creacion</th>
                        <th>Estado</th>
                        <th>Prioridad</th>
                        <th>&nbsp;</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                </tbody>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><asp:Literal ID="Titulo" runat="server" Text='<%# Eval("IncidenceTitle") %>'></asp:Literal></td>
                <td><asp:Literal ID="FechaCreacion" runat="server" Text='<%# Eval("DateCreation") %>'></asp:Literal></td>
                <td><asp:Literal ID="Estado" runat="server" Text='<%# Eval("Status") %>'></asp:Literal></td>
                <td><asp:Literal ID="Prioridad" runat="server" Text='<%# Eval("Priority") %>'></asp:Literal></td>
                <td><asp:Literal ID="Equipo" runat="server" Text='<%# Eval("Equipment.Name") %>'></asp:Literal></td>
                <td><asp:Button ID="Edit" runat="server" PostBackUrl='<%# Eval("Id","IncidenceAddEdit.aspx?Id={0}") %>' Text="Editar" CssClass="btn btn-info btn-xs"></asp:Button></td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
