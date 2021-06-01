<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BackEnd.master" CodeBehind ="DetalleOC.aspx.cs" Inherits="Web.Sistema.DetalleOC" %>

<asp:Content ID="s" ContentPlaceHolderID="cuerpo" runat="server">
    <center>
        <div>
            <br />
            <br />
            <br />
            <h3>Detalle Orden de Compra</h3>
        </div>
        <div>
            <asp:Label ID="Label3" runat="server" Text="Nro de Orden:"></asp:Label>
            <asp:TextBox ID="txtNroOrden" CssClass="form-control col-lg-2" runat="server" AutoPostBack="true"></asp:TextBox>
        </div>
        <br />
        <div>
            <asp:GridView ID="gvDetalleOC" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField AccessibleHeaderText="Cantidad" DataField="Cantidad" HeaderText="Cantidad" />
                    <asp:BoundField AccessibleHeaderText="Producto" DataField="Producto" HeaderText="Producto" />
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
        <br />
        <div>
            <asp:Label ID="Label1" runat="server" Text="Total: $"></asp:Label>
            <asp:TextBox ID="txtTotal" CssClass="form-control col-lg-2" runat="server" AutoPostBack="true"></asp:TextBox>
        </div>
        <br />
        <div>
            <asp:Button runat="server" Text="Aceptar" ID="Aceptar" class="btn btn-default" OnClick="Aceptar_Click" />
        </div>
    </center>
</asp:Content>
