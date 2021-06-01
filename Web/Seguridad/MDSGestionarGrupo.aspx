<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BackEnd.master" CodeBehind="MDSGestionarGrupo.aspx.cs" Inherits="Web.Seguridad.MDSGestionarGrupo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cuerpo" runat="server">
    <br />
    <br />
    <br />
    <center>
        <br />
        <br />
        <br />
        <div class="container">
            <br />
            <br />
            <br />
            <div>
                <h4>Gestionar Grupo</h4>
                <div>
                    <asp:TextBox ID="txtNombre" Placeholder="Nombre" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <br />
                <div>
                    <asp:TextBox ID="txtDescripcion" Placeholder="Descripcion" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <br />
                <div class="table tab-content table-bordered table-condensed">
                    <asp:Button ID="Aceptar" runat="server" Text="Aceptar" CssClass="btn btn-info" BackColor="#000065" BorderColor="Black" ForeColor="White" OnClick="Aceptar_Click" />
                    <asp:Button ID="Cancelar" runat="server" Text="Cancelar" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="Cancelar_Click" BorderColor="Black" />
                </div>
            </div>
        </div>
    </center>
</asp:Content>
