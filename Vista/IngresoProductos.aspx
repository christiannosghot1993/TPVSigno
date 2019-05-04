<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IngresoProductos.aspx.cs" Inherits="Vista.IngresoProductos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Productos</title>
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
        <ext:ResourceManager runat="server" ID="rmProductos" />
        <ext:FormPanel
            ID="FormPanel1"
            runat="server"
            Title="INGRESO DE PRODUCTOS"
            Width="1150"
            Height="630"
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
                                    Layout="HBoxLayout" LabelWidth="130">
                                    <Defaults>
                                        <ext:Parameter Name="Flex" Value="1" Mode="Raw" />
                                        <ext:Parameter Name="HideLabel" Value="true" Mode="Raw" />
                                    </Defaults>
                                    <Items>
                                        <ext:Label runat="server" Text="Cód. Producto:" MarginSpec="-5, 102, 0, 0" ></ext:Label>
                                        <ext:TextField ID="txtCodigoProducto" runat="server" AllowBlank="false" EnableKeyEvents="true"  MarginSpec="0, 60, 0, 0" MinWidth="150">
                                            <Listeners>
                                                <Tap Handler="focuscontrol();"></Tap>
                                            </Listeners>
                                        </ext:TextField>
                                        <ext:Label runat="server" Text="Cód. Barras:" MarginSpec="-5, 5, 0, 0"></ext:Label>
                                         <ext:TextField ID="txtCodBarras" runat="server" MinWidth="150">
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
                                    FieldLabel="Descripción">
                                    <Defaults>
                                        <ext:Parameter Name="Flex" Value="1" Mode="Raw" />
                                        <ext:Parameter Name="HideLabel" Value="true" Mode="Raw" />
                                    </Defaults>
                                    <Items>
                                        <ext:TextField ID="txDescripcion" runat="server" AllowBlank="false" EnableKeyEvents="true">
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
                                    FieldLabel="Proveedor">
                                    <Defaults>
                                        <ext:Parameter Name="Flex" Value="1" Mode="Raw" />
                                        <ext:Parameter Name="HideLabel" Value="true" Mode="Raw" />
                                    </Defaults>
                                    <Items>
                                        <ext:ComboBox ID="cbxProveedores" runat="server" AllowBlank="false" ValueField="prv_id" DisplayField="prv_razon_social" Editable="false">
                                            <Store>
                                                <ext:Store runat="server" ID="storeProveedor">
                                                    <Model>
                                                        <ext:Model runat="server">
                                                            <Fields>
                                                                <ext:ModelField Name="prv_id" />
                                                                <ext:ModelField Name="prv_razon_social" />
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
                                    FieldLabel="Categoría">
                                    <Defaults>
                                        <ext:Parameter Name="Flex" Value="1" Mode="Raw" />
                                        <ext:Parameter Name="HideLabel" Value="true" Mode="Raw" />
                                    </Defaults>
                                    <Items>
                                        <ext:ComboBox ID="cbxCategorias" runat="server" AllowBlank="false" ValueField="fam_id" DisplayField="fam_descripcion" Editable="false">
                                            <Store>
                                                <ext:Store runat="server" ID="storeCategorias">
                                                    <Model>
                                                        <ext:Model runat="server">
                                                            <Fields>
                                                                <ext:ModelField Name="fam_id" />
                                                                <ext:ModelField Name="fam_descripcion" />
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
                                    Layout="HBoxLayout" LabelWidth="130">
                                    <Defaults>
                                        <ext:Parameter Name="Flex" Value="1" Mode="Raw" />
                                        <ext:Parameter Name="HideLabel" Value="true" Mode="Raw" />
                                    </Defaults>
                                    <Items>
                                        <ext:Label ID="lblCoste" runat="server" Text="Coste:" MarginSpec="0, 15, 0, 0"></ext:Label>
                                        <ext:NumberField ID="nmbCoste" runat="server" MarginSpec="0, 20, 0, 0" AllowBlank="false" EnableKeyEvents="true">
                                            <Listeners>
                                                <Tap Handler="focuscontrol();"></Tap>
                                            </Listeners>
                                        </ext:NumberField>
                                        <ext:Label ID="Label1" runat="server" Text="Precio de venta:" MarginSpec="0, 0, 0, 5"></ext:Label>
                                        <ext:NumberField ID="nmbPrecioVenta" runat="server" MarginSpec="0, 0, 0, 20" AllowBlank="false" EnableKeyEvents="true">
                                            <Listeners>
                                                <Tap Handler="focuscontrol();"></Tap>
                                            </Listeners>
                                        </ext:NumberField>

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
                                        <ext:Label runat="server" Text="Impuesto:" MarginSpec="0, 5, 0, 0"></ext:Label>
                                        <ext:TextField ID="txtImpuesto" runat="server" MarginSpec="0, 15, 0, 0" AllowBlank="false"></ext:TextField>
                                        <ext:Label runat="server" Text="%"></ext:Label>
                                        <ext:Checkbox ID="chkEstadoProdcuto" runat="server" Note="Estado" NoteAlign="Down">
                                            <Listeners>
                                                <Tap Handler="focuscontrol();"></Tap>
                                            </Listeners>
                                        </ext:Checkbox>
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
                                        <ext:Label ID="lblStockActual" runat="server" Text="Stock actual:" MaxWidth="135"></ext:Label>
                                        <ext:NumberField ID="nmbStockActual" runat="server" MarginSpec="0, 20, 0, 0" AllowBlank="false" EnableKeyEvents="true">
                                            <Listeners>
                                                <Tap Handler="focuscontrol();"></Tap>
                                            </Listeners>
                                        </ext:NumberField>
                                        <ext:Label ID="lblStockMinimo" runat="server" Text="Stock mínimo:" MaxWidth="53" MinHeight="40"></ext:Label>
                                        <ext:NumberField ID="nmbStockMinimo" runat="server" AllowBlank="false" EnableKeyEvents="true">
                                            <Listeners>
                                                <Tap Handler="focuscontrol();"></Tap>
                                            </Listeners>
                                        </ext:NumberField>
                                        <ext:Hidden runat="server" ID="hdnIdProducto"></ext:Hidden>
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
                                        <ext:Label runat="server" Text="Fotografía" MaxWidth="134"></ext:Label>
                                        <ext:FileUploadField runat="server" ID="fuFotografia">
                                            <DirectEvents>
                                                <Change OnEvent="fuFotografia_change"></Change>
                                            </DirectEvents>
                                            <Listeners>
                                                <Tap Handler="focuscontrol();"></Tap>
                                            </Listeners>
                                        </ext:FileUploadField>
                                    </Items>
                                </ext:FieldContainer>
                                <ext:FieldContainer
                                    runat="server"
                                    MsgTarget="Side"
                                    CombineErrors="false"
                                    Layout="HBoxLayout">
                                    <Defaults>
                                        <ext:Parameter Name="Flex" Value="1" Mode="Raw" />
                                        <ext:Parameter Name="HideLabel" Value="true" Mode="Raw" />
                                    </Defaults>
                                    <Items>
                                        <ext:Hidden runat="server" ID="hdnPathImg" />
                                        <ext:Image runat="server" ID="imgProducto" MaxWidth="300" Height="170" MarginSpec="0, 0, 0, 134"></ext:Image>
                                    </Items>
                                </ext:FieldContainer>

                            </Items>
                        </ext:FieldSet>
                        <ext:FieldSet
                            runat="server"
                            Collapsible="false"
                            DefaultAnchor="100%"
                            MaxWidth="900"
                            Height="533">
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
                                        <ext:TextField runat="server" ID="txtBuscarDescripcion" Note="Buscar por Descripción">
                                            <DirectEvents>
                                                <Change OnEvent="txtBuscarDescripcion_change"></Change>
                                            </DirectEvents>
                                        </ext:TextField>
                                        <ext:TextField runat="server" ID="txtBuscarCodigo" Note="Buscar por Código">
                                            <DirectEvents>
                                                <Change OnEvent="txtBuscarCodigo_change"></Change>
                                            </DirectEvents>
                                        </ext:TextField>
                                    </Items>
                                </ext:FieldContainer>

                                <ext:GridPanel
                                    ID="gpProductos"
                                    runat="server"
                                    Header="true"
                                    Width="650"
                                    Height="470" Collapsible="true" Title="Lista de Productos">
                                    <Store>
                                        <ext:Store runat="server" ID="storeProductos">
                                            <Model>
                                                <ext:Model runat="server" IDProperty="ID">
                                                    <Fields>
                                                        <ext:ModelField Name="pro_codigo" Type="String" />
                                                        <ext:ModelField Name="pro_descripcion" Type="String" />
                                                        <ext:ModelField Name="pro_stock_actual" Type="Int" />
                                                        <ext:ModelField Name="pro_stock_minimo" Type="Int" />
                                                    </Fields>
                                                </ext:Model>
                                            </Model>
                                        </ext:Store>
                                    </Store>

                                    <ColumnModel runat="server">
                                        <Columns>
                                            <ext:Column runat="server" Text="Código" DataIndex="pro_codigo" Width="35" Flex="1" />
                                            <ext:Column runat="server" Text="Descripción" DataIndex="pro_descripcion" Flex="1" ID="Nombres">
                                            </ext:Column>
                                            <ext:Column runat="server" Text="Stock Actual" DataIndex="pro_stock_actual" Flex="1">
                                            </ext:Column>

                                            <ext:Column runat="server" Text="Stock Mínimo" DataIndex="pro_stock_minimo">
                                            </ext:Column>

                                        </Columns>
                                    </ColumnModel>
                                    <DirectEvents>
                                        <ItemClick OnEvent="gpProductos_click">
                                            <ExtraParams>
                                                <ext:Parameter Name="Values" Value="Ext.encode(#{gpProductos}.getRowsValues({selectedOnly:true}))" Mode="Raw" />
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
                <%--Before="return #{FormPanel1}.isValid();"--%>
                <ext:Button runat="server" ID="btnNuevoProducto" Text="Nuevo Producto">
                    <DirectEvents>
                        <Click OnEvent="btnNuevoProducto_click"></Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnEliminar" Text="Eliminar">
                    <DirectEvents>
                        <Click OnEvent="btnEliminar_click"></Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnGuardar" Text="Guardar">
                    <DirectEvents>
                        <Click OnEvent="btnGuardar_click" Before="return #{FormPanel1}.isValid();"></Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnCancelar" Text="Cancelar">
                    <DirectEvents>
                        <Click OnEvent="btnCancelar_click"></Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnEscondido" Hidden="true"></ext:Button>
            </Buttons>
        </ext:FormPanel>
    </div>
</body>

</html>
