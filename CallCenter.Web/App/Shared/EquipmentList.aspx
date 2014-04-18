<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EquipmentList.aspx.cs" Inherits="CallCenter.Web.App.Shared.EquipmentList" %>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:LinkButton runat="server" PostBackUrl="~/App/Shared/EquipmentAddEdit.aspx">Añadir Equipo</asp:LinkButton>
    <asp:ListView ID="ListEquipment" runat="server">
        <LayoutTemplate>
            <table>
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
                <td><asp:HyperLink ID="edit" runat="server" NavigateUrl='<%# Eval("Id","EquipmentAddEdit.aspx?Id={0}") %>' Text="Editar"></asp:HyperLink></td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
