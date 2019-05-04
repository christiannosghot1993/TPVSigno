<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroPuntoEmision.aspx.cs" Inherits="Vista.RegistroPuntoEmision" %>

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
        <ext:ResourceManager runat="server" ID="rmPuntoEmision" />
        <ext:FormPanel
            ID="FormPanel1"
            runat="server"
            Title="REGISTRO DE PUNTOS DE EMISIÓN"
            Width="1150"
            BodyPadding="10"
            DefaultAnchor="100%" Height="625">
            <Items>

                <ext:FieldContainer
                    runat="server"
                    MsgTarget="Side"
                    CombineErrors="false"
                    Layout="HBoxLayout" LabelWidth="130" >
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
                                    Layout="HBoxLayout" LabelWidth="130"
                                    FieldLabel="Establecimiento">
                                    <Defaults>
                                        <ext:Parameter Name="Flex" Value="1" Mode="Raw" />
                                        <ext:Parameter Name="HideLabel" Value="true" Mode="Raw" />
                                    </Defaults>
                                    <Items>
                                        <ext:Hidden ID="hdnPemId" runat="server"></ext:Hidden>
                                        <ext:ComboBox runat="server" ID="cbxEstablecimiento" Editable="false" ValueField="emp_id" DisplayField="emp_razon_social" AllowBlank="false">
                                            <Store>
                                                <ext:Store runat="server" ID="storeEstablecimiento">
                                                    <Model>
                                                        <ext:Model runat="server">
                                                            <Fields>
                                                                <ext:ModelField Name="emp_id" />
                                                                <ext:ModelField Name="emp_razon_social" />
                                                            </Fields>
                                                        </ext:Model>
                                                    </Model>
                                                </ext:Store>
                                            </Store>
                                            <Listeners>
                                                <Select Handler="focuscontrol();"></Select>
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                </ext:FieldContainer>
                                <ext:FieldContainer
                                    runat="server"
                                    MsgTarget="Side"
                                    CombineErrors="false"
                                    Layout="HBoxLayout" LabelWidth="130"
                                    FieldLabel="Dirección IP">
                                    <Defaults>
                                        <ext:Parameter Name="Flex" Value="1" Mode="Raw" />
                                        <ext:Parameter Name="HideLabel" Value="true" Mode="Raw" />
                                    </Defaults>
                                    <Items>
                                        <ext:TextField runat="server" ID="txtDireccionIP" ReadOnly="true" AllowBlank="false"></ext:TextField>
                                    </Items>
                                </ext:FieldContainer>
                                <ext:FieldContainer
                                    runat="server"
                                    MsgTarget="Side"
                                    CombineErrors="false"
                                    Layout="HBoxLayout" LabelWidth="130"
                                    FieldLabel="Punto Emisión">
                                    <Defaults>
                                        <ext:Parameter Name="Flex" Value="1" Mode="Raw" />
                                        <ext:Parameter Name="HideLabel" Value="true" Mode="Raw" />
                                    </Defaults>
                                    <Items>
                                        <ext:TextField runat="server" ID="txtPuntoEmision" MaskRe="/[0-9]/" AllowBlank="false">
                                             <Listeners>
                                                <Tap Handler="focuscontrol()" />
                                            </Listeners>
                                        </ext:TextField>
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
                                        <ext:TextField runat="server" ID="txtBuscarPorEstablecimiento" Note="Buscar por Establecimiento" MaxWidth="250">
                                            <DirectEvents>
                                                <Change OnEvent="txtBuscarPorEstablecimiento_change"></Change>
                                            </DirectEvents>
                                        </ext:TextField>
                                        <ext:TextField runat="server" ID="txtBuscarPorDireccionIp" Note="Buscar por Dirección IP" MaxWidth="250">
                                            <DirectEvents>
                                                <Change OnEvent="txtBuscarPorDireccionIp_change"></Change>
                                            </DirectEvents>
                                        </ext:TextField>
                                        <ext:TextField runat="server" ID="txtBuscarPorPuntoEmision" Note="Buscar por Punto de Emisión" MaxWidth="250">
                                            <DirectEvents>
                                                <Change OnEvent="txtBuscarPorPuntoEmision_change"></Change>
                                            </DirectEvents>
                                        </ext:TextField>
                                    </Items>
                                </ext:FieldContainer>
                                <ext:GridPanel
                                    ID="gdPuntoEmision"
                                    runat="server"
                                    Header="true"
                                    Width="650"
                                    Height="450" Collapsible="true" Title="Lista de Puntos de Emisión">
                                    <Store>
                                        <ext:Store runat="server" ID="storePuntoEmision">
                                            <Model>
                                                <ext:Model runat="server" IDProperty="ID">
                                                    <Fields>
                                                        <ext:ModelField Name="pem_emp_id" Type="String" />
                                                        <ext:ModelField Name="pem_direccion_ip" Type="String" />
                                                        <ext:ModelField Name="pem_punto_emision" Type="String" />
                                                    </Fields>
                                                </ext:Model>
                                            </Model>
                                        </ext:Store>
                                    </Store>

                                    <ColumnModel runat="server">
                                        <Columns>
                                            <ext:Column runat="server" Text="Establecimiento" DataIndex="pem_emp_id" Width="35" Flex="1" />
                                            <ext:Column runat="server" Text="Dirección IP" DataIndex="pem_direccion_ip" Width="35" Flex="1" Focusable="false" />
                                            <ext:Column runat="server" Text="Punto Emisión" DataIndex="pem_punto_emision" Width="35" Flex="1" Focusable="false" />
                                        </Columns>
                                    </ColumnModel>
                                    <DirectEvents>
                                        <ItemClick OnEvent="gdPuntoEmision_click">
                                            <ExtraParams>
                                                <ext:Parameter Name="Values" Value="Ext.encode(#{gdPuntoEmision}.getRowsValues({selectedOnly:true}))" Mode="Raw" />
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
                <ext:Button runat="server" ID="btnGuardar" Text="Guardar">
                    <DirectEvents>
                        <Click OnEvent="btnGuardar_click" Before="return #{FormPanel1}.isValid();"></Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnNuevoPuntoEmision" Text="Nuevo Punto de Emisión">
                    <DirectEvents>
                        <Click OnEvent="btnNuevoPuntoEmision_click"></Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnEliminar" Text="Eliminar">
                    <DirectEvents>
                        <Click OnEvent="btnEliminar_click">
                        </Click>
                    </DirectEvents>
                </ext:Button>

                <ext:Button runat="server" ID="btnCancelar" Text="Cancelar">
                    <DirectEvents>
                        <Click OnEvent="btnCancelar_click"></Click>
                    </DirectEvents>
                </ext:Button>
            </Buttons>
        </ext:FormPanel>
    </div>
</body>
</html>
