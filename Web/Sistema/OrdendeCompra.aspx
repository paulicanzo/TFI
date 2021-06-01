<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BackEnd.master" CodeBehind="OrdendeCompra.aspx.cs" Inherits="Web.Sistema.OrdendeCompra" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cuerpo" runat="server">

    <br />
    <br />
    <br />
    <br />
    <br />
    <div class="<form-horizontal center-block">
        <center><h3>Generar Orden de Compra</h3></center>
        <div class="container alert alert-dismissible alert-info">           

                <div class="form-group">
                    <div class="form-group">    
                        <asp:Label ID="Label2" runat="server" Text="Proveedor:"></asp:Label> <br />
                        <asp:DropDownList ID="dProveedores" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dProveedores_SelectedIndexChanged1" ForeColor="Black" Height="19px" Width="155px"></asp:DropDownList>
                    </div>
                    <div class="form-group">    
                        <asp:Label ID="Label3" runat="server" Text="Fecha de Emision:"></asp:Label><br />                   
                        <asp:TextBox ID="TxtFechaEmision" CssClass="form-control col-lg-2" runat="server" AutoPostBack="true"></asp:TextBox> 
                    </div>
                </div>
            <br />
            <br />
            <br />
            <br />
                <div class="form-group">
                    <div class="form-group"> 
                        <asp:Label ID="Label1" runat="server" Text="Condicion de Pago:"></asp:Label><br />              
                        <asp:DropDownList ID="ddCondiciones" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddCondiciones_SelectedIndexChanged" ForeColor="Black"></asp:DropDownList>
                    </div>          
                    <div class="form-group">
                        <asp:Label ID="Label4" runat="server" Text="Fecha de Recepcion de Mercaderia"></asp:Label><br />
                        <asp:TextBox ID="txtFecgaRecepcion" CssClass="form-control col-lg-2" runat="server" AutoPostBack="true"></asp:TextBox>
                    </div>
                </div>
            <br />
            <br />
            <br />
            <div>
                Detalle:
                <center>
                <div class="form-group">
                    <asp:GridView ID="gvDetalle" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvDetalle_SelectedIndexChanged" AutoGenerateSelectButton="true" >
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField AccessibleHeaderText="Cantidad" DataField="Cantidad" HeaderText="Cantidad" />
                            <asp:BoundField AccessibleHeaderText="Producto" DataField="Producto" HeaderText="Productos" />
                            <asp:BoundField AccessibleHeaderText="PrecioUnitario" DataField="PrecioUnitario" HeaderText="Precio Unitario" />
                            <asp:BoundField AccessibleHeaderText="SubTotal" DataField="SubTotal" HeaderText="SubTotal" />
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
                    </center>
                 </div>
             Total:
                    <div >
                        <div style="width: 131px" >
                            <asp:TextBox ID="txtTotal" runat="server" AutoPostBack="true" OnTextChanged="TxtTotal_TextChanged">
                            </asp:TextBox>
                        </div>
                    </div>
            </div>
            <br />
       <div>
               
        </div>
            </div>
     <center>
            <div>
                <div>
                    <asp:Button runat="server" Text ="Agregar" ID="Agregar"  CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black"  OnClick="Agregar_Click" Width="99px" /> <%--OnClick="Agregar_Click"--%> 
                    &nbsp;<asp:Button runat="server" Text ="Quitar" ID="Quitar"  CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black"  OnClick="Quitar_Click1" /><%--OnClick="Quitar_Click"--%>
                </div>
            </div>
            <br />

            <div >
                Cantidad:
                    <div >
                        <div style="width: 131px" >
                            <asp:TextBox ID="txtCantidad" runat="server" AutoPostBack="true">2</asp:TextBox>
                        </div>
                    </div>
            </div>
            <br />
            <div >
                Precio Unitario:
                    <div>
                        <div style="width: 126px" >
                            <asp:TextBox ID="txtPrecioUnitario" runat="server" AutoPostBack="true">2</asp:TextBox>
                        </div>
                    </div>
            </div>
            <br />
   
            <div>
                Listado de Productos:
                <div class="form-group">
                        <br />

                    <asp:GridView ID="gvListadoProductos" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvListadoProductos_SelectedIndexChanged" AutoGenerateSelectButton="true">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField AccessibleHeaderText="Nombre" DataField="Nombre" HeaderText="Productos" />
                            <asp:BoundField AccessibleHeaderText="Cantidad" DataField="Cantidad" HeaderText="Cantidad" />
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
            </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
                <div>
                    <asp:Button runat="server" Text ="Aceptar" ID="Aceptar" class="btn btn-default" OnClick="Aceptar_Click" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black"/>
                    &nbsp;<asp:Button runat="server" Text ="Cancelar" ID="Cancelar" class="btn btn-default" OnClick="Cancelar_Click" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black" Width="107px"/><%--OnClick="Quitar_Click"--%>
                </div>  
        </center>
</asp:Content>



