<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BackEnd.master" CodeBehind="Auditoria_Perfil.aspx.cs" Inherits="Web.Auditoria.Auditoria_Perfil" %>

<asp:Content ID="s" ContentPlaceHolderID="cuerpo" runat="server">

    <center>
        <br />
        <br />
        <br />
        <br />

        <div class="container">
            <h4>Perfil</h4>
            <div>
                <asp:GridView ID="gvPerfil" CssClass="table table-bordered table-hover table-condensed" runat="server" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gvPerfil_PageIndexChanging" OnSelectedIndexChanged="gvPerfil_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField AccessibleHeaderText="Grupo" DataField="Grupo" HeaderText="Grupo" />
                        <asp:BoundField AccessibleHeaderText="Permiso" DataField="Permiso" HeaderText="Permiso" />
                        <asp:BoundField AccessibleHeaderText="Formulario" DataField="Formulario" HeaderText="Formulario" />
                        <asp:BoundField AccessibleHeaderText="Usuario" DataField="Usuario" HeaderText="Usuario" />
                        <asp:BoundField AccessibleHeaderText="Operacion" DataField="Operacion" HeaderText="Operacion" />
                        <asp:BoundField AccessibleHeaderText="Fecha" DataField="Fecha" HeaderText="Fecha" />
                        <asp:BoundField AccessibleHeaderText="Equipo" DataField="Equipo" HeaderText="Equipo" />
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
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-info" BackColor="#990000" ForeColor="White" OnClick="btnAceptar_Click" BorderColor="Black" />
            </div>
        </div>

    </center>

</asp:Content>
