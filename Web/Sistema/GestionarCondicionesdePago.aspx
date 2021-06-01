<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BackEnd.master" CodeBehind="GestionarCondicionesdePago.aspx.cs" Inherits="Web.Sistema.GestionarCondicionesdePago" %>

<asp:Content ID="Cuerpo" ContentPlaceHolderID ="cuerpo" runat="server">
    <center>
        <br />
        <br />
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
                <h3>Gestionar Condiciones de Pago</h3>
                <br />
                <div>
                    <asp:GridView ID="gvCondiciones" CssClass="table table-bordered table-hover table-condensed" runat="server" AutoGenerateColumns="false" AutoGenerateSelectButton="true" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gvCondiciones_PageIndexChanging" OnSelectedIndexChanged="gvCondiciones_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField AccessibleHeaderText="Nombre" DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField AccessibleHeaderText="Descripcion" DataField="Descripcion" HeaderText="Descripcion" />
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
                    <asp:Button ID="ButtonAgregar" runat="server" Text="Agregar" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="ButtonAgregar_Click" BorderColor="Black" />&nbsp&nbsp
                    <asp:Button ID="ButtonEliminar" runat="server" Text="Eliminar" CssClass="btn btn-info" BackColor="#000065" ForeColor="White" OnClick="ButtonEliminar_Click" BorderColor="Black"/>
                </div>
            </div>
        </div>
    </center>
</asp:Content>
