<%@ Page Title="" Language="C#" MasterPageFile="~/VS/VisualStudio.Master" AutoEventWireup="true" CodeBehind="administracionDeCompras.aspx.cs" Inherits="VisualStudio.VS.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" type="text/css" href="../style/administracionDeCompras.css" />
    <link rel="Stylesheet" type="text/css" href="../style/gview.css" />
          <link type="text/css" rel="Stylesheet" href="../style/jquery-ui.css" />
          <script type="text/javascript" src="../Script/jquery.min.js" ></script>
          <script type="text/javascript" src="../Script/jquery-ui.min.js"></script>

          <script type="text/javascript">
              $(document).ready(function () {
                  $('#MainContent_txtbxFechaDeCompra').datepicker();
              });
            </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="registracion" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

        <p class="title">Administraci&oacuten De Compras</p>
    <div class="date"> 
    <asp:Label ID="Label4" runat="server" Text="Fecha:"></asp:Label>
     <asp:TextBox ID="txtbxFechaDeCompra" runat="server" 
            ontextchanged="txtbxFechaDeCompra_TextChanged"></asp:TextBox>  
        <asp:Button ID="btnMostrarFecha" runat="server" Text="Button" 
            onclick="btnMostrarFecha_Click" />
    <asp:Label ID="lblMostrarFecha" runat="server" Text=""></asp:Label>
    </div>
    
         <div class="mgrid">
                 <asp:GridView ID="gvAdmCompras" runat="server" AutoGenerateColumns="false" 
        onrowediting="gvAdmCompras_RowEditing" onrowupdating="gvAdmCompras_RowUpdating" 
                     onrowdeleted="gvAdmCompras_RowDeleted" >
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre Producto" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                        <asp:BoundField DataField="EmailComprador" HeaderText="Email del Comprador" />
                        <asp:BoundField DataField="FechaTransaccion" HeaderText="Fecha" />
                        <asp:BoundField DataField="Estado" HeaderText="Estado" />
                        
                        <%--<asp:CommandField ShowEditButton="true" ButtonType="Image" EditImageUrl="~/VS/img/edit.png"
                        UpdateImageUrl="~/VS/img/Cheeck.png" CancelImageUrl="~/VS/img/Cancel.png" />
--%>
                        
                        
                     
                    </Columns>
                </asp:GridView>

                <asp:HiddenField ID="HiddenField1" runat="server" /><br /><br />
        </div>

</asp:Content>
