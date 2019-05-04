<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Empresa.aspx.cs" Inherits="Vista.Empresa" %>

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
        <ext:ResourceManager runat="server" ID="rmClientes" />
        <ext:FormPanel
            ID="FormPanel1"
            runat="server"
            Title="INGRESO DE EMPRESAS"
            Width="1150"
            BodyPadding="10"
            DefaultAnchor="100%" Height="630">
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
                            DefaultAnchor="100%" Height="520">
                            <Defaults>
                                <ext:Parameter Name="labelWidth" Value="89" Mode="Raw" />
                            </Defaults>
                            <Items>

                                <ext:FieldContainer
                                    runat="server"
                                    MsgTarget="Side"
                                    CombineErrors="false"
                                    Layout="HBoxLayout" LabelWidth="130" FieldLabel="RUC">
                                    <Defaults>
                                        <ext:Parameter Name="Flex" Value="1" Mode="Raw" />
                                        <ext:Parameter Name="HideLabel" Value="true" Mode="Raw" />
                                    </Defaults>
                                    <Items>
                                        <ext:Hidden runat="server" ID="hdnEmpId"></ext:Hidden>
                                        <ext:TextField ID="txtRuc" runat="server" AllowBlank="false" EnableKeyEvents="true" MaskRe="/[0-9]/" MaxLength="13" EnforceMaxLength="true">
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
                                    FieldLabel="Razón Social">
                                    <Defaults>
                                        <ext:Parameter Name="Flex" Value="1" Mode="Raw" />
                                        <ext:Parameter Name="HideLabel" Value="true" Mode="Raw" />
                                    </Defaults>
                                    <Items>
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
                                    Layout="HBoxLayout" LabelWidth="130"
                                    FieldLabel="Nombre Comercial">
                                    <Defaults>
                                        <ext:Parameter Name="Flex" Value="1" Mode="Raw" />
                                        <ext:Parameter Name="HideLabel" Value="true" Mode="Raw" />
                                    </Defaults>
                                    <Items>
                                        <ext:TextField ID="txtNombreComercial" runat="server" AllowBlank="false" EnableKeyEvents="true">
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
                                    FieldLabel="Contribuyente Especial">
                                    <Defaults>
                                        <ext:Parameter Name="Flex" Value="1" Mode="Raw" />
                                        <ext:Parameter Name="HideLabel" Value="true" Mode="Raw" />
                                    </Defaults>
                                    <Items>
                                        <ext:TextField ID="txtContribuyenteEspecial" runat="server" EnableKeyEvents="true" MaskRe="/[0-9]/">
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
                                    FieldLabel="Número Establecimiento">
                                    <Defaults>
                                        <ext:Parameter Name="Flex" Value="1" Mode="Raw" />
                                        <ext:Parameter Name="HideLabel" Value="true" Mode="Raw" />
                                    </Defaults>
                                    <Items>
                                        <ext:TextField runat="server" ID="txtNumeroEstablecimiento" EnableKeyEvents="true" AllowBlank="false" MarginSpec="0, 70, 0, 0" MaskRe="/[0-9]/">
                                            <Listeners>
                                                <Tap Handler="focuscontrol()" />
                                            </Listeners>
                                        </ext:TextField>
                                        <ext:Checkbox runat="server" ID="chkObligadoContabilidad" Note="Obligado Contabilidad">
                                            <Listeners>
                                                <Tap Handler="focuscontrol()" />
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
                            Height="520">
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
                                        <ext:TextField runat="server" ID="txtBuscarPorNombreComercial" Note="Buscar por Nombre Comercial">
                                            <DirectEvents>
                                                <Change OnEvent="txtBuscarPorNombreComercial_change"></Change>
                                            </DirectEvents>
                                        </ext:TextField>
                                    </Items>
                                </ext:FieldContainer>
                                <ext:GridPanel
                                    ID="gdEmpresa"
                                    runat="server"
                                    Header="true"
                                    Width="200"
                                    Height="450" Collapsible="true" Title="Lista de Empresas">
                                    <Store>
                                        <ext:Store runat="server" ID="storeEmpresas">
                                            <Model>
                                                <ext:Model runat="server" IDProperty="ID">
                                                    <Fields>
                                                        <ext:ModelField Name="emp_ruc" Type="String" />
                                                        <ext:ModelField Name="emp_razon_social" Type="String" />
                                                        <ext:ModelField Name="emp_nombre_comercial" Type="String" />
                                                        <ext:ModelField Name="emp_numero_establecimiento" Type="String" />
                                                    </Fields>
                                                </ext:Model>
                                            </Model>
                                        </ext:Store>
                                    </Store>

                                    <ColumnModel runat="server">
                                        <Columns>
                                            <ext:Column runat="server" Text="RUC" DataIndex="emp_ruc" Width="35" Flex="1" />
                                            <ext:Column runat="server" Text="Razón Social" DataIndex="emp_razon_social" Flex="1" />
                                            <ext:Column runat="server" Text="Nombre Comercial" DataIndex="emp_nombre_comercial" Width="35" Flex="1" />
                                            <ext:Column runat="server" Text="Número Establecimiento" DataIndex="emp_numero_establecimiento" Width="35" Flex="1" />
                                        </Columns>
                                    </ColumnModel>
                                    <DirectEvents>
                                        <ItemClick OnEvent="gdEmpresa_click">
                                            <ExtraParams>
                                                <ext:Parameter Name="Values" Value="Ext.encode(#{gdEmpresa}.getRowsValues({selectedOnly:true}))" Mode="Raw" />
                                            </ExtraParams>
                                        </ItemClick>
                                    </DirectEvents>

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

                <ext:Button runat="server" ID="btnNuevaEmpresa" Text="Nueva Empresa">
                    <DirectEvents>
                        <Click OnEvent="btnNuevaEmpresa_click"></Click>
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
