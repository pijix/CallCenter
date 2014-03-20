<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IncidenceList.aspx.cs" Inherits="CallCenter.Web.App.User.ListClient" %>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="ListView1" runat="server">
        <LayoutTemplate>
            <table>
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
                <td><asp:HyperLink ID="edit" runat="server" NavigateUrl='<%# Eval("Id","PeopleNewEdit.aspx?Id={0}") %>' Text="Editar"></asp:HyperLink></td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
