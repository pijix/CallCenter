<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EquipmentAddEdit.aspx.cs" Inherits="CallCenter.Web.App.Shared.EquipmentAddEddit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <table style="width: 100%;">
        <tr>
            <td style="width: 25%;">&nbsp;</td>
            <td>Nombre:</td>
            <td><asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <br/><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="txtName" ForeColor="#CC0000" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>            
            <td style="width: 25%;">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 25%;">&nbsp;</td>
            <td>Descripción:</td>
            <td><asp:TextBox ID="txtDescription" runat="server"></asp:TextBox></td>            
            <td style="width: 25%;">&nbsp;</td>
        </tr>   
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td><asp:HiddenField ID="txtId" runat="server" />
                <asp:Button ID="Add" runat="server" Text="Añadir" OnClick="AddEquipment" />
                <asp:Button ID="Update" runat="server" Text="Modificar" OnClick="UpdateEquipment" />
                <asp:Button ID="Remove" runat="server" Text="Eliminar" OnClick="DeleteEquipment" />
                <asp:Button ID="Cancel" runat="server" Text="Cancelar" CausesValidation="False" PostBackUrl="~/App/Shared/EquipmentList.aspx" />
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
