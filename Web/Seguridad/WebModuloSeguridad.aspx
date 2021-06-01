<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BackEnd.master" CodeBehind="WebModuloSeguridad.aspx.cs" Inherits="Web.Seguridad.WebModuloSeguridad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cuerpo" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <center>
        <h3>Modulo de Seguridad</h3>
        <div>
            <div>
                <asp:Button ID="btnUsu" runat="server" Text="Usuarios" OnClick="btnUsuario_Click" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black" />
                <asp:Button ID="btnGrupos" runat="server" Text="Grupos" OnClick="btnGrupos_Click" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black" />
                <asp:Button ID="btnPerfiles" runat="server" Text="Perfiles" OnClick="btnPerfiles_Click" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black" />
            </div>
        </div>
    </center>
</asp:Content>
