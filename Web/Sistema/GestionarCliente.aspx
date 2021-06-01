<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BackEnd.master" CodeBehind="GestionarCliente.aspx.cs" Inherits="Web.Sistema.GestionarCliente" %>

<asp:Content ID="s" ContentPlaceHolderID="cuerpo" runat="server">
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
        <h3>Gestionar Cliente</h3>
        <div id="ABM">
            <asp:Label ID="Label1" runat="server" Text="Razon Social" style="position:relative" Enabled="false"></asp:Label>
            &nbsp;<asp:TextBox ID="txtRazonSocial" runat="server" Width="142px"></asp:TextBox>
            &nbsp; <br />

            <asp:Label ID="Label2" runat="server" Text="CUIT" style="position:relative"></asp:Label>
            &nbsp;<asp:TextBox ID="txtCUIT" runat="server" Width="165px"></asp:TextBox>
            &nbsp; <br />

            <asp:Label ID="Label4" runat="server" Text="Titular"></asp:Label>
            &nbsp;<asp:TextBox ID="txtTitular" runat="server" Width="152px"></asp:TextBox>
            &nbsp; <br />

            <asp:Label ID="Label6" runat="server" Text="Direccion" ToolTip=" "></asp:Label>
            <asp:TextBox ID="txtDireccion" runat="server" Width="152px"></asp:TextBox>
            &nbsp; <br />

            <asp:Label ID="Label7" runat="server" Text="Provincia"></asp:Label>
            &nbsp;<asp:DropDownList ID="ddlProvincia" runat="server" Height="17px" Width="170px" AutoPostBack="true" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged" ForeColor="Black">
                   <asp:ListItem Text="--Seleccione una provincia--" Value=""></asp:ListItem>
                  </asp:DropDownList> <br />
            <br />

            <asp:Label ID="Label8" runat="server" Text="Localidad"></asp:Label>
            &nbsp;<asp:DropDownList ID="ddlLocalidad" runat="server" Height="16px" Width="159px" AutoPostBack="true" ForeColor="Black" OnSelectedIndexChanged="ddlLocalidad_SelectedIndexChanged">
                   <asp:ListItem Text="--Seleccione una localidad--" Value=""></asp:ListItem>
                  </asp:DropDownList> <br />
            <br />

            <asp:Label ID="Label3" runat="server" Text="Categoria IVA"></asp:Label>
            &nbsp;<asp:DropDownList ID="ddlIVA" runat="server" Height="17px" Width="170px" AutoPostBack="true" OnSelectedIndexChanged="ddlIVA_SelectedIndexChanged" ForeColor="Black">
                    <asp:ListItem Text="--Seleccione una categoria--" Value=""></asp:ListItem>
                  </asp:DropDownList><br />
            <br />

            <asp:Label ID="Label9" runat="server" Text="Codigo Postal"></asp:Label>
            &nbsp;<asp:TextBox ID="txtCodPostal" runat="server" MaxLength="4"></asp:TextBox><br />
            <br />

            <asp:Label ID="Label10" runat="server" Text="Telefono"></asp:Label>
            &nbsp;<asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox><br />
            <br />

            <asp:Label ID="Label13" runat="server" Text="Correo Electronico"></asp:Label>
            &nbsp;<asp:TextBox ID="txtEmail" runat="server" Width="230px"></asp:TextBox>
            <br />
            <br />

            <asp:Label ID="Label5" runat="server" Text="Tipo Cliente"></asp:Label>
            <asp:DropDownList ID="ddlTipo" runat="server" Width="102px" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged" Height="28px" BackColor="White" ForeColor="Black">
                <asp:ListItem>Mayorista</asp:ListItem>
                <asp:ListItem>Minorista</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
        </div>
        <div>
            <asp:Button ID="btnGuardar" runat="server" Width="96px" Text="Guardar" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="btnGuardar_Click" BorderColor="Black" />
            &nbsp;<asp:Button ID="btnCancelar" runat="server" Width="96px" Text="Cancelar" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="btnCancelar_Click" BorderColor="Black" />
        </div>
    </center>
</asp:Content>
