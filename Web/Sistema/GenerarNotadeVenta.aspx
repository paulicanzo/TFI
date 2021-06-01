<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BackEnd.master" CodeBehind="GenerarNotadeVenta.aspx.cs" Inherits="Web.Sistema.GenerarNotadeVenta" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cuerpo" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <div class="container form-horizontal center-block">
        <div><h4>Generar Nota de Venta</h4></div>
        <div class="container alert alert-dismissible alert-info">
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Cliente:"></asp:Label>
                <asp:DropDownList ID="ddCliente" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddCliente_SelectedIndexChanged" ForeColor="Black" Height="17px" Width="144px"></asp:DropDownList>
                <asp:TextBox ID="txtFechaEmision" CssClass="form-control col-lg-2 pull-right" runat="server" AutoPostBack="true"></asp:TextBox>
                <asp:Label ID="Label2" CssClass="pull-right" runat="server" Text="Fecha:" Width="48px"></asp:Label>
            </div>
            <br />
            <h5>Detalle de Nota de Venta:</h5>
            <center>
                <div class="form-group">
                    <asp:GridView ID="gvDetalle" CssClass="table table-bordered table-hover table-condensed" runat="server" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanging="gvDetalle_SelectedIndexChanged1" AutoGenerateSelectButton="true" Width="428px">
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
            <br />
            <br />
        </div>
        <center>
            <div>
                <asp:Button runat="server" Text="Deshacer" ID="btnDeshacer" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black" OnClick="btnDeshacer_Click" Width="100px" />
            </div>
            <br />
            <div class="form-group">
                <asp:Button runat="server" Text="Agregar" ID="Agregar" CssClass="btn btm-info" BackColor="#000065" ForeColor="White" BorderColor="Black" OnClick="Agregar_Click" Width="100px" />
                &nbsp;<asp:Button runat="server" Text="Quitar" ID="Quitar" class="btn btn-default" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black" OnClick="Quitar_Click" Width="100px" />
            </div>
            <br />
            <div class="form-group">
                <asp:Label ID="Label7" runat="server" Text="Cantidad:"></asp:Label>
                <asp:TextBox ID="txtCantidad" runat="server" AutoPostBack="true">2</asp:TextBox>
                <br />
                <asp:Label ID="Label6" runat="server" Text="Precio Unitario:"></asp:Label>
                <asp:TextBox ID="txtPrecioUnitario" runat="server" AutoPostBack="true">2</asp:TextBox>
            </div>
            <br />
            <div class="form-group">
                <asp:Label ID="Label5" runat="server" Text="Filtrar:"></asp:Label>
                <asp:TextBox ID="txtFiltrar" runat="server" AutoPostBack="true"></asp:TextBox>
                &nbsp;<asp:Button Text="Filtrar" runat="server" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black" OnClick="Unnamed1_Click" Width="76px" Height="40px" />
            </div>
            <div class="form-group">
                <asp:Label ID="Label4" runat="server" Text="Lista de Productos: "></asp:Label>
                <br />
                <asp:GridView ID="gvListadoProductos" runat="server" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvListadoProductos_SelectedIndexChanged" AutoGenerateSelectButton="true" Width="278px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField AccessibleHeaderText="Nombre" DataField="Nombre" HeaderText="Productos" />
                        <asp:BoundField AccessibleHeaderText="Cantidad" DataField="Cantidad" HeaderText="Cantidad" />
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
            <br />
            <br />
            <br />
            <br />
            <br />
            <div class="form-group">
                <asp:Button runat="server" Text="Aceptar" ID="Aceptar" class="btn btn-default" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black" OnClick="Aceptar_Click" />
                &nbsp; 
                <asp:Button runat="server" Text="Cancelar" ID="Cancelar" class="btn btn-default" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black" OnClick="Cancelar_Click" />
            </div>
        </center>
    </div>
</asp:Content>

