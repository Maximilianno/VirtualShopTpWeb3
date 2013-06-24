<%@ Control Language="C#"  AutoEventWireup="true" CodeBehind="ucElegirCategoria.ascx.cs" Inherits="VisualStudio.VS.ucElegirCategoria" %>

<asp:DropDownList ID="category" CssClass = "catDDListControl" runat="server" 
                  onselectedindexchanged="Category_SelectedIndexChanged"
                  onChange="Category_SelectedIndexChanged();">
</asp:DropDownList>  