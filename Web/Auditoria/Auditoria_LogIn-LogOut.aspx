<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BackEnd.master" CodeBehind="Auditoria_LogIn-LogOut.aspx.cs" Inherits="Web.Auditoria.Auditoria_LogIn_LogOut" %>

<asp:Content ID="s" ContentPlaceHolderID="cuerpo" runat="server">

    <center>
        <div>
            <br />
            <br />
            <br />
            <br />
            <div class="container">
                <h4>LogIn - LogOut</h4>
                <div>
                    <asp:GridView ID="LogGV" CssClass="table table-bordered table-hover table-condensed" runat="server" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="LogGV_PageIndexChanging" OnSelectedIndexChanged="LogGV_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White"/>
                        <Columns>
                            <asp:BoundField AccessibleHeaderText="Fecha" DataField="Fecha" HeaderText="Fecha y Hora" />
                            <asp:BoundField AccessibleHeaderText="Usuario" DataField="Usuario" HeaderText="Usuario" />
                            <asp:BoundField AccessibleHeaderText="Operacion" DataField="Operacion" HeaderText="Operacion" />
                            <asp:BoundField AccessibleHeaderText="Equipo" DataField="Equipo" HeaderText="Equipo" />
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <HeaderStyle BackColor="#000084" Font-Bold="true" ForeColor="White" />
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
        </div>
    </center>

</asp:Content>
