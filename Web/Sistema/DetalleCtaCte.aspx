<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BackEnd.master" CodeBehind="DetalleCtaCte.aspx.cs" Inherits="Web.Sistema.DetalleCtaCte" %>

<asp:Content ID="s" ContentPlaceHolderID="cuerpo" runat="server">
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
        <h3>Detalle Cuenta Corrienta</h3>
        <br />
        <div id="Datos">
            <asp:Label ID="Label2" runat="server" Text="Cliente" ></asp:Label>
            &nbsp;<asp:TextBox ID="txtCliente" runat="server" Width="102px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            <asp:Label ID="Label3" runat="server" Text="Categoria IVA" ></asp:Label>
            &nbsp;<asp:TextBox ID="txtIVA" runat="server" Width="102px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

             <asp:Label ID="Label4" runat="server" Text="Telefono" ></asp:Label>
             &nbsp;<asp:TextBox ID="txtTelefono" runat="server" Width="102px"></asp:TextBox>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            <asp:Label ID="Label5" runat="server" Text="Domicilio" ></asp:Label>
            &nbsp;<asp:TextBox ID="txtDomicilio" runat="server" Width="102px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            <asp:Label ID="Label6" runat="server" Text="Localidad" ></asp:Label>
            &nbsp;<asp:TextBox ID="txtLocalidad" runat="server" Width="102px"></asp:TextBox>
        </div>
        <br />
        <br />
         <asp:DataGrid ID="dvDetalle" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="95%" AutoGenerateColumns="False"  OnItemDataBound="dvDetalle_ItemDataBound" HorizontalAlign="Center" GridLines="Vertical">
             <AlternatingItemStyle BackColor="#DCDCDC" />
             <Columns>
                    <asp:BoundColumn DataField="Fecha" HeaderText="Fecha"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Concepto" HeaderText="Concepto" />
                    <asp:BoundColumn HeaderText="Ingreso" />
                    <asp:BoundColumn HeaderText="Egreso" />
                    <asp:BoundColumn DataField="Monto" Visible="false" />
                    <asp:BoundColumn DataField= "Tipo" Visible="false" />                    
                </Columns>
             <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
             <HeaderStyle BackColor="#000065" Font-Bold="True" ForeColor="White" />
             <ItemStyle BackColor="#EEEEEE" ForeColor="Black" />
             <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" Mode="NumericPages" />        
             <SelectedItemStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
         </asp:DataGrid>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Total: $" ></asp:Label>
        &nbsp;<asp:TextBox ID="txtTotal" runat="server" Width="102px"></asp:TextBox>
        <br />
        <br />
        <div>
            &nbsp;<asp:Button ID="Btnvolver" runat="server" Height="45px" OnClick="Btnvolver_Click" Text="Volver" Width="102px" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black" />
            &nbsp;&nbsp;
        <br />
        </div>  
    </center>
</asp:Content>
