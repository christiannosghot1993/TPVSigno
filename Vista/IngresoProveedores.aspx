<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IngresoProveedores.aspx.cs" Inherits="Vista.IngresoProveedores" %>

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
        <ext:ResourceManager runat="server" ID="rmProveedores"/>
        <ext:FormPanel
            ID="FormPanel1"
            runat="server"
            Title="INGRESO DE PROVEEDORES"
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
                                    FieldLabel="Razón Social">
                                    <Defaults>
                                        <ext:Parameter Name="Flex" Value="1" Mode="Raw" />
                                        <ext:Parameter Name="HideLabel" Value="true" Mode="Raw" />
                                    </Defaults>
                                    <Items>
                                        <ext:Hidden runat="server" ID="hdnProvId"></ext:Hidden>
                                        <ext:TextField ID="txtRazonSocial" runat="server" AllowBlank="false" EnableKeyEvents="true">
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
                                        <ext:Label runat="server" Text="RUC:"></ext:Label>
                                        <ext:TextField ID="txtRuc" runat="server" MarginSpec="0, 59, 0, 0" AllowBlank="false" EnableKeyEvents="true" MaskRe="/[0-9]/" MaxLength="13" EnforceMaxLength="true">
                                            <Listeners>
                                                <Tap Handler="focuscontrol()" />
                                            </Listeners>
                                        </ext:TextField>
                                        <ext:Label runat="server" Text="Teléfono:" MaxWidth="70"></ext:Label>
                                        <ext:TextField runat="server" ID="txtTelefono" EnableKeyEvents="true">
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
                                        <ext:TextField runat="server" ID="txtDireccion" EnableKeyEvents="true">
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
                                        <ext:TextField runat="server" ID="txtCorreo" EnableKeyEvents="true">
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
                                    FieldLabel="Página Web">
                                    <Defaults>
                                        <ext:Parameter Name="Flex" Value="1" Mode="Raw" />
                                        <ext:Parameter Name="HideLabel" Value="true" Mode="Raw" />
                                    </Defaults>
                                    <Items>
                                        <ext:TextField runat="server" ID="txtPaginaWeb" EnableKeyEvents="true">
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
                                    Layout="HBoxLayout" LabelWidth="130" Height="210">
                                    <Defaults>
                                        <ext:Parameter Name="Flex" Value="1" Mode="Raw" />
                                        <ext:Parameter Name="HideLabel" Value="true" Mode="Raw" />
                                    </Defaults>
                                    <Items>
                                        <ext:Label ID="lblCoste" runat="server" Text="Estado:" MaxWidth="135"></ext:Label>
                                        <ext:Checkbox ID="chkEstadoProveedor" runat="server" >
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
                                    Layout="HBoxLayout" Height="56">
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
                            Height="508">
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
                                        <ext:TextField runat="server" ID="txtBuscarPorRuc" Note="Buscar por RUC">
                                            <DirectEvents>
                                                <Change OnEvent="txtBuscarPorRuc_change"></Change>
                                            </DirectEvents>
                                        </ext:TextField>
                                        <ext:TextField runat="server" ID="txtBuscarPorRazonSocial" Note="Buscar por Razón Social">
                                            <DirectEvents>
                                                <Change OnEvent="txtBuscarPorRazonSocial_change"></Change>
                                            </DirectEvents>
                                        </ext:TextField>
                                    </Items>
                                </ext:FieldContainer>
                                <ext:GridPanel
                                    ID="gdProveedores"
                                    runat="server"
                                    Header="true"
                                    Width="200"
                                    Height="430" Collapsible="true" Title="Lista de Proveedores">
                                    <Store>
                                        <ext:Store runat="server" ID="storeProveedores">
                                            <Model>
                                                <ext:Model runat="server" IDProperty="ID">
                                                    <Fields>
                                                        <ext:ModelField Name="prv_ruc" Type="String" />
                                                        <ext:ModelField Name="prv_razon_social" Type="String" />
                                                        <ext:ModelField Name="prv_estado" Type="String" />
                                                    </Fields>
                                                </ext:Model>
                                            </Model>
                                        </ext:Store>
                                    </Store>

                                    <ColumnModel runat="server">
                                        <Columns>
                                            <ext:Column runat="server" Text="RUC" DataIndex="prv_ruc" Width="35" Flex="1" />
                                            <ext:Column runat="server" Text="Razón Social" DataIndex="prv_razon_social" Flex="1">
                                            </ext:Column>
                                            <ext:Column runat="server" Text="Estado" DataIndex="prv_estado" Flex="1">
                                            </ext:Column>
                                        </Columns>
                                    </ColumnModel>
                                    <DirectEvents>
                                        <ItemClick OnEvent="gdProveedores_click">
                                            <ExtraParams>
                                                <ext:Parameter Name="Values" Value="Ext.encode(#{gdProveedores}.getRowsValues({selectedOnly:true}))" Mode="Raw" />
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

                <ext:Button runat="server" ID="btnNuevoProveedor" Text="Nuevo Proveedor">
                    <DirectEvents>
                        <Click OnEvent="btnNuevoProveedor_click">
                        </Click>
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
            </Buttons>
        </ext:FormPanel>
    </div>
</body>
</html>
