﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsersByRole.aspx.cs" Inherits="Seguridad.Admin.Access.UsersByRole" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"> 
<table class="webparts">
<tr>
	<th align="left">Usuarios por Rol</th>
</tr>
<tr>
<td class="details" valign="top">

Filtros por rol:

<asp:DropDownList ID="UserRoles" runat="server" AppendDataBoundItems="true" AutoPostBack="true">
<asp:ListItem>Mostrar todos</asp:ListItem>
</asp:DropDownList>


<br /><br />

<asp:GridView runat="server" ID="Users" AutoGenerateColumns="false"
	CssClass="list" AlternatingRowStyle-CssClass="odd" GridLines="none"
	AllowSorting="true"
	>
<Columns>
	<asp:TemplateField>
		<HeaderTemplate>Nombre de usuario</HeaderTemplate>
		<ItemTemplate>
		<a href="edit_user.aspx?username=<%# Eval("UserName") %>"><%# Eval("UserName") %></a>
		</ItemTemplate>
	</asp:TemplateField>
	<asp:BoundField DataField="email" HeaderText="Email" />
	<asp:BoundField DataField="comment" HeaderText="Comentario" />
	<asp:BoundField DataField="creationdate" HeaderText="Fecha de creación" />
	<asp:BoundField DataField="lastlogindate" HeaderText="Fecha último acceso" />
	<asp:BoundField DataField="lastactivitydate" HeaderText="Fecha última actividad" />
	<asp:BoundField DataField="isapproved" HeaderText="Activo" />
	<asp:BoundField DataField="isonline" HeaderText="Online" />
	<asp:BoundField DataField="islockedout" HeaderText="Bloqueado" />
</Columns>
</asp:GridView>

</td></tr></table>

</asp:Content>
