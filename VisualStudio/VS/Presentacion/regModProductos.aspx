<%@ Page Title="" Language="C#" MasterPageFile="~/VS/VisualStudio.Master" AutoEventWireup="true" CodeBehind="regModProductos.aspx.cs" Inherits="VisualStudio.VS.WebForm7" %>
<%@ Register TagPrefix="uc" TagName="ElegirCategoria" 
    Src="~/VS/userControls/ucElegirCategoria.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <link rel="Stylesheet" type="text/css" href="../style/regModProductos.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="registracion" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<div class="division">
        <p class="title">Registraci&oacuten de productos</p>
         <div runat="server" class="controlers">
            
            <div id = "dvMessage" runat = "server"></div>
            
            <div runat="server" class="oneControl">
                <div>
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
                    <asp:TextBox ID="txtbxNombre" MaxLength="50" runat="server"></asp:TextBox>
                </div>
            </div>
            
            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ValidationGroup = "producto" ErrorMessage="* Ingrese Nombre del producto"  Display="Dynamic" Font-Size="X-Small" ControlToValidate="txtbxNombre"></asp:RequiredFieldValidator>
            
            <div  runat="server" class="oneControl">

                <div>
                    <asp:Label ID="lblDescripcion" runat="server" Text="Descripci&oacuten:"></asp:Label>
                    <asp:TextBox ID="txtbxDescripcion" MaxLength="500" TextMode="MultiLine" runat="server"></asp:TextBox>
                </div>

            </div>
            
            <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ValidationGroup = "producto" ErrorMessage="* Ingrese una Descripcion" Display="Dynamic" Font-Size="X-Small" ControlToValidate="txtbxDescripcion"></asp:RequiredFieldValidator>

            <div runat="server" class="oneControl">
                <div>
                    <asp:Label ID="lblStock" runat="server" Text="Cantidad en Stock:"></asp:Label>
                    <asp:TextBox MaxLength="15" ID="txtbxStock" runat="server"></asp:TextBox>
                </div>
            </div>
            <asp:RequiredFieldValidator ID="rfvStock" runat="server" ValidationGroup = "producto" ErrorMessage="* Ingrese una cantidad de Stock" Display="Dynamic" Font-Size="X-Small" ControlToValidate="txtbxStock"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rgStock" runat="server" ValidationGroup = "producto" ControlToValidate="txtbxStock" ErrorMessage="* Ingrese la cantidad correcta." Type="Integer" MaximumValue="10000" MinimumValue="1" Display="Dynamic" Font-Size="X-Small"></asp:RangeValidator>
            
            <div runat="server" class="oneControl">
                <div>
                    <asp:Label ID="lblPrecio" runat="server" Text="Precio:" ></asp:Label>
                    <asp:TextBox ID="txtbxPrecio" MaxLength="15"  runat="server" ></asp:TextBox>
                </div>
            </div>
            <asp:RequiredFieldValidator ID="rfvPrecio" runat="server" ValidationGroup = "producto" ErrorMessage="* Ingrese el precio"   Display="Dynamic" Font-Size="X-Small" ControlToValidate="txtbxPrecio"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rgPrecio" runat="server" ValidationGroup = "producto" ErrorMessage="* Ingrese el precio correctamente." ControlToValidate="txtbxPrecio"  Display="Dynamic" Font-Size="X-Small" Type= "Double" MaximumValue="100000"  MinimumValue="1"></asp:RangeValidator>

            <div runat="server" class="oneControl">
                <div>
                    <asp:Label ID="catelblCategoria" runat="server" Text="Categor&iacutea:"></asp:Label>
                    <asp:DropDownList ID="ddlCategorias" runat="server"></asp:DropDownList>
                </div>
            </div>

             <div runat="server" class="oneControl">
                <div>
                    <asp:FileUpload ID="fuTiendaImg" runat="server" />
                </div>
                <div>
                    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div runat="server" class="controlers">
                <asp:Button ID="create" runat="server" ValidationGroup = "producto" Text="Crear" onclick="create_Click" />
                <asp:Button ID="mod" runat="server" ValidationGroup = "producto" Text="Modificar" />                    
            </div>
            
        </div>
        
    </div>
        <asp:Image ID="Image2" runat="server" ImageUrl="~/VS/img/vsOpaco copy.jpg" cssClass="imgBackgroud"/>
    
</asp:Content>
