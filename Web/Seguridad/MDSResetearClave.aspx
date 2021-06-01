<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="MDSResetearClave.aspx.cs" Inherits="Web.Seguridad.MDSResetearClave" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title></title>
</head>

<body>
    <form id="form1" runat="server">
        <div id="Cliente">
            <fieldset style="top: 0px; left:0px; width:496px">
                <legend><span>Contactos</span></legend>

                <asp:Label ID="Label4" runat="server" Text="Nombre y Apellido: "></asp:Label>
                &nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="202px"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
                &nbsp;<asp:TextBox ID="TextBox2" runat="server" Width="175px"></asp:TextBox>
                <br />
                <br />
                Mensaje:
                <br />
                <asp:TextBox ID="TextBox3" runat="server" Height="98px" TextMode="MultiLine" Width="331px"></asp:TextBox>
                <br />
                <br />
                <asp:ImageButton ID="IBGuardar" runat="server" Height="27px" ImageUrl="~/Imagenes/Botones/Confirmar.png" OnClick="IBGuardar_Click" Width="99px" />
            </fieldset>
        </div>
    </form>
</body>
