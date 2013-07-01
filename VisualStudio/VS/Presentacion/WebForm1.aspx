<%@ Page Title="" Language="C#" MasterPageFile="~/VS/VisualStudio.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="VisualStudio.VS.Presentacion.WebForm1" %>
<%@ Register TagPrefix="uc" TagName="ElegirCategoria" 
    Src="~/VS/userControls/ucElegirCategoria.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="registracion" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

<asp:GridView ID="gvPrueba" runat="server" AutoGenerateColumns="false" 
        onrowediting="gvPrueba_RowEditing" onselectedindexchanging="gvPrueba_SelectedIndexChanging"
                    >
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"/>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                        <asp:BoundField DataField="Stock" HeaderText="Stock" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" />
                        
                        <asp:TemplateField HeaderText="Categoria" SortExpression="Categoria"
                        ItemStyle-HorizontalAlign="Center">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlPrueba" runat="server" >
                            <asp:ListItem Text="1" Value="hola"></asp:ListItem>
                            <asp:ListItem Text="2" Value="jeje"></asp:ListItem>
                            <asp:ListItem Text="3" Value="tres"></asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblValor" runat="server" Text='<%# Bind("") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowSelectButton="true" ButtonType="Link"  />
                        <%--<asp:CommandField ShowEditButton="true" ButtonType="Image" EditImageUrl="~/VS/img/edit.png"
                        UpdateImageUrl="~/VS/img/Cheeck.png" CancelImageUrl="~/VS/img/Cancel.png" />--%>

                        <%--<asp:CommandField ShowDeleteButton="true" ButtonType="Image" 
                        DeleteImageUrl="~/VS/img/del.png"/>--%>
                        
                     
                    </Columns>
                </asp:GridView>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
