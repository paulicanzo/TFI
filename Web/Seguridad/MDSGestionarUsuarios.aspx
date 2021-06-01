<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BackEnd.master" CodeBehind="MDSGestionarUsuarios.aspx.cs" Inherits="Web.Seguridad.MDSGestionarUsuarios" %>

<asp:Content ID="Conte" ContentPlaceHolderID="cuerpo" runat="server">

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
                <h3>Gestionar Usuarios</h3>
                <div id="Busqueda">
                    <asp:TextBox ID="txtFiltrar" runat="server" Placeholder="Filtro"></asp:TextBox>
                    &nbsp;<asp:Button ID="btnBuscar" runat="server" Text="Filtrar" Height="43px" CssClass="btn btn-info" BackColor="#000065" BorderColor="Black" ForeColor="White" OnClick="btnBuscar_Click" Width="145px" />
                    &nbsp;<asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Height="43px" CssClass="btn btn-info" BackColor="#000065" BorderColor="Black" ForeColor="White" OnClick="btnCancelar_Click" Width="145px" />
                    &nbsp;
                </div>
                <br />
                <div>
                    <asp:GridView ID="gvUsuarios" CssClass="table table-bordered table-hover table-condensed" runat="server" AutoGenerateColumns="false" AutoGenerateSelectButton="true" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gvUsuarios_PageIndexChanging" OnSelectedIndexChanged="gvUsuarios_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField AccessibleHeaderText="Nombre" DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField AccessibleHeaderText="NombreUsuario" DataField="NombreUsuario" HeaderText="NombreUsuario" />
                            <asp:BoundField AccessibleHeaderText="CorreoElectronico" DataField="CorreoElectronico" HeaderText="Correo Electronico" />
                            <asp:CheckBoxField DataField="Estado" HeaderText="Estado">
                            </asp:CheckBoxField>
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
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="btnAgregar_Click" BorderColor="Black" />
                    &nbsp;<asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="btnModificar_Click" BorderColor="Black" />
                    &nbsp;<asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="btnEliminar_Click" BorderColor="Black" />
                    &nbsp;<asp:Button ID="btnHabilitar" runat="server" Text="Habilitar/Deshabilitar" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="btnHabilitar_Click" BorderColor="Black" />
                    &nbsp;<asp:Button ID="btnResetear" runat="server" Text="Resetear Clave" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="btnResetear_Click" BorderColor="Black" />
                </div>
            </div>
        </div>
    </center>

</asp:Content>
