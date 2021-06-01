<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BackEnd.master" CodeBehind="MDSCambiarClave.aspx.cs" Inherits="Web.Seguridad.MDSCambiarClave" %>

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
        <div id="ABM">
            <center><h3>Cambiar Contraseña</h3></center>
            <asp:Label ID="Label2" runat="server" Text="Nombre de Usuario"></asp:Label>
            &nbsp; <asp:TextBox ID="txtUsuario" runat="server" Enabled="false"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Contraseña actual: "></asp:Label>
            &nbsp;<asp:TextBox ID="txtPassActual" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Contraseña nueva: "></asp:Label>
            &nbsp;<asp:TextBox ID="txtPassNueva" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Confirmar contraseña: "></asp:Label>
            &nbsp;<asp:TextBox ID="ConfirPass" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            &nbsp;
            <div class="table tab-content table-bordered table-condensed">
                <asp:Button ID="Aceptar" runat="server" Text="Aceptar" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="Aceptar_Click" BorderColor="Black" />
                <asp:Button ID="Cancelar" runat="server" Text="Cancelar" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="Cancelar_Click" BorderColor="Black" />
            </div>
        </div>
    </center>
</asp:Content>
