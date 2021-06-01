<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BackEnd.master" CodeBehind="Auditoria_OrdenCompra.aspx.cs" Inherits="Web.Auditoria.Auditoria_OrdenCompra" %>

<asp:Content ID="s" ContentPlaceHolderID="cuerpo" runat="server">
   
    <center>
        <br />
        <br />
        <br />
        <br />

        <div class="container">
            <br />
            <br />
            <h4>Ordenes de Compra</h4>
            <br />
            <br />
            <br />

            <div>
                <asp:GridView ID="gvOrden" OnSelectedIndexChanging="gvOrden_SelectedIndexChanging" AutoGenerateSelectButton="true" CssClass="table table-bordered table-hover table-condensed" runat="server" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gvlOG_PageIndexChanging" OnSelectedIndexChanged="gvlOG_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField AccessibleHeaderText="NroOrdenCompra" DataField="NroOrdenCompra" HeaderText="Nro Orden" />
                        <asp:BoundField AccessibleHeaderText="Proveedor" DataField="Proveedor" HeaderText="Proveedor" />
                        <asp:BoundField AccessibleHeaderText="CondicionesPago" DataField="CondicionesPago" HeaderText="Condiciones de Pago" />
                        <asp:BoundField AccessibleHeaderText="FechaEmision" DataField="FechaEmision" HeaderText="Fecha Emision" />
                        <asp:BoundField AccessibleHeaderText="Estado" DataField="Estado" HeaderText="Estado" />
                        <asp:BoundField AccessibleHeaderText="Usuario" DataField="Usuario" HeaderText="Usuario" />
                        <asp:BoundField AccessibleHeaderText="Operacion" DataField="Operacion" HeaderText="Operacion" />
                        <asp:BoundField AccessibleHeaderText="Fecha" DataField="Fecha" HeaderText="Fecha" />
                        <asp:BoundField AccessibleHeaderText="Equipo" DataField="Equipo" HeaderText="Equipo" />
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
            </div>
            <div class="table tab-content table-bordered table-condensed">
                &nbsp; <asp:Button ID="btnVerDetalle" runat="server" Height="42px" OnClick="btnVerDetalle_Click" Text="Ver Detalle" Width="112px" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black" />
            </div>
        </div>

    </center>
</asp:Content>
