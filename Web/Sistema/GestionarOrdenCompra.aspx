<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BackEnd.master" CodeBehind="GestionarOrdenCompra.aspx.cs" Inherits="Web.Sistema.GestionarOrdenCompra" %>

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
            <h3>Gestionar Ordenes de Compra</h3>
            <br />
                <div id="Busqueda">
                    <asp:TextBox ID="txtFiltrar" runat="server" Width="250px">Proveedor, Fecha  o Estado</asp:TextBox>
                    &nbsp;<asp:Button ID="BtnFiltrar" runat="server" Height="41px" OnClick="BtnFiltrar_Click" Text="Filtrar"  Width="105px" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black"/>
                <%--&nbsp;<asp:Button ID="btnCancelar" runat="server" Height="27px" OnClick="btnCancelar_Click" Text="Cancelar"  Width="99px" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black"/>--%>
                </div>
            <br />
            <br />
        
            <asp:GridView ID="gvOrdenes" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="80%" AutoGenerateColumns="False" HorizontalAlign="Center"  OnSelectedIndexChanged="gvOrdenes_SelectedIndexChanged1" onrowdatabound="gvOrdenes_RowDataBound">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="NroOrdenCompra" HeaderText="Nro Orden" SortExpression="NroOrdenCompra" AccessibleHeaderText="NroOrdenCompra" />
                    <asp:BoundField DataField="FechaEmision" HeaderText="Fecha de Emision" SortExpression="FechaEmision" AccessibleHeaderText="FechaEmision" />
                    <asp:BoundField DataField="PrecioTotal" HeaderText="PrecioTotal" SortExpression="PrecioTotal" AccessibleHeaderText="Precio Total" />
                    <asp:BoundField DataField="FechaRecepcionMercaderia" HeaderText="Fecha de Recepcion Mercaderia" SortExpression="dd/MM/yyyy" AccessibleHeaderText="Fecha Recepcion Mercaderia"/>
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
                &nbsp;<asp:Button ID="BtnGenerarOC" runat="server" Height="40px" OnClick="BtnGenerarOC_Click" Text="Generar Orden de Compra" Width="211px" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black"/>
                &nbsp;<asp:Button ID="BtnIngresarMercaderia" runat="server" Height="41px" OnClick="BtnIngresarMercaderia_Click" Text="Ingresar Mercaderia" Width="168px" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black"/>
                &nbsp;<asp:Button ID="BtnVerDetalle" runat="server" Height="42px" OnClick="BtnVerDetalle_Click" Text="Ver Detalle" Width="112px" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black"/>
                &nbsp;<asp:Button ID="BtnAnular" runat="server" OnClick="BtnAnular_Click" Text="Anular" Height="42px" Width="115px" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black"/>
                &nbsp;<asp:Button ID="BtnImprimir" runat="server" OnClick="BtnImprimir_Click" Text="Imprimir Orden de Compra" Height="43px" Width="222px" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black"/>
                &nbsp;&nbsp;<br />
            </div>  
</asp:Content>
