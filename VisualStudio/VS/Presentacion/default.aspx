<%@ Page Title="" Language="C#" MasterPageFile="~/VS/VisualStudio.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="VisualStudio.VS.WebForm3" %>
<%@ Register TagPrefix="uc" TagName="ElegirCategoria" 
    Src="~/VS/userControls/ucElegirCategoria.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../style/index.css"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="registracion" runat="server">
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
        <div class="category">
                  <p class="catLabelControl">Elige la categoria del producto que querieres ver</p>
                 <div>
                  <uc:ElegirCategoria id="ElegirCategoria" 
                    runat="server" />
                 </div>
        </div>

        <div id = "dvTablaTienda" class="shops"></div>
  
    <asp:Label ID="lblLista" runat="server" Text=""></asp:Label>

</asp:Content>
