<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BackEnd.master" CodeBehind="RegistrarPago.aspx.cs" Inherits="Web.Sistema.RegistrarPago" %>

<asp:Content ID="s" ContentPlaceHolderID="cuerpo" runat="server">
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
        <h3>Registrar Pago</h3>
        <br />
        <div >
        <div>
            <asp:Label ID="Label2" runat="server" Text="Fecha:"></asp:Label>
            <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
        </div>
        <br />
        <div>
            <asp:Label ID="Label1" runat="server" Text="Cliente:"></asp:Label>
            <asp:DropDownList ID="ddlClientes" OnSelectedIndexChanged="ddlClientes_SelectedIndexChanged1" AutoPostBack="true" runat="server" ForeColor="Black"></asp:DropDownList>
        </div>           
            <br />
            <br />
            <div>
            <asp:Label ID="Label8" runat="server" Text="Forma de Pago:"></asp:Label>
            <asp:DropDownList ID="ddlFormadePago" OnSelectedIndexChanged="ddlFormadePago_SelectedIndexChanged" AutoPostBack="true" runat="server" ForeColor="Black"></asp:DropDownList>
        </div>
        <div>
            <asp:Label ID="Label3" runat="server" Text="Saldo de Cuenta Corriente del Cliente: $"></asp:Label>
            <asp:Label ID="txtSaldo" runat="server" Text="Saldo"></asp:Label>
        </div>
            <br />
            <div>
            <asp:Label ID="Label6" runat="server" Text="Comprobante a abonar:"></asp:Label>
            <asp:DropDownList ID="ddlComprobanteAbonar" OnSelectedIndexChanged="ddlComprobanteAbonar_SelectedIndexChanged" AutoPostBack="true" runat="server" ForeColor="Black"></asp:DropDownList>
        </div>
        <br />
            <div>
            <asp:Label ID="Label7" runat="server" Text="Total del comprobante: $"></asp:Label>
            <asp:Label ID="txtSaldoCompro" runat="server" Text="Saldo"></asp:Label>
        </div>        
            <br />
        <div>
            <asp:Label ID="Label5" runat="server" Text="Monto: $"></asp:Label>
            <asp:TextBox ID="txtMonto" runat="server" OnTextChanged="txtMonto_TextChanged"></asp:TextBox>
        </div>
            <br />
        <div>
            &nbsp;<asp:Button ID="BtnCargarConcepto" runat="server" OnClick="BtnCargarConcepto_Click" Text="Cargar Concepto" Height="43px" Width="148px" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black"/>
        </div>
        <br />
        <div>
            <asp:Label ID="Label4" runat="server" Text="Concepto:"></asp:Label>
            <asp:TextBox ID="txtConcepto" runat="server" Width="700px"></asp:TextBox>
        </div>
        
            </div>
        <br />
        <div>
            &nbsp;<asp:Button ID="BtnRegistrar" runat="server" OnClick="Registrar_Clink" Text="Registrar Pago" Height="42px" Width="148px" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black"/>
        </div>
    </center>
</asp:Content>
