<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BackEnd.master" CodeBehind="ListadoCuentasCorrientes.aspx.cs" Inherits="Web.Sistema.ListadoCuentasCorrientes" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cuerpo" runat="server">
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
<h3>Cuentas Corrientes</h3>
            <br />
            <div id="Busqueda">
                <asp:TextBox ID="txtFiltrar" runat="server" Width="239px">Ingrese Cliente</asp:TextBox>
                &nbsp;<asp:Button ID="BtnFiltrar" runat="server" Height="38px" OnClick="BtnFiltrar_Click" Text="Filtrar"  Width="105px" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black" />
            </div>
            <br />
            <br />
        
            <asp:GridView ID="gvCtasCtes" runat="server" BackColor="White" BorderColor="#3366CC"
                BorderStyle="None" BorderWidth="1px" CellPadding="4"
                Width="95%" AutoGenerateColumns="False" HorizontalAlign="Center" OnSelectedIndexChanged="gvCtasCtes_SelectedIndexChanged" OnPageIndexChanging="gvCtasCtes_PageIndexChanging">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="Cliente" HeaderText="Cliente" AccessibleHeaderText="Cliente" />
                    <asp:BoundField DataField="Saldo" HeaderText="Saldo" AccessibleHeaderText="Saldo" />
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
            &nbsp;<asp:Button ID="BtnVerDetalle" runat="server" Height="45px" OnClick="BtnVerDetalle_Click" Text="Ver Detalle" Width="108px" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black" />
            &nbsp;<asp:Button ID="BtnImprimir" runat="server" Height="40px" OnClick="BtnImprimir_Click" Text="Imprimir Cuenta Corriente" Width="206px" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black" />
            &nbsp;&nbsp;<br />
            </div>  
</asp:Content>
