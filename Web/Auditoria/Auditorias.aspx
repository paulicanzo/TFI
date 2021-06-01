<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BackEnd.master" CodeBehind="Auditorias.aspx.cs" Inherits="Web.Auditoria.Auditorias" %>

<asp:Content ID="s" ContentPlaceHolderID="cuerpo" runat="server">

    <center>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />

        <div>
            <h4>Auditorias</h4>
            <div>
                <asp:Button ID="btnLogInLogOut" runat="server" Text="LogIn-LogOut" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="btnLogInLogOut_Click" BorderColor="Black" />
                &nbsp; <asp:Button ID="btnPerfil" runat="server" Text="Perfil" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="btnPerfil_Click" BorderColor="Black" />
                &nbsp; <asp:Button ID="btnOrden" runat="server" Text="Orden de Compra" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="btnOrden_Click" BorderColor="Black" />
            </div>
        </div>
        <br />

        <div id="LogIng">
            <asp:GridView ID="LogGV" CssClass="table table-bordered table-hover table-condensed" runat="server" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="LogGV_PageIndexChanging" OnSelectedIndexChanged="LogGV_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" />
                   <Columns>
                            <asp:BoundField AccessibleHeaderText="Fecha" DataField="Fecha" HeaderText="Fecha y Hora" />
                            <asp:BoundField AccessibleHeaderText="Usuario" DataField="Usuario" HeaderText="Usuario" />
                            <asp:BoundField AccessibleHeaderText="Operacion" DataField="Operacion" HeaderText="Operacion" />
                            <asp:BoundField AccessibleHeaderText="Equipo" DataField="Equipo" HeaderText="Equipo" />
                    </Columns>  
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
        </div>
        <br />

        <div id="Perfil">
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
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
        </div>
        <br />

        <div id="OC">
            <asp:GridView ID="gvOrden" CssClass="table table-bordered table-hover table-condensed" runat="server" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gvOrden_PageIndexChanging" OnSelectedIndexChanged="gvOrden_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" />
                  <Columns>
                        <asp:BoundField AccessibleHeaderText="NroOrdenCompra" DataField="NroOrdenCompra" HeaderText="Nro Orden" />
                        <asp:BoundField AccessibleHeaderText="Proveedor" DataField="Proveedor" HeaderText="Proveedor" />
                        <asp:BoundField AccessibleHeaderText="CondicionesPago" DataField="CondicionesPago" HeaderText="Condiciones de Pago" />
                        <asp:BoundField AccessibleHeaderText="FechaEmision" DataField="FechaEmision" HeaderText="Fecha Emision" />
                        <asp:BoundField AccessibleHeaderText="Estado" DataField="Estado" HeaderText="Estado" />
                        <asp:BoundField AccessibleHeaderText="Usuario" DataField="Usuario" HeaderText="Usuario" />
                        <asp:BoundField AccessibleHeaderText="Operacion" DataField="Operacion" HeaderText="Operacion" />
                        <asp:BoundField AccessibleHeaderText="Fecha" DataField="Fecha" HeaderText="Fecha" />
                        <asp:BoundField AccessibleHeaderText="Equipo" DataField="Equipo" HeaderText="Equipo" />
                 </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
        </div>
    </center>

</asp:Content>
