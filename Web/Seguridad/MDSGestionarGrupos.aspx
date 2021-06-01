<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BackEnd.master" CodeBehind="MDSGestionarGrupos.aspx.cs" Inherits="Web.Seguridad.MDSGestionarGrupos" %>

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
                <h3>Gestionar Grupos</h3>
                <div>
                    <asp:GridView ID="gvGrupos" CssClass="table table-bordered table-hover table-condensed" runat="server" AutoGenerateColumns="false" AutoGenerateSelectButton="true" CellPadding="3" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" OnSelectedIndexChanged="gvGrupos_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <Columns>
                            <asp:BoundField AccessibleHeaderText="Nombre" DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField AccessibleHeaderText="Descripcion" DataField="Descripcion" HeaderText="Descripcion" />
                            <asp:CheckBoxField AccessibleHeaderText="Estado" DataField="Estado" HeaderText="Estado" />
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
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" BorderColor="Black" OnClick="btnAgregar_Click" />
                    &nbsp;<asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="btnModificar_Click" BorderColor="Black"/>
                    &nbsp;<asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="btnEliminar_Click" BorderColor="Black"/>
                    &nbsp;<asp:Button ID="btnHabilitar" runat="server" Text="Habilitar/Deshabilitar" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="btnConsultar_Click" BorderColor="Black"/>
                </div>
            </div>
        </div>
    </center>
</asp:Content>
