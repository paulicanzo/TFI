<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BackEnd.master" CodeBehind="GestionarClientes.aspx.cs" Inherits="Web.Sistema.GestionarClientes" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cuerpo" runat="server">
    <center>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <h3>Gestionar Clientes</h3>
        <br />
        <div id="Busqueda">
            <asp:TextBox ID="txtFiltrar" runat="server" Width="239px"></asp:TextBox>
            &nbsp;<asp:Button ID="btnFiltrar" runat="server" Height="38px" OnClick="btnFiltrar_Click" Text="Filtrar" Width="105px" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black" />
        </div>
        <br />
        <br />
        <asp:GridView ID="gvClientes" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="95%" AutoGenerateColumns="false"  HorizontalAlign="Center" OnSelectedIndexChanged="gvClientes_SelectedIndexChanged" OnPageIndexChanging="gvClientes_PageIndexChanging">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" AccessibleHeaderText="RazonSocial" />
                <asp:BoundField DataField="CorreoElectronico" HeaderText="Correo Electronico" AccessibleHeaderText="CorreoElectronico" />
                <asp:BoundField AccessibleHeaderText="Telefono" DataField="Telefono" HeaderText="Telefono" />
                <asp:CheckBoxField AccessibleHeaderText="Estado" DataField="Estado" HeaderText="Estado" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
        <br />
        <div>
            &nbsp;<asp:Button ID="BtnAgregar" runat="server" Height="45px" OnClick="BtnAgregar_Click" Text="Agregar" Width="102px" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black" />
            &nbsp;<asp:Button ID="BtnModificar" runat="server" Height="40px" OnClick="BtnModificar_Click" Text="Modificar" Width="103px" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black" />
            &nbsp;<asp:Button ID="BtnEliminar" runat="server" OnClick="BtnEliminar_Click" Text="Habilitar/Deshabilitar" Height="42px" Width="166px" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black"/>
            &nbsp;<asp:Button ID="BtnConsultar" runat="server" OnClick="BtnConsultar_Click" Text="Consultar" Height="42px" Width="119px" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black"/>
            &nbsp;&nbsp;<br />
        </div>
    </center>
</asp:Content>
