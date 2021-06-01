<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BackEnd.master" CodeBehind="DescontarMercaderia.aspx.cs" Inherits="Web.Sistema.DescontarMercaderia" %>

<asp:Content ID="c" ContentPlaceHolderID="cuerpo" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <div class="container form-horizontal center-block">
        <div><h4>Descontar Mercaderia</h4></div>
        <div class="container alert alert-dismissible alert-info">
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Cliente:"></asp:Label>
                <asp:TextBox ID="txtFechaEmision" CssClass="form-control col-lg-2 pull-right" runat="server" AutoPostBack="true"></asp:TextBox>
                <asp:Label ID="Label2" CssClass="pull-right" runat="server" Text="Fecha:" Width="48px"></asp:Label>
            </div>
            <asp:TextBox ID="txtClientes" CssClass="form-control col-lg-2 pull-right" runat="server" AutoPostBack="true"></asp:TextBox>
            <br />
            <h5>Detalle Nota de Venta:</h5>
            <center>
                <div class="form-group">
                    <asp:GridView ID="gvDetalle" CssClass="table table-bordered table-hover table-condensed" runat="server" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="gvDetalle_SelectedIndexChanged" AutoGenerateSelectButton="true" Width="428px">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField AccessibleHeaderText="Cantidad" DataField="Cantidad" HeaderText="Cantidad" />
                            <asp:BoundField AccessibleHeaderText="Producto" DataField="Producto" HeaderText="Producto" />
                            <asp:BoundField AccessibleHeaderText="PrecioUnitario" DataField="PrecioUnitario" HeaderText="Precio Unitario" />
                            <asp:BoundField AccessibleHeaderText="SubTotal" DataField="SubTotal" HeaderText="SubTotal" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </div>
            </center>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <div class="form-group">
                <asp:TextBox ID="txtTotal" CssClass="pull-right" runat="server" AutoPostBack="true" OnTextChanged="txtTotal_TextChanged"></asp:TextBox>
                <asp:Label ID="Label3" CssClass="pull-right" runat="server" Text="Precio Total:"></asp:Label>
            </div>
        </div>
    </div>
        <br />
        <center>
            <div>
                Cantidad:
                <div>
                    <div style="width:131px">
                        <asp:TextBox ID="txtCantidadIngresada" runat="server" AutoPostBack="true"></asp:TextBox>
                    </div>
                </div>
            </div>
            <br />
            <div>
                <asp:Button runat="server" Text="Cargar" ID="btnCargar" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black" OnClick="btnCargar_Click" Height="43px" Width="94px" />
            </div>
            <br />
            <asp:Button runat="server" Text="Aceptar" ID="btnAceptar" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black" OnClick="btnAceptar_Cliclk" />
        </center>
</asp:Content>
