<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BackEnd.master" CodeBehind="MDSGestionarPerfiles.aspx.cs" Inherits="Web.Seguridad.MDSGestionarPerfiles" %>

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
        <div class="container"></div>
        <h3>Gestionar Perfiles</h3>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Grupo"></asp:Label>
        &nbsp;<asp:DropDownList ID="ddlGrupos" runat="server" Height="16px" Width="141px" ForeColor="Black"></asp:DropDownList>
        &nbsp; &nbsp;
        <asp:Label ID="Label3" runat="server" Text="Formulario"></asp:Label>
        &nbsp;<asp:DropDownList ID="ddlFormularios" runat="server" Height="16px" Width="153px" ForeColor="Black"></asp:DropDownList>
        &nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server" Text="Permiso"></asp:Label>
        &nbsp;<asp:DropDownList ID="ddlPermisos" runat="server" Height="16px" Width="153px" ForeColor="Black"></asp:DropDownList>
        <br />
        <br />
        &nbsp; 
        &nbsp; 
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="Agregar_Click" BorderColor="Black" />
        <br />
        <br />
        <div>
            <asp:GridView ID="gvPerfiles" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None"  Width="100%" AutoGenerateColumns="False" HorizontalAlign="Center" onpageindexchanging="gvPerfiles_PageIndexChanging" onselectedindexchanged="gvPerfiles_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="Grupo" HeaderText="Grupo" SortExpression="Grupo" />
                    <asp:BoundField DataField="Formulario" HeaderText="Formulario" SortExpression="Formulario" />
                    <asp:BoundField DataField="Permiso" HeaderText="Permiso" SortExpression="Permiso" />
                </Columns>
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView>
        </div>
        <div class="table tab-content table-bordered table-condensed">
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-info" BackColor="#000065"  ForeColor="White" OnClick="btnEliminar_Click" BorderColor="Black"/>  
        </div>
    </center>
</asp:Content>
