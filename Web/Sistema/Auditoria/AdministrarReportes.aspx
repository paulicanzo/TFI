<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BackEnd.master"  CodeBehind="AdministrarReportes.aspx.cs" Inherits="Web.Sistema.Auditoria.AdministrarReportes" %>


<asp:Content ID="s" runat="server" ContentPlaceHolderID="cuerpo">
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
        <br />
        <br />
        <div>
            <h3>Reportes</h3>
            <asp:Button ID="ButtonListadoProdMasVend" runat="server" Text="Listado de Productos mas Vendidos" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="ButtonListadoProdMasVend_Click" BorderColor="Black" Width="282px" />
            &nbsp;<asp:Button ID="btnListaPorod" runat="server" Text="Listado de Productos" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="btnListaPorod_Click" BorderColor="Black" Width="188px"/>
            &nbsp;<asp:Button ID="ButtonDeudores" runat="server" Text="Listado de Mayores Deudores" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="ButtonDeudores_Click" BorderColor="Black" Width="245px"/>
            &nbsp;<asp:Button ID="ButtonCompradores" runat="server" Text="Listado de Mayores Compradores" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="ButtonCompradores_Click" BorderColor="Black" Width="258px"/>
&nbsp;            <asp:Button ID="BtnCompras" runat="server" Text="Compras Mensuales" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="BtnCompras_Click" BorderColor="Black"/>
            <%--<asp:Button ID="ButtonHabilotar" runat="server" Text="Habilitar/Deshabilitar" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="ButtonConsultar_Click" BorderColor="Black"/>--%>
        </div>
    </center>
</asp:Content>

