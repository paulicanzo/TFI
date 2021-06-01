<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BackEnd.master" CodeBehind="GestionarProducto.aspx.cs" Inherits="Web.Sistema.GestionarProducto" %>

<asp:Content ID="asd" ContentPlaceHolderID="cuerpo" runat="server">
    <center>
        <div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <h4>Gestionar Producto</h4>
                <div>
                    <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
                    <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" Width="200px"></asp:TextBox>
                </div>
                    <br />
                 <div>
                     <asp:Label ID="Label2" runat="server" Text="Punto de Pedido:"></asp:Label>
                     <asp:TextBox ID="txtPuntoPedido" CssClass="form-control" runat="server" Width="200px"></asp:TextBox>
                </div>
                <br />
                <div>
                    <asp:Label ID="Label3" runat="server" Text="Precio:"></asp:Label>
                    <asp:TextBox ID="txtPrecio"  CssClass="form-control" runat="server" Width="200px"></asp:TextBox>
                </div>
                <br />
                <div>
                    <asp:Label ID="Label4" runat="server" Text="Cantidad:"></asp:Label>
                    <asp:TextBox ID="txtCantidad" CssClass="form-control" runat="server" Width="200px"></asp:TextBox>
                </div>                    
                <br />
                <div>
                    <asp:Label ID="Label5" runat="server" Text="Categoria:"></asp:Label>
                    <asp:DropDownList ID="ddlCategoria" runat="server" Height="35px" Width="200px"  OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged1" ForeColor="Black"></asp:DropDownList>
                </div>
                <br />
                <div>
                    <asp:Label ID="Label6" runat="server" Text="Proveedor:"></asp:Label>
                    <asp:DropDownList ID="ddlProveedor" runat="server" Height="35px" Width="200px"  OnSelectedIndexChanged="ddlProveedor_SelectedIndexChanged" ForeColor="Black"></asp:DropDownList>
                </div>
                <br />
                <asp:Button ID="Button1" runat="server" Width="96px" Text="Gruardar" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="Button1_Click" BorderColor="Black" />
                &nbsp;<asp:Button ID="Cancelar" runat="server" Width="102px" Text="Cancelar" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="Cancelar_Click1" BorderColor="Black"/>
        </div>
    </center>
</asp:Content>
