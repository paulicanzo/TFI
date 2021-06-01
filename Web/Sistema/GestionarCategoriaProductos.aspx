<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BackEnd.master" CodeBehind="GestionarCategoriaProductos.aspx.cs" Inherits="Web.Sistema.GestionarCategoriaProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cuerpo" runat="server">
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
        <div class="container">
            <div>
                <h4>Gestionar Categoria Producto</h4>
                <div>
                    <asp:TextBox ID="txtNombre" Placeholder="Nombre" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <br />
                <div>
                    <asp:TextBox ID="txtDescripcion" Placeholder="Descripcion" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <br />
                <div class="table tab-content table-bordered table-condensed">
                    <asp:Button ID="Aceptar" runat="server" Text="Aceptar" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="Aceptar_Click" BorderColor="Black" />
                    &nbsp;<asp:Button ID="Cancelar" runat="server" Text="Cancelar" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="Cancelar_Click" BorderColor="Black" />
                </div>
            </div>
        </div>
    </center>
</asp:Content>
