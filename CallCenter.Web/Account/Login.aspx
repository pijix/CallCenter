<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CallCenter.Web.Account.Login" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="col-lg-4 col-lg-offset-4">
    <section id="loginForm">
        <asp:Login runat="server" ViewStateMode="Disabled" RenderOuterTable="false">
            <LayoutTemplate>
                <p class="validation-summary-errors">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
                <fieldset>
                    <legend>Formulario de Log in</legend>
<%--                            <asp:Label runat="server" AssociatedControlID="UserName">User name</asp:Label>--%>
                            <asp:TextBox runat="server" ID="UserName" CssClass="form-control" placeholder="Nombre de Usuario" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" CssClass="text-danger" ErrorMessage="El nombre de usuario es obligatorio." />

<%--                            <asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label>--%>
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" placeholder="Contrasenya" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="El campo de contraseña es obligatorio." />
                            <asp:Button runat="server" CommandName="Login" Text="Log in" CssClass="btn btn-lg btn-primary btn-block" />
                </fieldset>
            </LayoutTemplate>
        </asp:Login>
<%--        <p>
            <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register</asp:HyperLink>
            if you don't have an account.
        </p>--%>
    </section>
    </div>
<%--    <section id="socialLoginForm">
        <h2>Use another service to log in.</h2>
        <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
    </section>--%>
</asp:Content>
