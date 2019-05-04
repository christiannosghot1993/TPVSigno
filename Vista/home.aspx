<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Vista.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .contenedor{
    position: absolute;
    left: 50%;
    top: 48%;
    transform: translate(-50%, -50%);
    -webkit-transform: translate(-50%, -50%);
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="contenedor">
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/assets/images/logo.png" Width="500px" Height="500px"/>
        </div>
    </form>
</body>
</html>
