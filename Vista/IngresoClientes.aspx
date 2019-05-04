<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IngresoClientes.aspx.cs" Inherits="Vista.IngresoClientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .dot-label {
            font-weight: bold;
            font-size: 20px;
        }

        .note .x-form-item {
            margin-bottom: 0px;
        }

        .note .x-form-display-field {
            color: gray;
            padding-top: 0px;
            padding-left: 105px;
            margin-bottom: 5px;
        }

        .contenedor {
            position: absolute;
            left: 50%;
            top: 48%;
            transform: translate(-50%, -50%);
            -webkit-transform: translate(-50%, -50%);
        }
    </style>
    <script type="text/javascript">
        function focuscontrol() {
            App.direct.mostrarBotonGuardar();
        }
    </script>
</head>
<body>
    <div class="contenedor">
        <ext:ResourceManager runat="server" ID="rmClientes"/>
        <ext:FormPanel
            ID="FormPanel1"
            runat="server"
            Title="INGRESO DE CLIENTES 2"
            Width="1150"
            BodyPadding="10"
            DefaultAnchor="100%">
            <Items>

                <ext:FieldContainer
                    runat="server"
                    MsgTarget="Side"
                    CombineErrors="false"
                    Layout="HBoxLayout" LabelWidth="130">
                    <Defaults>
                        <ext:Parameter Name="Flex" Value="1" Mode="Raw" />
                        <ext:Parameter Name="HideLabel" Value="true" Mode="Raw" />
                    </Defaults>
                    <Items>
                        <ext:FieldSet
                            runat="server"
                            Collapsible="false"
                            DefaultAnchor="100%">
                            <Defaults>
                                <ext:Parameter Name="labelWidth" Value="89" Mode="Raw" />
                            </Defaults>
                            <Items>
                                <ext:FieldContainer
                                    runat="server"
                                    MsgTarget="Side"
                                    CombineErrors="false"
                                    Layout="HBoxLayout" LabelWidth="130"
                                    FieldLabel="Nombres">
                                    <Defaults>
                                        <ext:Parameter Name="Flex" Value="1" Mode="Raw" />
                                        <ext:Parameter Name="HideLabel" Value="true" Mode="Raw" />
                                    </Defaults>
                                    <Items>
                                        <ext:TextField ID="txtNombres" runat="server" AllowBlank="false" EnableKeyEvents="true">
                                            <Listeners>
                                                <Tap Handler="focuscontrol();"></Tap>
                                            </Listeners>
                                        </ext:TextField>
                                    </Items>
                                </ext:FieldContainer>
                                                                <ext:FieldContainer
                                    runat="server"
                                    MsgTarget="Side"
                                    CombineErrors="false"
                                    Layout="HBoxLayout" LabelWidth="130"
                                    FieldLabel="Apellidos">
                                    <Defaults>
                                        <ext:Parameter Name="Flex" Value="1" Mode="Raw" />
                                        <ext:Parameter Name="HideLabel" Value="true" Mode="Raw" />
                                    </Defaults>
                                    <Items>
                                        <ext:TextField ID="txtApellidos" runat="server" AllowBlank="false" EnableKeyEvents="true">
                                            <Listeners>
                                                <Tap Handler="focuscontrol();"></Tap>
                                            </Listeners>
                                        </ext:TextField>
                                    </Items>
                                </ext:FieldContainer>

                                <ext:FieldContainer
                                    runat="server"
                                    MsgTarget="Side"
                                    CombineErrors="false"
                                    Layout="HBoxLayout" LabelWidth="130">
                                    <Defaults>
                                        <ext:Parameter Name="Flex" Value="1" Mode="Raw" />
                                        <ext:Parameter Name="HideLabel" Value="true" Mode="Raw" />
                                    </Defaults>
                                    <Items>
                                        <ext:Label runat="server" Text="RUC/CI:"></ext:Label>
                                        <ext:TextField ID="txtRuc" runat="server" MarginSpec="0, 59, 0, 0" AllowBlank="false" EnableKeyEvents="true" MaskRe="/[0-9]/" MaxLength="13" EnforceMaxLength="true">
                                            <Listeners>
                                                <Tap Handler="focuscontrol()" />
                                            </Listeners>
                                        </ext:TextField>
                                        <ext:Label runat="server" Text="Teléfono:" MaxWidth="70"></ext:Label>
                                        <ext:TextField runat="server" ID="txtTelefono" EnableKeyEvents="true" AllowBlank="false">
                                            <Listeners>
                                                <Tap Handler="focuscontrol()" />
                                            </Listeners>
                                        </ext:TextField>
                                    </Items>
                                </ext:FieldContainer>
                                <ext:FieldContainer
                                    runat="server"
                                    MsgTarget="Side"
                                    CombineErrors="false"
                                    Layout="HBoxLayout" LabelWidth="130"
                                    FieldLabel="Dirección">
                                    <Defaults>
                                        <ext:Parameter Name="Flex" Value="1" Mode="Raw" />
                                        <ext:Parameter Name="HideLabel" Value="true" Mode="Raw" />
                                    </Defaults>
                                    <Items>
                                        <ext:TextField runat="server" ID="txtDireccion" EnableKeyEvents="true" AllowBlank="false">
                                            <Listeners>
                                                <Tap Handler="focuscontrol()" />
                                            </Listeners>
                                        </ext:TextField>
                                    </Items>
                                </ext:FieldContainer>

                                <ext:FieldContainer
                                    runat="server"
                                    MsgTarget="Side"
                                    CombineErrors="false"
                                    Layout="HBoxLayout" LabelWidth="130"
                                    FieldLabel="Correo">
                                    <Defaults>
                                        <ext:Parameter Name="Flex" Value="1" Mode="Raw" />
                                        <ext:Parameter Name="HideLabel" Value="true" Mode="Raw" />
                                    </Defaults>
                                    <Items>
                                        <ext:Hidden runat="server" ID="hdnCliId"></ext:Hidden>
                                        <ext:TextField runat="server" ID="txtCorreo" EnableKeyEvents="true" AllowBlank="false">
                                            <Listeners>
                                                <Tap Handler="focuscontrol()" />
                                            </Listeners>
                                        </ext:TextField>
                                    </Items>
                                </ext:FieldContainer>
                                <ext:FieldContainer
                                    runat="server"
                                    MsgTarget="Side"
                                    CombineErrors="false"
                                    Layout="HBoxLayout" LabelWidth="130" Height="188">
                                    <Defaults>
                                        <ext:Parameter Name="Flex" Value="1" Mode="Raw" />
                                        <ext:Parameter Name="HideLabel" Value="true" Mode="Raw" />
                                    </Defaults>
                                    <Items>
                                        <ext:Label ID="lblCoste" runat="server" Text="Estado:" MaxWidth="135"></ext:Label>
                                        <ext:Checkbox ID="chkEstadoCliente" runat="server" >
                                            <Listeners>
                                                <Tap Handler="focuscontrol()"></Tap>
                                            </Listeners>
                                        </ext:Checkbox>
                                    </Items>
                                </ext:FieldContainer>
                                <ext:FieldContainer
                                    runat="server"
                                    MsgTarget="Side"
                                    CombineErrors="false"
                                    Layout="HBoxLayout" Height="76">
                                    <Defaults>
                                        <ext:Parameter Name="Flex" Value="1" Mode="Raw" />
                                        <ext:Parameter Name="HideLabel" Value="true" Mode="Raw" />
                                    </Defaults>
                                    <Items>
                                    </Items>
                                    </ext:FieldContainer>
                            </Items>
                        </ext:FieldSet>
                        <ext:FieldSet
                            runat="server"
                            Collapsible="false"
                            DefaultAnchor="100%"
                            MaxWidth="900"
                            Height="506">
                            <Defaults>
                                <ext:Parameter Name="labelWidth" Value="89" Mode="Raw" />
                            </Defaults>
                            <Items>
                                 <ext:FieldContainer
                                    runat="server"
                                    MsgTarget="Side"
                                    CombineErrors="false"
                                    Layout="HBoxLayout" LabelWidth="130">
                                    <Defaults>
                                        <ext:Parameter Name="Flex" Value="1" Mode="Raw" />
                                        <ext:Parameter Name="HideLabel" Value="true" Mode="Raw" />
                                    </Defaults>
                                    <Items>
                                        <ext:TextField runat="server" ID="txtBuscarPorCiRuc" Note="Buscar por RUC/CI">
                                            <DirectEvents>
                                                <Change OnEvent="txtBuscarPorCiRuc_change"></Change>
                                            </DirectEvents>
                                        </ext:TextField>
                                        <ext:TextField runat="server" ID="txtBuscarPorNombresApellidos" Note="Buscar por Nombres y Apellidos">
                                            <DirectEvents>
                                                <Change OnEvent="txtBuscarPorNombresApellidos_change"></Change>
                                            </DirectEvents>
                                        </ext:TextField>
                                    </Items>
                                </ext:FieldContainer>
                                <ext:GridPanel
                                    ID="gdClientes"
                                    runat="server"
                                    Header="true"
                                    Width="200"
                                    Height="410" Collapsible="true" Title="Lista de Clientes">
                                    <Store>
                                        <ext:Store runat="server" ID="storeClientes">
                                            <Model>
                                                <ext:Model runat="server" IDProperty="ID">
                                                    <Fields>
                                                        <ext:ModelField Name="cli_cedula_ruc" Type="String" />
                                                        <ext:ModelField Name="cli_nombres" Type="String" />
                                                        <ext:ModelField Name="cli_apellidos" Type="String" />
                                                        <ext:ModelField Name="cli_telefono" Type="String" />
                                                    </Fields>
                                                </ext:Model>
                                            </Model>
                                        </ext:Store>
                                    </Store>

                                    <ColumnModel runat="server">
                                        <Columns>
                                            <ext:Column runat="server" Text="RUC/CI" DataIndex="cli_cedula_ruc" Width="35" Flex="1" />
                                            <ext:Column runat="server" Text="Nombres" DataIndex="cli_nombres" Flex="1"/>
                                             <ext:Column runat="server" Text="Apellidos" DataIndex="cli_apellidos" Width="35" Flex="1" />
                                            <ext:Column runat="server" Text="Teléfono" DataIndex="cli_telefono" Flex="1">
                                            </ext:Column>
                                        </Columns>
                                    </ColumnModel>
                                    <DirectEvents>
                                        <ItemClick OnEvent="gdClientes_click">
                                            <ExtraParams>
                                                <ext:Parameter Name="Values" Value="Ext.encode(#{gdClientes}.getRowsValues({selectedOnly:true}))" Mode="Raw" />
                                            </ExtraParams>
                                        </ItemClick>
                                    </DirectEvents>

                                    <%--<Plugins>
                                        <ext:RowEditing runat="server" SaveBtnText="actualizar" CancelBtnText="cancelar">
                                        </ext:RowEditing>
                                    </Plugins>--%>
                                    <BottomBar>
                                        <ext:PagingToolbar runat="server" HideRefresh="true" />
                                    </BottomBar>

                                </ext:GridPanel>
                            </Items>
                        </ext:FieldSet>
                    </Items>
                </ext:FieldContainer>

            </Items>

            <Buttons>

                <ext:Button runat="server" ID="btnNuevoCliente" Text="Nuevo Cliente">
                    <DirectEvents>
                        <Click OnEvent="btnNuevoCliente_click"></Click>
                    </DirectEvents>
                </ext:Button>

                <ext:Button runat="server" ID="btnGuardar" Text="Guardar">
                    <DirectEvents>
                        <Click OnEvent="btnGuardar_click" Before="return #{FormPanel1}.isValid();"></Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnEliminar" runat="server" Text="Eliminar">
                    <DirectEvents>
                        <Click OnEvent="btnEliminar_click"></Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnCancelar" runat="server" Text="Cancelar">
                    <DirectEvents>
                        <Click OnEvent="btnCancelar_click"></Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button1" runat="server" Hidden="true">
                </ext:Button>
            </Buttons>
        </ext:FormPanel>
    </div>
</body>

</html>
