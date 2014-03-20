<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListIncidence.aspx.cs" Inherits="CallCenter.Web.App.User.ListClient" %>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="ListView1" runat="server">
        <LayoutTemplate>
            <table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Surname</th>
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
                <td><asp:Literal ID="Surname" runat="server" Text='<%# Eval("Surname") %>'></asp:Literal></td>
                <td><asp:HyperLink ID="edit" runat="server" NavigateUrl='<%# Eval("Id","PeopleNewEdit.aspx?Id={0}") %>' Text="Editar"></asp:HyperLink></td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
