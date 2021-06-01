<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BackEnd.master" CodeBehind="GestionarProductos.aspx.cs" Inherits="Web.Sistema.GestionarProductos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cuerpo" runat="server">
    
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
            <center>
            <h3>Gestionar Productos</h3>
            <br />
            <div id="Busqueda">
                <asp:TextBox ID="txtFiltrar" runat="server" Width="239px"></asp:TextBox>
                &nbsp;<asp:Button ID="BtnFiltrar" runat="server" Height="41px" Text="Filtrar" onclick="BtnFiltrar_Click" Width="78px" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black" />
            </div>           
            <br />
           
            <br />
            <asp:GridView ID="GridProducto" runat="server" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridProducto_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="codProducto" AccessibleHeaderText="Nombre" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="cantMinima" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" />
                    <asp:BoundField DataField="Proveedor" HeaderText="Proveedor" SortExpression="Proveedor" />
                    <asp:BoundField DataField="CategoriaProducto" HeaderText="Categoria Producto" SortExpression="CategoriaProducto" />
                    <asp:CheckBoxField AccessibleHeaderText="Estado" HeaderText="Estado" DataField="Estado" />
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
            <asp:Button ID="BtnAgregar" runat="server" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black" Height="42px" text="Agregar" onclick="BtnAgregar_Click" Width="109px" />
            &nbsp;<asp:Button ID="BtnModificar" runat="server" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black" Height="43px" text="Modificar" onclick="BtnModificar_Click" Width="109px" />
            &nbsp;<asp:Button ID="BtnHabilitar" runat="server"  CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black" Height="41px" Text="Habilitar/Deshabilitar" onclick="BtnHabilitar_Click" Width="174px" />
            &nbsp;<asp:Button ID="BtnConsultar" runat="server" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black" Height="45px" Text="Consultar" onclick="BtnConsultar_Click" Width="109px" />
            &nbsp;&nbsp;&nbsp;<br />  
        </div>
    </center>     
</asp:Content>
