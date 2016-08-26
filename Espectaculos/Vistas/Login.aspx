<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vistas.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenedorDinamico" runat="server">
    <p>

        &nbsp;</p>
    <p>

        Usuario<asp:TextBox ID="tbUsuario" runat="server" style="margin-left: 65px"></asp:TextBox>
&nbsp;&nbsp;
        <asp:Label ID="lbUsuario" runat="server"></asp:Label>

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btCargarUsuario" runat="server" OnClick="btCargarPantalla_Click" Text="Cargar Usuario" Width="139px" />
        <asp:Button ID="btCargarAdmin" runat="server" OnClick="btCargarAdmin_Click" Text="Cargar Admin" Width="140px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

    </p>
    <p>

        Contraseña<asp:TextBox ID="tbContraseña" runat="server" style="margin-left: 42px"></asp:TextBox>
&nbsp;&nbsp;
        <asp:Label ID="lbConstraseña" runat="server"></asp:Label>

    </p>
    <p>

        <asp:Button ID="btIngresar" runat="server" EnableViewState="False" style="margin-left: 110px" Text="Ingresar" OnClick="btIngresar_Click" />

    </p>
    <p>

        <asp:Label ID="lbMensaje" runat="server"></asp:Label>

    </p>
    </asp:Content>