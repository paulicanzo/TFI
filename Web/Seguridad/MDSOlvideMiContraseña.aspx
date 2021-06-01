<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BackEnd.master" CodeBehind="MDSOlvideMiContraseña.aspx.cs" Inherits="Web.Seguridad.MDSOlvideMiContraseña" %>

<asp:Content ID="d" ContentPlaceHolderID="cuerpo" runat="server">
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
            <center><h3>Olvide Mi Contraseña</h3></center>
            <asp:Label ID="Label2" runat="server" Text="Nombre de Usuario"></asp:Label>
            &nbsp;<asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
        </div>
        <br />
        <div class="table tab-content table-bordered table-condensed">
            <asp:Button ID="Aceptar" runat="server" Text="Recueprar" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="Aceptar_Click" BorderColor="Black" />
            <asp:Button ID="Cancelar" runat="server" Text="Cancelar" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="Cancelar_Click" BorderColor="Black" />
        </div>
    </center>
</asp:Content>
