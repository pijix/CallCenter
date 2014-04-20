<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IncidenceList.aspx.cs" Inherits="CallCenter.Web.App.User.IncidencetList" %>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
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
                <td><asp:Button ID="edit" runat="server" PostBackUrl='<%# Eval("Id","IncidenceAddEdit.aspx?Id={0}") %>' Text="Editar" CssClass="btn btn-info btn-xs"></asp:Button></td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
