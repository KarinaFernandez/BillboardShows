<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Reservas.aspx.cs" Inherits="Vistas.ReservasPendientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenedorDinamico" runat="server">
    <p>
        &nbsp;</p>
    &nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="btReservasPend" runat="server" OnClick="btReservasPend_Click" Text="Reservas pendientes" Width="184px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblMensajeReservas" runat="server"></asp:Label>
    <br />
<br />
&nbsp;&nbsp;&nbsp;
<asp:Button ID="btRankingCli" runat="server" Text="Ranking clientes" Width="183px" OnClick="btRankingCli_Click" />
    <p>
        &nbsp;</p>
    <p>
        <asp:GridView ID="GridViewReservasPend" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewReservasPend_RowCommand" style="margin-right: 1px">
            <Columns>
                <asp:BoundField DataField="IdReserva" HeaderText="Id" />
                <asp:BoundField DataField="UsuarioNombre" HeaderText="Usuario" />
                <asp:BoundField DataField="UsuarioEmail" HeaderText="Email" />
                <asp:BoundField DataField="UsuarioTel" HeaderText="Telefono" />
                <asp:BoundField DataField="EspectaculoNombre" HeaderText="Espectaculo" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="Total" HeaderText="Total a pagar" />
                <asp:ButtonField Text="Pagar" CommandName="Pagar" />
            </Columns>
        </asp:GridView>
    </p>
<p>
        &nbsp;</p>
<p>
        <asp:Label ID="lblRanking" runat="server" Text="Ranking clientes" Visible="False"></asp:Label>
    </p>
<p>
        <asp:ListBox ID="listRanking" runat="server" Height="99px" Visible="False" Width="555px"></asp:ListBox>
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>