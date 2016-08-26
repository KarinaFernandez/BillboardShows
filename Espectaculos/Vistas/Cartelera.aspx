<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Cartelera.aspx.cs" Inherits="Vistas.Cartelera" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenedorDinamico" runat="server">
    <p>
        CARTELERA DE ESPECTACULOS&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btCargaPantalla" runat="server" OnClick="btCargaPantalla_Click" style="margin-top: 29px" Text="Cargar datos pantalla" />
</p>
    <p>
        Fecha desde&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <asp:Calendar ID="CalendarDesde" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px"  Width="200px">
        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
        <NextPrevStyle VerticalAlign="Bottom" />
        <OtherMonthDayStyle ForeColor="#808080" />
        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
        <SelectorStyle BackColor="#CCCCCC" />
        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
        <WeekendDayStyle BackColor="#FFFFCC" />
    </asp:Calendar>
    <p>
        Fecha hasta<asp:Calendar ID="CalendarHasta" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px"  Width="200px">
            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
            <NextPrevStyle VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#808080" />
            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" />
            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
            <WeekendDayStyle BackColor="#FFFFCC" />
        </asp:Calendar>
    </p>
    <p>
        <asp:Label ID="lblFechaHasta" runat="server"></asp:Label>
    </p>
    <p>
        Tipo espectaculo</p>
    <p>
        <asp:RadioButtonList ID="rbTipoEspec" runat="server">
            <asp:ListItem>Estandar</asp:ListItem>
            <asp:ListItem>VIP</asp:ListItem>
        </asp:RadioButtonList>
    </p>
    <p>
        &nbsp;Precio desde&nbsp;&nbsp;&nbsp; <asp:TextBox ID="tbPrecioDesde" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp; hasta&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbPrecioHasta" runat="server"></asp:TextBox>
    </p>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblPrecioDesde" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblPrecioHasta" runat="server"></asp:Label>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btFiltrar" runat="server" OnClick="btFiltrar_Click" Text="Buscar" />
    </p>
    <asp:Label ID="lblMensajeFiltrado" runat="server"></asp:Label>
    <p>
        <asp:GridView ID="GridViewEspect" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewEspect_RowCommand">
            <Columns>
                <asp:BoundField DataField="IdEspec" HeaderText="Id" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre espectaculo" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" />
                <asp:ButtonField ButtonType="Button" Text="Ver detalles" CommandName="VerDetalles" />
            </Columns>
        </asp:GridView>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
    <asp:GridView ID="GridViewDetalles" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="IdEspec" HeaderText="Id" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
            <asp:BoundField DataField="Hora" HeaderText="Hora" />
            <asp:BoundField DataField="Duracion" HeaderText="Duracion" />
            <asp:BoundField DataField="Categoria" HeaderText="Categoria" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
            <asp:BoundField DataField="Precio" HeaderText="Precio" />
            <asp:BoundField DataField="NombreLugar" HeaderText="Nombre Lugar" />
            <asp:BoundField DataField="DireccionLugar" HeaderText="Direccion Lugar" />
            <asp:BoundField DataField="TelLugar" HeaderText="Tel Lugar" />
            <asp:BoundField DataField="CapacidadLugar" HeaderText="Capacidad Lugar" />
        </Columns>
    </asp:GridView>
    <p style="margin-left: 40px">
        <asp:Button ID="btReservar" runat="server" OnClick="btReservar_Click" Text="Reservar" Visible="False" />
</p>
<p style="margin-left: 40px">
        &nbsp;</p>
<p style="margin-left: 40px">
        &nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>