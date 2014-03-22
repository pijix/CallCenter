<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IncidenceAddEdit.aspx.cs" Inherits="CallCenter.Web.App.User.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <table style="width: 100%;">
        <tr>
            <td style="width: 25%;">&nbsp;</td>
            <td>Título:</td>
            <td><asp:TextBox ID="txtTitle" runat="server"></asp:TextBox></td>            
            <td style="width: 25%;">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 25%;">&nbsp;</td>
            <td>Prioridad:</td>
            <td><asp:TextBox ID="txtPriority" runat="server"></asp:TextBox></td>            
            <td style="width: 25%;">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 25%;">&nbsp;</td>
            <td>Estado:</td>
            <td><asp:TextBox ID="txtStatus" runat="server"></asp:TextBox></td>            
            <td style="width: 25%;">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 25%;">&nbsp;</td>
            <td>Equipo:</td>
            <td><asp:TextBox ID="txtEquipment" runat="server"></asp:TextBox></td>            
            <td style="width: 25%;">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="2">
                <asp:HyperLink Visible="false" ID="HyperLink1" runat="server" NavigateUrl="TelephoneNewEdit.aspx" Text="Nuevo número" />
                <asp:ListView ID="ListView1" runat="server">
                    <LayoutTemplate>
                        <table>
                            <thead>
                                <tr>
                                    <th>Número</th>
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
                            <td><asp:Literal ID="Number" runat="server" Text='<%# Eval("Phone") %>'></asp:Literal></td>
                            <td><asp:HyperLink ID="edit" runat="server" NavigateUrl='<%# Eval("Id","TelephoneNewEdit.aspx?Id={0}") %>' Text="Editar"></asp:HyperLink></td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>                
            </td>            
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td><asp:HiddenField ID="txtId" runat="server" /><asp:Button ID="Add" runat="server" Text="Añadir" OnClick="AddIncidence" /><asp:Button ID="Update" runat="server" Text="Modificar" OnClick="UpdateIncidence" /><asp:Button ID="Remove" runat="server" Text="Eliminar" OnClick="DelteIncidence" /></td>            
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td><asp:Label ID="lblResult" runat="server" Text=""></asp:Label></td>            
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
