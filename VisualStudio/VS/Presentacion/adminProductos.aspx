<%@ Page Title="" Language="C#" MasterPageFile="~/VS/VisualStudio.Master" AutoEventWireup="true" CodeBehind="adminProductos.aspx.cs" Inherits="VisualStudio.VS.WebForm5" %>
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
                     onrowdeleting="gvAdmProd_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                        <asp:BoundField DataField="Stock" HeaderText="Stock" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" />
                        <asp:BoundField DataField="Categoria" HeaderText="Categoria" />
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
