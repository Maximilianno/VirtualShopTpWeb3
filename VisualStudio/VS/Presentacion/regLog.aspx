<%@ Page Title="" Language="C#" MasterPageFile="~/VS/VisualStudio.Master" AutoEventWireup="true" CodeBehind="regLog.aspx.cs" Inherits="VisualStudio.VS.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" >
   
     <link rel="stylesheet" id="regLog" type="text/css" href="../style/regLog.css"/>
   
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="division">
        <p class="title">Registraci&oacuten</p>
         <div runat = "server" class="controlers">
        
        <div id = "dvMessage" runat = "server"></div>

        <div runat = "server" class="oneControl">
            <asp:Label ID="lblRazonSocial" runat="server" Text="Razon Social:"></asp:Label>
            <asp:TextBox ID="txtbxRazonSocial" MaxLength="50" runat="server"></asp:TextBox>
        </div>

        <asp:RequiredFieldValidator ID="rfvRazonSocial" ValidationGroup = "tienda" runat="server" ErrorMessage="* Ingrese su Razon Social" ControlToValidate="txtbxRazonSocial" Display="Dynamic" Font-Size="X-Small"></asp:RequiredFieldValidator>

        <div runat = "server" class="oneControl">
            <asp:Label ID="lblCUIT" runat="server" Text="CUIT:"></asp:Label>
            <asp:TextBox ID="txtbxCUIT" MaxLength="15" runat="server"></asp:TextBox>
        </div>

        <asp:RequiredFieldValidator ID="rfvCUIT" runat="server" ValidationGroup = "tienda" ErrorMessage="* Ingrese su CUIT" ControlToValidate="txtbxCUIT" Display="Dynamic" Font-Size="X-Small"></asp:RequiredFieldValidator>

        <div runat = "server" class="oneControl">
            <asp:Label ID="lblMail" runat="server" Text="Mail:"></asp:Label>
            <asp:TextBox ID="txtbxMail" MaxLength="100" runat="server"></asp:TextBox>
        </div>

            <asp:RequiredFieldValidator ID="rfvMAIL" runat="server" ValidationGroup = "tienda" ErrorMessage="* Ingrese su Mail" Display="Dynamic" Font-Size="X-Small" ControlToValidate="txtbxMail"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="reMail" runat="server" ValidationGroup = "tienda" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"  Display="Dynamic" Font-Size="X-Small" ControlToValidate="txtbxMail" ErrorMessage="Su mail ah sido ingresado incorrectamente"></asp:RegularExpressionValidator>
        
        <div runat ="server"  class="oneControl">
            <asp:Label ID="lblContrasena" runat="server" Text="Contraseña:" ></asp:Label>
            <asp:TextBox ID="txtbxContrasena" runat="server" MaxLength="8" TextMode="Password"></asp:TextBox>
         </div>

         <asp:RequiredFieldValidator ID="rfvContrasena" runat="server" ValidationGroup = "tienda" ErrorMessage="* Ingrese su Contraseña" Display="Dynamic" Font-Size="X-Small" ControlToValidate="txtbxContrasena"></asp:RequiredFieldValidator>

         <div runat ="server" class="oneControl">
                <asp:Label ID="lblRepeatContrasena" runat="server" Text="Repetir Contraseña:"></asp:Label>
                <asp:TextBox ID="txtbxRepeatContrasena" MaxLength="8" runat="server" TextMode="Password"></asp:TextBox>
         </div>

            <asp:CompareValidator ID="cvContrasena" runat="server" ValidationGroup = "tienda" ErrorMessage="* Su Contraseña no es valida" Display="Dynamic" Font-Size="X-Small" ControlToValidate="txtbxContrasena"
            ControlToCompare="txtbxRepeatContrasena"></asp:CompareValidator>

                <div runat ="server"  class="oneControl">
                    <asp:Image ID="imgCaptcha" runat="server"  CssClass="captcha" ImageUrl="~/VS/captcha/captcha.aspx"  />
                    <asp:Label ID="lblmessage" runat="server" CssClass="mgerror" ></asp:Label>
                    <asp:TextBox ID="txtbxCaptcha" MaxLength="5" runat="server" ></asp:TextBox>
                </div>
                
                <asp:RequiredFieldValidator ID="rfvCaptcha" runat="server" ValidationGroup = "tienda" ErrorMessage="* Ingrese el numero de Captcha." Display="Dynamic" Font-Size="X-Small" ControlToValidate="txtbxCaptcha"></asp:RequiredFieldValidator>
            
            <div class="oneControl">
                <div>
                    <asp:FileUpload ID="fuTiendaImg" runat="server" />
                </div>
                
                <div>
                    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                </div>
            </div>

                    &nbsp;
                <div class="oneControl"><asp:Button ID="btnRegistrar" ValidationGroup = "tienda" runat="server" Text="Registrar"  onclick="Button1_Click" /></div>
           
           </div>
        </div>   

    <asp:Image ID="Image2" runat="server" ImageUrl="~/VS/img/vsOpaco copy.jpg" CssClass="imgBackgroud"/>

</asp:Content>
