<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IncidenceAddEdit.aspx.cs" Inherits="CallCenter.Web.App.Admin.IncidenceAddEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <table style="width: 100%;">
        <tr>
            <td style="width: 25%; height: 64px;"></td>
            <td style="height: 64px">Título:</td>
            <td style="height: 64px">
                <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox><br/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Es obligatorio informar el título" ControlToValidate="txtTitle" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>            
            <td style="width: 25%; height: 64px;"></td>
        </tr>
          <tr>
            <td style="width: 25%;">&nbsp;</td>
            <td>Usuario:</td>
            <td>
                <asp:DropDownList ID="cmdUsuario" runat="server">
                </asp:DropDownList>
            </td>            
            <td style="width: 25%;">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 25%;">&nbsp;</td>
            <td>Prioridad:</td>
            <td>
                <asp:DropDownList ID="cmbPriority" runat="server">
                </asp:DropDownList>
            </td>            
            <td style="width: 25%;">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 25%;">&nbsp;</td>
            <td>Estado:</td>
            <td>
                <asp:DropDownList ID="cmbStatus" runat="server">
                </asp:DropDownList>
            </td>            
            <td style="width: 25%;">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 25%;">&nbsp;</td>
            <td>Equipo:
            <td>
                <asp:DropDownList ID="cmbEquipment" runat="server">
                </asp:DropDownList>
            </td>            
            <td style="width: 25%;">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="2">
                <td colspan="2">
                <asp:TextBox runat="server" ID="txtMessage"></asp:TextBox>
                <asp:Button ID="AddMessage" runat="server" Text="Añadir" OnClick="AddNewMessage" />
                <asp:ListView ID="ListMessages" runat="server">
        <LayoutTemplate>
            <table>
                <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><asp:Literal ID="User" runat="server" Text='<%# Eval("UserName") %>'></asp:Literal></td>
                <td><asp:Literal ID="MessageDate" runat="server" Text='<%# Eval("CreatedDate") %>'></asp:Literal></td>
                <td><asp:Literal ID="MessageText" runat="server" Text='<%# Eval("Text") %>'></asp:Literal></td>
            </tr>
        </ItemTemplate>
    </asp:ListView> 
            </td>            
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td><asp:HiddenField ID="guidIncidence" runat="server" />
                <asp:Button ID="Add" runat="server" Text="Añadir" OnClick="AddIncidence" />
                <asp:Button ID="Update" runat="server" Text="Modificar" OnClick="UpdateIncidence" />
                <asp:Button ID="Remove" runat="server" Text="Eliminar" OnClick="DelteIncidence" />
                <asp:Button ID="CancelActions" runat="server" Text="Cancelar" PostBackUrl="IncidenceList.aspx"  CausesValidation="False" />
            </td>            
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
