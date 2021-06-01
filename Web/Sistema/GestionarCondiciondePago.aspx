<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BackEnd.master" CodeBehind="GestionarCondiciondePago.aspx.cs" Inherits="Web.Sistema.GestionarCondiciondePago" %>

<asp:Content>
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
    <center>
        <div class="container">
            <div>
                <h4>Gestionar Condicion de Pago</h4>
                <div>
                    <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
                    <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <br />
                <div>
                    <asp:Label ID="Label2" runat="server" Text="Descripcion"></asp:Label>
                    <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <br />
                <div>
                     <asp:Button ID="Aceptar" runat="server" Text="Aceptar" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="Aceptar_Click" BorderColor="Black"/>
                     <asp:Button ID="Cancelar" runat="server" Text="Cancelar" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="Cancelar_Click" BorderColor="Black"/>
                </div>
            </div>
        </div>
    </center>
</asp:Content>
