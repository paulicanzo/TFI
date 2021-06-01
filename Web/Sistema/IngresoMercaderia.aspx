<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BackEnd.master" CodeBehind="IngresoMercaderia.aspx.cs" Inherits="Web.Sistema.IngresoMercaderia" %>

<asp:Content ID="Cuerpo" ContentPlaceHolderID="cuerpo" runat="server">
    <div>
        <br />
            <br />
            <br />
        <br />
            <br />
            <br />
     
        <div class="<form-horizontal center-block">
        <h3>Control de Mercaderia</h3>
        <div class="container alert alert-dismissible alert-info">           

                <div class="form-group">
                    <div class="form-group">    
                        <asp:Label ID="Label5" runat="server" Text="Nro Orden:"></asp:Label> <br />
                        <asp:TextBox ID="txtNroOrden" CssClass="form-control col-lg-2" runat="server" AutoPostBack="true"></asp:TextBox> 
                    </div>
                    <div class="form-group">    
                        <asp:Label ID="Label2" runat="server" Text="Proveedor:"></asp:Label> <br />
                        <asp:TextBox ID="TXTProveedor" CssClass="form-control col-lg-2" runat="server" AutoPostBack="true"></asp:TextBox> 
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
                        <asp:TextBox ID="txtCondicion" CssClass="form-control col-lg-2" runat="server" AutoPostBack="true"></asp:TextBox> 
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
                    <asp:GridView ID="gvDetalleOC" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvDetalleOC_SelectedIndexChanged" AutoGenerateSelectButton="true" >
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
                            <asp:TextBox ID="txtTotal" runat="server" AutoPostBack="true" OnTextChanged="txtTotal_TextChanged">
                            </asp:TextBox>
                        </div>
                    </div>
            </div>
            <br />
       <div>
               
        </div>
            </div>
     <center>
            <br />
            <div >
                Cantidad:
                    <div >
                        <div style="width: 131px" >
                            <asp:TextBox ID="txtCantidadIngresada" runat="server" AutoPostBack="true"></asp:TextBox>
                        </div>
                    </div>
            </div>
            <br />
         <div>
                    <asp:Button runat="server" Text ="Cargar" ID="btnCargar" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black" OnClick="btnCargar_Click"/>
                </div>
            <br />
   
            <div>
                Estado de Mercaderia:
                <div class="form-group">
                        <br />

                    <asp:GridView ID="gvEstadoMerca" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvEstadoMerca_SelectedIndexChanged" AutoGenerateSelectButton="true">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField AccessibleHeaderText="Producto" DataField="Producto" HeaderText="Productos" />
                            <asp:BoundField AccessibleHeaderText="CantidadFaltante" DataField="CantidadFaltante" HeaderText="Cantidad Faltante" />
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
                    <asp:Button runat="server" Text ="Aceptar" ID="Aceptar" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black" OnClick="Aceptar_Click"/>
                    &nbsp;<asp:Button runat="server" Text ="Cancelar" ID="Cancelar" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black" OnClick="Cancelar_Click"/>
                </div>  
        </center>
    </div>
</asp:Content>