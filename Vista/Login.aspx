<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vista.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="/resources/css/examples.css" rel="stylesheet" />
</head>
<body>
        <form runat="server">
        <ext:ResourceManager runat="server" >
            <Listeners>
                <DocumentReady Handler="var t = Ext.isGecko ? Ext.getDoc() : Ext.getBody();
                    
                            t.on('keydown', function (e) { App.direct.focusBusqueda(e.getKey()) })" />
            </Listeners>
        </ext:ResourceManager>
            <ext:Image runat="server" ImageUrl="~/assets/images/businees.jpg" ></ext:Image>
        <ext:Window
            ID="Window1"
            runat="server"
            Closable="false"
            Resizable="false"
            Height="200"
            Icon="Lock"
            Title="Login"
            Draggable="false"
            Width="350"
            Modal="true"
            BodyPadding="5"
            Layout="FormLayout">
            <Items>
                <ext:TextField
                    ID="txtUsuario"
                    runat="server"
                    FieldLabel="Username"
                    AllowBlank="false"
                    BlankText="El nombre de usuario es requerido"
                    />
                <ext:TextField
                    ID="txtPassword"
                    runat="server"
                    InputType="Password"
                    FieldLabel="Password"
                    AllowBlank="false"
                    BlankText="El password es requerido"
                    />
            </Items>
            <Buttons>
                <ext:Button ID="btnLogin" runat="server" Text="Login" Icon="Accept">
                    <Listeners>
                        <Click Handler="
                            if (!#{txtUsuario}.validate() || !#{txtPassword}.validate()) {
                                Ext.Msg.alert('Error','El Usuario y el Password son requeridos');
                                // return false to prevent the btnLogin_Click Ajax Click event from firing.
                                return false;
                            }" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnLogin_Click">
                            <EventMask ShowMask="true" Msg="Autenticando..." MinDelay="500" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                
            </Buttons>
        </ext:Window>
    </form>

</body>
</html>
