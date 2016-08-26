<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Espectaculos.aspx.cs" Inherits="Vistas.AltaEspectaculo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenedorDinamico" runat="server">
    <p>
        &nbsp;</p>
    <p>
        Nombre&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbNombre" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblNombre" runat="server"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btCargarEstandar" runat="server" OnClick="btCargarEstandar_Click" Text="Cargar datos estandar" Width="194px" />
    &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btCargarVIP" runat="server" OnClick="btCargarVIP_Click" Text="Cargar datos VIP" Width="190px" />
    </p>
    <p>
        Fecha&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Calendar ID="Calendar" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" style="margin-left: 86px" Width="200px">
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
        <asp:Label ID="lblFecha" runat="server"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p>
        Hora&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbHora" runat="server" style="margin-left: 21px" Width="34px"></asp:TextBox>
&nbsp;<strong>: </strong>&nbsp;<asp:TextBox ID="tbMinutos" runat="server" Width="34px"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblHora" runat="server"></asp:Label>
    </p>
    <p>
        Duracion&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbDuracion" runat="server" Width="61px"></asp:TextBox>
    &nbsp;min&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblDuracion" runat="server"></asp:Label>
    </p>
    <p>
        Lugar&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="dropDownLugar" runat="server" Height="25px" Width="207px" style="margin-bottom: 0px">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblLugar" runat="server"></asp:Label>
    </p>
    <p>
        Precio&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbPrecio" runat="server"></asp:TextBox>
    &nbsp;
        <asp:Label ID="lblPrecio" runat="server"></asp:Label>
    </p>
    <p>
        Categoria&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbCategoria" runat="server"></asp:TextBox>
        &nbsp;&nbsp;
        <asp:Label ID="lblCategoria" runat="server"></asp:Label>
    </p>
    <p>
        Descripcion&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbDescripcion" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;<asp:Label ID="lblDescrip" runat="server"></asp:Label>
    </p>
        <asp:RadioButtonList ID="rbTipoEspect" runat="server">
            <asp:ListItem>Estandar</asp:ListItem>
            <asp:ListItem>VIP</asp:ListItem>
        </asp:RadioButtonList>
    <p>
        &nbsp;
        <asp:CheckBox ID="cbImpreso" runat="server" Text="Impreso" Enabled="False" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Recargo&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbRecargo" runat="server" Enabled="False"></asp:TextBox>
&nbsp;
        <asp:Label ID="lblMensajeRecargo" runat="server"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p style="margin-left: 40px">
        <asp:Label ID="lblMensajeAlta" runat="server"></asp:Label>
    </p>
    <p style="margin-left: 40px">
        <asp:Button ID="btAltaEspect" runat="server" OnClick="btAltaEspect_Click" Text="Alta espectaculo" Width="181px" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
<p style="margin-left: 40px">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
    <div style="margin-left: 40px">
        <asp:Button ID="btEspecLlenos" runat="server" OnClick="btEspecLlenos_Click" Text="Espectaculos llenos" Width="181px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblMensajeEspecLlenos" runat="server"></asp:Label>
        <br />
    </div>
&nbsp;&nbsp;&nbsp;
    <asp:GridView ID="GridViewEspecLlenos" runat="server" AutoGenerateColumns="False" style="margin-right: 0px">
        <Columns>
            <asp:BoundField DataField="IdEspec" HeaderText="Id" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
            <asp:BoundField DataField="Hora" HeaderText="Hora" />
            <asp:BoundField DataField="NombreLugar" HeaderText="Nombre Lugar" />
            <asp:BoundField DataField="CapacidadLugar" HeaderText="Capacidad Lugar" />
            <asp:BoundField DataField="EntradasVendidas" HeaderText="Entradas vendidas" />
        </Columns>
    </asp:GridView>
    </asp:Content>