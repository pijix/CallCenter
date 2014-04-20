<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EquipmentList.aspx.cs" Inherits="CallCenter.Web.App.Shared.EquipmentList" %>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button runat="server" PostBackUrl="~/App/Shared/EquipmentAddEdit.aspx" Text="Añadir Equipo" CssClass="btn btn-info"></asp:Button>
    <asp:ListView ID="ListEquipment" runat="server">
        <LayoutTemplate>
            <table class="table table-striped table-hover">
                <thead>
                    <tr>
                        <th>Nombre</th>
                        <th>Descripción</th>
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
                <td><asp:Literal ID="Name" runat="server" Text='<%# Eval("Name") %>'></asp:Literal></td>
                <td><asp:Literal ID="Description" runat="server" Text='<%# Eval("Description") %>'></asp:Literal></td>
                <td><asp:Button ID="edit" runat="server" PostBackUrl='<%# Eval("Id","EquipmentAddEdit.aspx?Id={0}") %>' Text="Editar" CssClass="btn btn-info btn-xs"></asp:Button></td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
