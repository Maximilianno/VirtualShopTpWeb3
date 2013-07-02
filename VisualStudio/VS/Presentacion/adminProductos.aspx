<%@ Page Title="" Language="C#" MasterPageFile="~/VS/VisualStudio.Master" AutoEventWireup="true" CodeBehind="adminProductos.aspx.cs" Inherits="VisualStudio.VS.WebForm5" %>
<%@ Register TagPrefix="uc" TagName="ElegirCategoria" 
    Src="~/VS/userControls/ucElegirCategoria.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" type="text/css" href="../style/adminProductos.css" />
    <link rel="Stylesheet" type="text/css" href="../style/gview.css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="registracion" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    
        <p class="title">Administraci&oacuten De Productos</p>
    
           

             <div class="mgrid">
                 <asp:GridView ID="gvAdmProd" runat="server" AutoGenerateColumns="false" 
                    onrowcancelingedit="gvAdmProd_RowCancelingEdit" 
                    onrowediting="gvAdmProd_RowEditing" onrowupdating="gvAdmProd_RowUpdating" 
                    onrowdeleting="gvAdmProd_RowDeleting" DataKeyNames="Id">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"/>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                        <asp:BoundField DataField="Stock" HeaderText="Stock" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" />
                        <asp:TemplateField HeaderText="Categoria">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlPrueba" runat="server" SelectedValue='<%# Bind("IdCategoria") %>' ToolTip="Categoria">
                                
                                <asp:ListItem Value="1" Text="Accesorios para vehículos"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Animales y Mascotas"></asp:ListItem>
                                <asp:ListItem Value="3" Text="Antigüedades"></asp:ListItem>
                                <asp:ListItem Value="4" Text="Autos, Motos y Otros"></asp:ListItem>
                                <asp:ListItem Value="5" Text="Bebés"></asp:ListItem>
                                <asp:ListItem Value="6" Text="Cámaras y Accesorios"></asp:ListItem>
                                <asp:ListItem Value="7" Text="Celulares y Teléfonos"></asp:ListItem>
                                <asp:ListItem Value="8" Text="Coleccionables y Hobbies"></asp:ListItem>
                                <asp:ListItem Value="9" Text="Computación"></asp:ListItem>
                                <asp:ListItem Value="10" Text="Consolas y Videojuegos"></asp:ListItem>
                                <asp:ListItem Value="11" Text="Deportes y Fitness"></asp:ListItem>
                                <asp:ListItem Value="12" Text="Electrodomésticos y Aires Ac."></asp:ListItem>
                                <asp:ListItem Value="13" Text="Electrónica, Audio y Video"></asp:ListItem>
                                <asp:ListItem Value="14" Text="Entradas para Eventos"></asp:ListItem>
                                <asp:ListItem Value="15" Text="Hogar, Muebles y Jardín"></asp:ListItem>
                                <asp:ListItem Value="16" Text="Industrias y Oficinas"></asp:ListItem>
                                <asp:ListItem Value="17" Text="Inmuebles"></asp:ListItem>
                                <asp:ListItem Value="18" Text="Instrumentos Musicales"></asp:ListItem>
                                <asp:ListItem Value="19" Text="Joyas y Relojes"></asp:ListItem>
                                <asp:ListItem Value="20" Text="Juegos y Juguetes"></asp:ListItem>
                                <asp:ListItem Value="21" Text="Libros, Revistas y Comics"></asp:ListItem>
                                <asp:ListItem Value="22" Text="Música, Películas y Series"></asp:ListItem>
                                <asp:ListItem Value="23" Text="Otras categorías"></asp:ListItem>
                                <asp:ListItem Value="24" Text="Ropa y Accesorios"></asp:ListItem>
                                <asp:ListItem Value="25" Text="Salud y Belleza"></asp:ListItem>
                                <asp:ListItem Value="26" Text="Servicios"></asp:ListItem>
                                
                            </asp:DropDownList>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="true" ButtonType="Image" EditImageUrl="~/VS/img/edit.png"
                        UpdateImageUrl="~/VS/img/Cheeck.png" CancelImageUrl="~/VS/img/Cancel.png" />

                        <asp:CommandField ShowDeleteButton="true" ButtonType="Image" 
                        DeleteImageUrl="~/VS/img/del.png"/>
                        
                     
                    </Columns>
                </asp:GridView>
                 <asp:HiddenField ID="HiddenField1" runat="server" /><br /><br />
                 <asp:Label ID="lblMessage" runat="server" ></asp:Label>

        </div>

            
                <div class="controlers">
                    <asp:Button ID="create" runat="server" Text="Crear" PostBackUrl="~/VS/Presentacion/regModProductos.aspx" />
                    
                </div>
              

        
</asp:Content>
