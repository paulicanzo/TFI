<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BackEnd.master" CodeBehind="MDSGestionarUsuario.aspx.cs" Inherits="Web.Seguridad.MDSGestionarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cuerpo" runat="server">

    <center>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <div class="container">
            <div>
                <h4>Gestionar Usuarios</h4>
                <div>
                    <asp:TextBox ID="txtNombreUsuario" Placeholder="UserName" CssClass="form-control" runat="server" Width="200px"></asp:TextBox>
                </div>
                <br />
                <div>
                    <asp:TextBox ID="txtNombre" Placeholder="Nombre" CssClass="form-control" runat="server" Width="200px"></asp:TextBox>
                </div>
                <br />
                <div>
                    <asp:TextBox ID="txtApellido" Placeholder="Apellido" CssClass="form-control" runat="server" Width="200px"></asp:TextBox>
                </div>
                <br />
                <div>
                    <asp:TextBox ID="txtCorreoElectronico" Placeholder="Correo electronico" CssClass="form-control" runat="server" Width="200px"></asp:TextBox>
                </div>
                <br />

                <div>
                    <asp:DropDownList ID="ddlGrupos" runat="server" Height="35px" Width="200px" OnSelectedIndexChanged="ddlGrupos_SelectedIndexChanged" ForeColor="Black"></asp:DropDownList>
                    <br />
                    <asp:Button ID="Asignar" runat="server" Width="85px" Text="Asignar" CssClass="btn btn-info" BackColor="#990000" ForeColor="White" OnClick="Asignar_Click" BorderColor="Black" />
                    <asp:Button ID="Quitar" runat="server" Width="85px" Text="Quuitar" CssClass="btn btn-info" BackColor="#990000" ForeColor="White" OnClick="Quitar_Click" BorderColor="Black" />
                <div>
                    <asp:Label ID="Label1" runat="server" Text="Grupos"></asp:Label>
                </div>
                    <div>
                        <asp:ListBox ID="lbGrupos" CssClass="form-control" runat="server" Width="200px" ForeColor="Black" OnSelectedIndexChanged="lbGrupos_SelectedIndexChanged"></asp:ListBox>
                    </div>
                </div>
                <br />
                <div class="table tab-content table-bordered table-condensed">
                    <asp:Button ID="btnAceptarUsuario" runat="server" Text="Aceptar" CssClass="btn btn-info" BackColor="#990000" ForeColor="White" OnClick="btnAceptarUsuario_Click" BorderColor="Black" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-info" BackColor="#990000" ForeColor="White" OnClick="btnCancelar_Click" BorderColor="Black" />
                </div>
            </div>
        </div>
    </center>

</asp:Content>