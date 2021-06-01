<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BackEnd.master" CodeBehind="GestionarProveedor.aspx.cs" Inherits="Web.Sistema.GestionarProveedor" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cuerpo" runat="server">
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
          <h3>Gestionar Proveedor</h3>
        <div id="ABM">            
                <asp:Label ID="Label1" runat="server" Text="Denominacion Legal" Style="position: relative" 
                    Enabled="False" Visible="False"></asp:Label>
                &nbsp;<asp:TextBox ID="txtDenominacion" runat="server" Width="142px" 
                    Enabled="False" Visible="False"></asp:TextBox><br />
                &nbsp;<br />
                <asp:Label ID="Label2" runat="server" Text="Cuit" Style="position: relative"></asp:Label>
                &nbsp;<asp:TextBox ID="txtCuit" runat="server" Width="165px"></asp:TextBox><br />
                &nbsp;<br />
                <asp:Label ID="Label4" runat="server" Text="Titular"></asp:Label>
                &nbsp;<asp:TextBox ID="txtTitular" runat="server" Width="152px"></asp:TextBox><br />
                &nbsp;&nbsp;<br />
                <asp:Label ID="Label6" runat="server" Text="Dirección" ToolTip=" "></asp:Label>
                &nbsp;<asp:TextBox ID="txtDireccion" runat="server" Width="152px"></asp:TextBox><br />
                &nbsp;<br />                
                        <asp:Label ID="Label7" runat="server" Text="Provincia"></asp:Label>
                        &nbsp;<asp:DropDownList ID="ddlProvincia" runat="server" Height="17px" Width="170px"
                            AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged" ForeColor="Black">
                            <asp:ListItem Text="--Seleccionar Provincia--" Value=""></asp:ListItem>
                        </asp:DropDownList><br />
                        <br />
                        <asp:Label ID="Label8" runat="server" Text="Localidad"></asp:Label>
                        &nbsp;<asp:DropDownList ID="ddlCiudad" runat="server" Height="16px" Width="159px"
                            AutoPostBack="True" ForeColor="Black">
                            <asp:ListItem Text="--Seleccionar Ciudad--" Value=""></asp:ListItem>
                        </asp:DropDownList> <br />               
                        <br />
                        <asp:Label ID="Label3" runat="server" Text="Categoria IVA"></asp:Label>
                        &nbsp;<asp:DropDownList ID="ddIVA" runat="server" Height="17px" Width="170px"
                            AutoPostBack="True" OnSelectedIndexChanged="ddIVA_SelectedIndexChanged" ForeColor="Black">
                            <asp:ListItem Text="--Seleccionar Categoria--" Value=""></asp:ListItem></asp:DropDownList><br />
                   <br />
                <asp:Label ID="Label9" runat="server" Text="Codigo postal"></asp:Label>
                &nbsp;<asp:TextBox ID="txtCodPostal" runat="server" MaxLength="9999"></asp:TextBox><br />
                <br />
                <asp:Label ID="Label10" runat="server" Text="Telefono"></asp:Label>
                &nbsp;<asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox><br />
                <br />
                <asp:Label ID="Label11" runat="server" Text="Encargado"></asp:Label>
                &nbsp;<asp:TextBox ID="txtEncargado" runat="server"></asp:TextBox><br />
                <br />
                <asp:Label ID="Label12" runat="server" Text="Ingresos Brutos"></asp:Label>
                &nbsp;<asp:TextBox ID="txtIngresosBrutos" runat="server"></asp:TextBox><br />
                <br />
                <asp:Label ID="Label13" runat="server" Text="Email"></asp:Label>
                &nbsp;<asp:TextBox ID="txtEmail" runat="server" Width="230px"></asp:TextBox>
                <br />
                &nbsp;<div>
                    <asp:Label ID="Label5" runat="server" Text="Condiciones de Pago:"></asp:Label><br />
                    <asp:ListBox ID="lbCondiciones" runat="server" CssClass="form-control" ForeColor="Black" OnSelectedIndexChanged="lbCondiciones_SelectedIndexChanged" Width="200px"></asp:ListBox><br />
                    <br />
                    <asp:Button ID="Asignar" runat="server" BackColor="#000065" BorderColor="Black" CssClass="btn btn-info" ForeColor="White" OnClick="Asignar_Click" Text="Asignar" Width="85px" />
                    &nbsp;&nbsp;<asp:Button ID="Quitar" runat="server" BackColor="#000065" BorderColor="Black" CssClass="btn btn-info" ForeColor="White" OnClick="Quitar_Click" Text="Quitar" Width="76px" /><br />
                    <br />
                    <div>
                        <asp:Label ID="Label14" runat="server" Text="Lista de Condiciones de Pagos"></asp:Label>
                    </div>
                    <div>
                        <asp:ListBox ID="lbTodasCondiciones" runat="server" CssClass="form-control" ForeColor="Black" OnSelectedIndexChanged="lbTodasCondiciones_SelectedIndexChanged" Width="200px"></asp:ListBox>
                    </div>
                </div>
          </div>
          <br></br>
          <div>
              <asp:Button ID="BtnGuardar" runat="server" Width="96px" Text="Gruardar" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="BtnGuardar_Click1" BorderColor="Black" />
              <asp:Button ID="BtnCancelar" runat="server" Width="96px" Text="Cancelar" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="BtnCancelar_Click1" BorderColor="Black" />
          </div>
    </center>            
</asp:Content>