<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BackEnd.master" CodeBehind="GenerarNotadeCredito.aspx.cs" Inherits="Web.Sistema.GenerarNotadeCredito" %>

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
        <h3>Generar Nota de Credito</h3>
        <br />
        <div>
            <div>
                <asp:Label ID="Label2" runat="server" Text="Fecha:"></asp:Label>
                <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label ID="Label8" runat="server" Text="Forma de Pago:"></asp:Label>
                <asp:DropDownList ID="ddlFormaPago" OnSelectedIndexChanged="ddlFormaPago_SelectedIndexChanged" AutoPostBack="true" runat="server" ForeColor="Black"></asp:DropDownList>
            </div>
            <br />
            <div>
                <asp:Label ID="Label1" runat="server" Text="Cliente:"></asp:Label>
                <asp:DropDownList ID="ddlClientes" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlClientes_SelectedIndexChanged" ForeColor="Black"></asp:DropDownList>
            </div>
            <br />
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
                <asp:Label ID="Label7" runat="server" Text="Total del comprobante: $ "></asp:Label>
                <asp:Label ID="txtSaldoCompro" runat="server" Text="Saldo"></asp:Label>
            </div>
            <br />
            <div>
                <asp:Label ID="Label5" runat="server" Text="Monto: $"></asp:Label>
                <asp:TextBox ID="txtMonto" runat="server"></asp:TextBox>
            </div>
            <br />
            <div>
                &nbsp;<asp:Button ID="btnCargarConcepto" runat="server" OnClick="btnCargarConcepto_Click" Text="Cargar Concepto" Height="43px" Width="148px" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black" />
            </div>
            <br />
            <div>
                <asp:Label ID="Label4" runat="server" Text="Concepto:"></asp:Label>
                <asp:TextBox ID="txtConcepto" runat="server" Width="700px"></asp:TextBox>
            </div>
        </div>
        <br />
        <div>
            &nbsp;<asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" Height="42px" Width="119px" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black" />
        </div>
    </center>
</asp:Content>
