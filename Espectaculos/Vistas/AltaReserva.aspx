<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AltaReserva.aspx.cs" Inherits="Vistas.AltaReserva" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenedorDinamico" runat="server">
    <p>
        &nbsp;</p>
    <p>
        Espectaculo&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbEspectaculo" runat="server" ReadOnly="True" Width="391px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblEspectaculo" runat="server"></asp:Label>
    </p>
    <p>
        Cant entradas<asp:TextBox ID="tbCantEntradas" runat="server" style="margin-left: 44px" Width="80px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblCantEntradas" runat="server"></asp:Label>
    </p>
<p>
        &nbsp;</p>
    <p style="margin-left: 40px">
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    </p>
    <asp:Button ID="btReserva" runat="server" OnClick="btReserva_Click" style="margin-left: 130px" Text="Reservar" />
    <p>
        &nbsp;</p>
</asp:Content>