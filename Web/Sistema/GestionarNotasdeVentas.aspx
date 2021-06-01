<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BackEnd.master" CodeBehind="GestionarNotasdeVentas.aspx.cs" Inherits="Web.Sistema.GestionarNotasdeVentas" %>

<asp:Content ID="Cuerpo" ContentPlaceHolderID="cuerpo" runat="server">
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
            <h3>Gestionar Notas de Ventas</h3>
            <br />
                <div id="Busqueda">
                     <asp:TextBox ID="txtFiltrar" runat="server" Width="250px">Cliente, Fecha  o Estado</asp:TextBox>
                     &nbsp;<asp:Button ID="BtnFiltrar" runat="server" Height="41px" OnClick="BtnFiltrar_Click1" Text="Filtrar"  Width="105px" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black"/>
                </div>
            <br />
            <br />       
            <asp:GridView ID="gvNotas" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4"  Width="80%" AutoGenerateColumns="False" HorizontalAlign="Center"   OnSelectedIndexChanged="gvNotas_SelectedIndexChanged" onrowdatabound="gvNotas_RowDataBound">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="NroNotaVenta" HeaderText="Nro Nota" SortExpression="NroNotaVenta" AccessibleHeaderText="NroNotaVenta" />
                    <asp:BoundField DataField="Cliente" HeaderText="Cliente" SortExpression="Cliente" AccessibleHeaderText="Cliente" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" AccessibleHeaderText="Fecha" />
                    <asp:BoundField DataField="PrecioTotal" HeaderText="PrecioTotal" SortExpression="PrecioTotal" AccessibleHeaderText="Precio Total" />
                    <asp:BoundField AccessibleHeaderText="Estado" DataField="Estado" HeaderText="Estado" />                    
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
                &nbsp;<asp:Button ID="BtnGenerarOC" runat="server" Height="40px" OnClick="BtnGenerarOC_Click" Text="Generar Nota de Venta" Width="211px" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black"/>
                &nbsp;<asp:Button ID="BtnDescontarMercaderia" runat="server" Height="41px" OnClick="BtnDescontarMercaderia_Click" Text="Descontar Mercaderia" Width="182px" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black"/>
                &nbsp;<asp:Button ID="BtnVerDetalle" runat="server" Height="42px" OnClick="BtnVerDetalle_Click" Text="Ver Detalle" Width="112px" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black"/>
                &nbsp;<asp:Button ID="BtnAnular" runat="server" OnClick="BtnAnular_Click" Text="Anular" Height="42px" Width="115px" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black"/>
                &nbsp;<asp:Button ID="BtnImprimir" runat="server" OnClick="BtnImprimir_Click" Text="Imprimir Nota de Venta" Height="43px" Width="185px" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black"/>
                &nbsp;&nbsp;<br />
            </div>  
</asp:Content>
