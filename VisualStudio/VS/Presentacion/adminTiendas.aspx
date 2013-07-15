<%@ Page Title="" Language="C#" MasterPageFile="~/VS/VisualStudio.Master" AutoEventWireup="true" CodeBehind="adminTiendas.aspx.cs" Inherits="VisualStudio.VS.Presentacion.adminTiendas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="registracion" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
Mediante el siguiente listado prodrá habilitar, o deshabilitar las tiendas.

<asp:GridView ID="GrdVwTiendas" AutoGenerateColumns="false" runat="server" 
        onrowdatabound="GrdVwTiendas_RowDataBound">
    <Columns>
        <asp:BoundField DataField="Id"          HeaderText="Id" Visible="false"/>
        <asp:BoundField DataField="CUIT"        HeaderText="C.U.I.T." />
        <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" />
        <asp:TemplateField HeaderText="Estado">
            <HeaderTemplate>Estado</HeaderTemplate>
            <ItemTemplate>
                <asp:DropDownList ID="ComboEstado" runat="server" Width="120px"></asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

</asp:Content>

