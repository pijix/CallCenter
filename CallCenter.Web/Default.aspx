<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CallCenter.Web._Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
        <asp:ListView ID="ListIncidence" runat="server">
        <LayoutTemplate>
            <table>
                <thead>
                    <tr>
                        <th>Título</th>
                        <th>Fecha Creacion</th>
                        <th>Estado</th>
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
            </tr>
        </ItemTemplate>
    </asp:ListView>
    </asp:Content>
