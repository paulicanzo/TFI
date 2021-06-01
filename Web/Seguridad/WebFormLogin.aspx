<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BackEnd.master" CodeBehind="WebFormLogin.aspx.cs" Inherits="Web.Seguridad.WebFormLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cuerpo" runat="server">
    <link rel="stylesheet" href="StyleSheetLogin.css" type="text/css"/>
    <center>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <div class="login">
            <div class="heading">
                <h2>Ingresar</h2>
                <div action="#">
                    <div class="input-group input-group-lg">
                        <span class="input-group-addon"<i class="fa fa-user"></i></span>
                        <asp:TextBox ID="txtUsuario" type="text" class="form-control" runat="server" placeholder="Nombre Usuario"></asp:TextBox>
                    </div>

                    <div class="input-group input-group-lg">
                        <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                        <asp:TextBox ID="txtContraseña" type="password" class="form-control" runat="server" placeholder="Password"></asp:TextBox>
                    </div>

                    <asp:LinkButton ID="Olvi" runat="server" Text="Olvide mi contraseña" OnClick="Olvi_Click"></asp:LinkButton>
                    <br />
                    <br />

                    <asp:Button runat="server" Text="Aceptar" class="btn btn-default" ID="Aceptar" OnClick="Aceptar_Click1" BackColor="#CCCCCC" Font-Bold="true" ForeColor="Black" Height="46px" Width="119px" Font-Size="Medium" />
                    &nbsp;
                </div>
            </div>
        </div>
    </center>
</asp:Content>
