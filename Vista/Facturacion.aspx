<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Facturacion.aspx.cs" Inherits="Vista.Facturacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <ext:XScript runat="server" ID="xScript">
        <script type="text/javascript">
            var GetImage = function (value) {
                return "<img height='42' width='42' src='Archivos/" + "Cpu" + ".jpg' />";
            }
        </script>
    </ext:XScript>
</head>
<body>
    <div class="contenedor">
        <ext:ResourceManager runat="server" ID="rmProductos">
            <Listeners>
                <DocumentReady Handler="var t = Ext.isGecko ? Ext.getDoc() : Ext.getBody();
                    
                            t.on('keydown', function (e) { App.direct.focusBusqueda(e.getKey()) })" />
            </Listeners>
        </ext:ResourceManager>
        <ext:FormPanel
            ID="FormPanel1"
            runat="server"
            Width="1150"
            BodyPadding="10"
            MinWidth="1165"
            DefaultAnchor="100%"
            Height="625">
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
                            DefaultAnchor="100%"
                            MaxWidth="1228"
                            Height="30"
                            MarginSpec="0, 0, 0, 0">
                            <Defaults>
                                <ext:Parameter Name="labelWidth" Value="89" Mode="Raw" />
                            </Defaults>
                            <Items>
                                <ext:Label runat="server" ID="lblEstablecimiento" MarginSpec="0, 90, 0, 0"></ext:Label>
                                <ext:Label runat="server" Text="Usuario: "></ext:Label>
                                <ext:Label runat="server" ID="lblUsuario" MinWidth="300" MarginSpec="0, 80, 0, 0"></ext:Label>
                                <ext:Label runat="server" Text="Fecha: "></ext:Label>
                                <ext:Label runat="server" ID="lblFechaActual" MarginSpec="0, 80, 0, 0"></ext:Label>
                                <ext:Label runat="server" Text="Factura actual: "></ext:Label>
                                <ext:Label runat="server" ID="lblFacturaActual" MarginSpec="0, 80, 0, 0"></ext:Label>
                                <ext:Hidden runat="server" ID="hdnFacturaActual"></ext:Hidden>
                                <ext:Label runat="server" Text="Punto de emisión: "></ext:Label>
                                <ext:Label runat="server" ID="lblPuntoEmision" ></ext:Label>
                                <ext:Hidden runat="server" ID="hdnPuntoEmision"></ext:Hidden>
                            </Items>
                        </ext:FieldSet>
                    </Items>
                </ext:FieldContainer>

                <ext:FieldContainer
                    runat="server"
                    MsgTarget="Side"
                    CombineErrors="false"
                    MarginSpec="-12, 0, 0, 0"
                    Layout="HBoxLayout" LabelWidth="130">
                    <Defaults>
                        <ext:Parameter Name="Flex" Value="1" Mode="Raw" />
                        <ext:Parameter Name="HideLabel" Value="true" Mode="Raw" />
                    </Defaults>
                    <Items>
                        <ext:FieldSet
                            runat="server"
                            Collapsible="false"
                            DefaultAnchor="100%" Height="579">
                            <Defaults>
                                <ext:Parameter Name="labelWidth" Value="89" Mode="Raw" />
                            </Defaults>
                            <Items>
                                <ext:GridPanel
                                    ID="gpDetalleVenta"
                                    runat="server"
                                    Header="true"
                                    Width="650"
                                    Height="430" Collapsible="false" Title="Detalle de venta">
                                    <Store>
                                        <ext:Store runat="server" ID="storeDetalleVenta">
                                            <Model>
                                                <ext:Model runat="server" IDProperty="ID">
                                                    <Fields>
                                                        <ext:ModelField Name="codigo" Type="String" />
                                                        <ext:ModelField Name="cantidad" Type="Int" />
                                                        <ext:ModelField Name="descripcion" Type="String" />
                                                        <ext:ModelField Name="precio" Type="Float" />
                                                        <ext:ModelField Name="total" Type="Float" />
                                                        <ext:ModelField Name="descuento" Type="Float" />
                                                        <ext:ModelField Name="porcentajeDescuento" Type="Float" />
                                                    </Fields>
                                                </ext:Model>
                                            </Model>
                                        </ext:Store>
                                    </Store>

                                    <ColumnModel runat="server">
                                        <Columns>
                                            <ext:Column runat="server" Text="Codigo" DataIndex="codigo" Flex="1" ID="Column3" Hidden="true">
                                            </ext:Column>
                                            <ext:Column runat="server" Text="Cantidad" DataIndex="cantidad" Flex="1" ID="Column2">
                                            </ext:Column>
                                            <ext:Column runat="server" Text="Producto" DataIndex="descripcion" Flex="1" ID="Column1">
                                            </ext:Column>
                                            <ext:NumberColumn runat="server" Text="Precio" DataIndex="precio" Flex="1">
                                            </ext:NumberColumn>
                                            <ext:NumberColumn runat="server" Text="Total" DataIndex="total" Flex="1">
                                            </ext:NumberColumn>
                                            <ext:NumberColumn runat="server" Text="Descuento" DataIndex="descuento" Flex="1">
                                            </ext:NumberColumn>
                                            <ext:NumberColumn runat="server" Text="% Descuento" DataIndex="porcentajeDescuento" Flex="1">
                                            </ext:NumberColumn>
                                        </Columns>
                                    </ColumnModel>
                                    <DirectEvents>
                                        <ItemClick OnEvent="gpDetalleVenta_click">
                                            <ExtraParams>
                                                <ext:Parameter Name="ValuesDV" Value="Ext.encode(#{gpDetalleVenta}.getRowsValues({selectedOnly:true}))" Mode="Raw" />
                                            </ExtraParams>
                                        </ItemClick>
                                    </DirectEvents>
                                </ext:GridPanel>
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
                                        <ext:ImageButton ID="imgBtnCobrar" runat="server" ImageUrl="assets/images/cobrar.png" ToolTip="Cobrar">
                                            <DirectEvents>
                                                <Click OnEvent="imgBtnCobrar_click"></Click>
                                            </DirectEvents>
                                        </ext:ImageButton>
                                        <ext:Label runat="server" Text="TOTAL $" MarginSpec="0, 0, 0, 300" MaxWidth="50"></ext:Label>
                                        <ext:NumberField ID="nmbTotal" runat="server" ReadOnly="true" MaxWidth="400"></ext:NumberField>
                                    </Items>
                                </ext:FieldContainer>

                            </Items>
                        </ext:FieldSet>
                        <ext:FieldSet
                            runat="server"
                            Collapsible="false"
                            DefaultAnchor="100%"
                            MaxWidth="900"
                            Height="579" ID="fsCatProd">
                            <Defaults>
                                <ext:Parameter Name="labelWidth" Value="89" Mode="Raw" />
                            </Defaults>
                            <Items>
                                <ext:ComboBox runat="server" ID="cbxFamilias" ValueField="fam_id" DisplayField="fam_descripcion" Editable="false" FieldLabel="Categoría">
                                    <Store>
                                        <ext:Store runat="server" ID="storeCbxFamilias">
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
                                    <Items>
                                        <ext:ListItem Text="Todos" Value="0"></ext:ListItem>
                                    </Items>
                                    <SelectedItems>
                                        <ext:ListItem Text="Todos" Value="0"></ext:ListItem>
                                    </SelectedItems>
                                    <DirectEvents>
                                        <Select OnEvent="cbxFamilias_Select"></Select>
                                    </DirectEvents>
                                </ext:ComboBox>
                                <ext:Label runat="server" ID="LabelSeparatore1" Html="<hr>" />
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
                                        <ext:TextField runat="server" ID="txtBuscarDescripcion" Note="F2 Buscar por Descripción">
                                            <DirectEvents>
                                                <Change OnEvent="txtBuscarDescripcion_change"></Change>
                                            </DirectEvents>
                                        </ext:TextField>
                                        <ext:TextField runat="server" ID="txtBuscarCodigo" Note="F8 Buscar por Código">
                                            <DirectEvents>
                                                <Change OnEvent="txtBuscarCodigo_change"></Change>
                                            </DirectEvents>
                                        </ext:TextField>
                                        <ext:TextField runat="server" ID="txtBuscarCodBarras" Note="F10 Buscar por Cód. Barras">
                                            <DirectEvents>
                                                <Change OnEvent="txtBuscarCodBarras_change">
                                                    <ExtraParams>
                                                        <ext:Parameter Name="gridDV" Value="Ext.encode(#{gpDetalleVenta}.getRowsValues({selectedOnly : false}))" Mode="Raw" />
                                                    </ExtraParams>
                                                </Change>
                                            </DirectEvents>
                                        </ext:TextField>
                                    </Items>
                                </ext:FieldContainer>

                                <ext:GridPanel
                                    ID="gpProductos"
                                    runat="server"
                                    Header="true"
                                    Width="650"
                                    Height="435" Collapsible="false" Title="Productos">
                                    <Store>
                                        <ext:Store runat="server" ID="storeProductos">
                                            <Model>
                                                <ext:Model runat="server" IDProperty="ID">
                                                    <Fields>
                                                        <ext:ModelField Name="pro_codigo" Type="String" />
                                                        <ext:ModelField Name="pro_descripcion" Type="String" />
                                                        <ext:ModelField Name="pro_imagen" Type="Auto" />
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
                                            <ext:Column runat="server" Text="Imagenl" DataIndex="pro_imagen" Flex="1">
                                            </ext:Column>
                                        </Columns>
                                    </ColumnModel>
                                    <DirectEvents>
                                        <ItemClick OnEvent="gpProductos_click">
                                            <ExtraParams>
                                                <ext:Parameter Name="Values" Value="Ext.encode(#{gpProductos}.getRowsValues({selectedOnly:true}))" Mode="Raw" />
                                                <ext:Parameter Name="gridDV" Value="Ext.encode(#{gpDetalleVenta}.getRowsValues({selectedOnly : false}))" Mode="Raw" />
                                            </ExtraParams>
                                        </ItemClick>
                                    </DirectEvents>
                                    <BottomBar>
                                        <ext:PagingToolbar runat="server" HideRefresh="true" />
                                    </BottomBar>

                                </ext:GridPanel>

                            </Items>
                        </ext:FieldSet>
                        <ext:FieldSet
                            runat="server"
                            Collapsible="false"
                            DefaultAnchor="100%"
                            MaxWidth="900"
                            Height="579" ID="fsFinalizarVenta">
                            <Defaults>
                                <ext:Parameter Name="labelWidth" Value="89" Mode="Raw" />
                            </Defaults>
                            <Items>
                                <ext:ImageButton ID="ImageButton1" runat="server" ImageUrl="assets/images/CERRAR VENTA.png" MaxWidth="110" MaxHeight="100">
                                </ext:ImageButton>
                                <ext:Label runat="server" ID="Label1" Html="<hr>" />
                                <ext:NumberField runat="server" ID="nmbCVTotalVenta" ReadOnly="true" FieldLabel="Total Venta"></ext:NumberField>
                                <ext:NumberField runat="server" ID="nmbCVEntregaCliente" FieldLabel="Entrega Cliente">
                                    <DirectEvents>
                                        <Change OnEvent="nmbCVEntregaCliente_change"></Change>
                                    </DirectEvents>
                                </ext:NumberField>
                                <ext:NumberField runat="server" ID="nmbCVDevolucion" ReadOnly="true" FieldLabel="Devolución"></ext:NumberField>
                                <ext:Label runat="server" ID="Label2" Html="<hr>" />
                                <ext:FieldContainer
                                    runat="server"
                                    MsgTarget="Side"
                                    CombineErrors="false"
                                    Layout="HBoxLayout" LabelWidth="130" MarginSpec="0, 5, 0, 0">
                                    <Defaults>
                                        <ext:Parameter Name="Flex" Value="1" Mode="Raw" />
                                        <ext:Parameter Name="HideLabel" Value="true" Mode="Raw" />
                                    </Defaults>
                                    <Items>
                                        <ext:TextField ID="txtCVFormaPagoSeleccionada" runat="server" ReadOnly="true" Note="Forma de pago seleccionada" MaxWidth="270" MarginSpec="0, 100, 0, 0"></ext:TextField>
                                        <ext:TextField ID="txtCVClienteSeleccionado" runat="server" ReadOnly="true" Note="Cliente Seleccionado" MaxWidth="270"></ext:TextField>
                                        <ext:Hidden runat="server" ID="hdnRucClienteSeleccionado"></ext:Hidden>
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
                                        <ext:ImageButton runat="server" ID="imgBtnOtrosConUsoSF" ImageUrl="assets/images/OTROS_CON_USO_SF.png" ToolTip="Otros con uso del Sistema Financiero" MarginSpec="-15, 10, 0, 0">
                                            <DirectEvents>
                                                <Click OnEvent="imgBtnOtrosConUsoSF_click"></Click>
                                            </DirectEvents>
                                        </ext:ImageButton>
                                        <ext:ImageButton runat="server" ID="imgBtnTarjetaCredito" ImageUrl="assets/images/TARJETA_CREDITO.png" ToolTip="Tarjeta de Crédito" MarginSpec="-15, 10, 0, 0">
                                            <DirectEvents>
                                                <Click OnEvent="imgBtnTarjetaCredito_click"></Click>
                                            </DirectEvents>
                                        </ext:ImageButton>
                                        <ext:ImageButton runat="server" ID="imgBtnTarjetaDebito" ImageUrl="assets/images/TARJETA_DEBITO.png" ToolTip="Tarjeta de Débito" MarginSpec="-15, 10, 0, 0">
                                            <DirectEvents>
                                                <Click OnEvent="imgBtnTarjetaDebito_click"></Click>
                                            </DirectEvents>
                                        </ext:ImageButton>
                                        <ext:ImageButton runat="server" ID="imgBtnSinUsoSF" ImageUrl="assets/images/SIN_USO_SF.png" ToolTip="Sin uso del Sistema Financiero" MarginSpec="-10, 10, 0, 0">
                                            <DirectEvents>
                                                <Click OnEvent="imgBtnSinUsoSF_click"></Click>
                                            </DirectEvents>
                                        </ext:ImageButton>
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
                                        <ext:ImageButton runat="server" ID="imgBtnDineroElectronico" ImageUrl="assets/images/DINERO_ELECTRONICO.png" ToolTip="Dinero Electrónico" MarginSpec="-15, 10, 0, 0">
                                            <DirectEvents>
                                                <Click OnEvent="imgBtnDineroElectronico_click"></Click>
                                            </DirectEvents>
                                        </ext:ImageButton>
                                        <ext:ImageButton runat="server" ID="imgBtnTarjetaPrepago" ImageUrl="assets/images/TARJETA PREPAGO.png" ToolTip="Tarjera Prepago" MarginSpec="-15, 10, 0, 0">
                                            <DirectEvents>
                                                <Click OnEvent="imgBtnTarjetaPrepago_click"></Click>
                                            </DirectEvents>
                                        </ext:ImageButton>
                                        <ext:ImageButton runat="server" ID="imgBtnCompensacionDeudas" ImageUrl="assets/images/COMPENSACION_DEUDAS.png" ToolTip="Compensación de deudas" MarginSpec="-23, 10, 0, 0">
                                            <DirectEvents>
                                                <Click OnEvent="imgBtnCompensacionDeudas_click"></Click>
                                            </DirectEvents>
                                        </ext:ImageButton>
                                        <ext:ImageButton runat="server" ID="imgBtnEndosoTitulos" ImageUrl="assets/images/ENDOSO_TITULOS.png" ToolTip="Endoso de Títulos" MarginSpec="-5, 10, 0, 0">
                                            <DirectEvents>
                                                <Click OnEvent="imgBtnEndosoTitulos_click"></Click>
                                            </DirectEvents>
                                        </ext:ImageButton>
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
                                        <ext:Button runat="server" Text="Regresar a la venta" ID="btnRegresarVenta" MaxWidth="135" MarginSpec="0, 10, 0, 0">
                                            <DirectEvents>
                                                <Click OnEvent="btnRegresarVenta_click"></Click>
                                            </DirectEvents>

                                        </ext:Button>
                                        <ext:Button runat="server" ID="btnBuscarCliente" Text="Buscar Cliente" MaxWidth="170" MarginSpec="0, 130, 0, 0">
                                            <DirectEvents>
                                                <Click OnEvent="btnBuscarCliente_click"></Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button runat="server" Text="Terminar Venta" ID="btnTerminarVenta" MaxWidth="170">
                                            <DirectEvents>
                                                <Click OnEvent="btnTerminarVenta_click">
                                                    <ExtraParams>
                                                        <ext:Parameter Name="Values" Value="Ext.encode(#{gpDetalleVenta}.getRowsValues({selectedOnly:false}))" Mode="Raw" />
                                                    </ExtraParams>
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                    </Items>
                                </ext:FieldContainer>

                            </Items>
                        </ext:FieldSet>

                    </Items>
                </ext:FieldContainer>

            </Items>
            <Buttons>
                <%--Before="return #{FormPanel1}.isValid();"--%>
                <ext:Button runat="server" ID="btnBorrarVenta" Text="Borrar Venta">
                    <DirectEvents>
                        <Click OnEvent="btnBorrarVenta_click"></Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnAbrirCajetin" Text="Abrir Cajetin">
                </ext:Button>
                <ext:Button runat="server" ID="btnOpcionesCaja" Text="Opciones de Caja">
                </ext:Button>
            </Buttons>
        </ext:FormPanel>
    </div>
    <form runat="server" id="formWindow">
        <ext:Window
            ID="Window1"
            runat="server"
            Title="Modificando línea de venta"
            Icon="Application"
            Height="200"
            Width="700"
            BodyStyle="background-color: #fff;"
            BodyPadding="5"
            Hidden="true"
            Modal="true">
            <Content>
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
                        <ext:Hidden runat="server" ID="hdnModCodigoProducto"></ext:Hidden>
                        <ext:NumberField runat="server" ID="nmbModCantidad" Note="Cantidad"></ext:NumberField>
                        <ext:TextField runat="server" ID="txtModDescripcion" Note="Producto"></ext:TextField>
                        <ext:NumberField runat="server" ID="nmbModPrecio" Note="Precio por unidad"></ext:NumberField>
                        <ext:NumberField runat="server" ID="nmbModDescuento" Note="Descuento %"></ext:NumberField>
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
                        <ext:Button runat="server" ID="btnBorrarLinea" Text="Borrar Línea" MarginSpec="30, 0, 0, 0">
                            <DirectEvents>
                                <Click OnEvent="btnBorrarLinea_click">
                                    <ExtraParams>
                                        <ext:Parameter Name="pmtApliCam" Value="Ext.encode(#{gpDetalleVenta}.getRowsValues({selectedOnly : false}))" Mode="Raw" />
                                    </ExtraParams>
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                        <ext:Button runat="server" ID="btnSalirSinCambios" Text="Salir sin cambios" MarginSpec="30, 0, 0, 0">
                            <DirectEvents>
                                <Click OnEvent="btnSalirSinCambios_click">
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                        <ext:Button runat="server" ID="btnAplicarCambios" Text="Aplicar Cambios" MarginSpec="30, 0, 0, 0">
                            <DirectEvents>
                                <Click OnEvent="btnAplicarCambios_click">
                                    <ExtraParams>
                                        <ext:Parameter Name="pmtApliCam" Value="Ext.encode(#{gpDetalleVenta}.getRowsValues({selectedOnly : false}))" Mode="Raw" />
                                    </ExtraParams>
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                    </Items>
                </ext:FieldContainer>
            </Content>
        </ext:Window>


        <ext:Window
            ID="Window2"
            runat="server"
            Title="Buscar Cliente"
            Icon="Application"
            Height="380"
            Width="1115"
            BodyStyle="background-color: #fff;"
            BodyPadding="5"
            Hidden="true"
            Modal="true">
            <Content>
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
                                    Layout="HBoxLayout" LabelWidth="85"
                                    FieldLabel="Nombres">
                                    <Defaults>
                                        <ext:Parameter Name="Flex" Value="1" Mode="Raw" />
                                        <ext:Parameter Name="HideLabel" Value="true" Mode="Raw" />
                                    </Defaults>
                                    <Items>
                                        <ext:TextField ID="txtNombres" runat="server" AllowBlank="false" EnableKeyEvents="true" Width="456">
                                            <DirectEvents>
                                                <Change OnEvent="txtNombres_change"></Change>
                                            </DirectEvents>
                                        </ext:TextField>
                                    </Items>
                                </ext:FieldContainer>
                                <ext:FieldContainer
                                    runat="server"
                                    MsgTarget="Side"
                                    CombineErrors="false"
                                    Layout="HBoxLayout" LabelWidth="85"
                                    FieldLabel="Apellidos">
                                    <Defaults>
                                        <ext:Parameter Name="Flex" Value="1" Mode="Raw" />
                                        <ext:Parameter Name="HideLabel" Value="true" Mode="Raw" />
                                    </Defaults>
                                    <Items>
                                        <ext:TextField ID="txtApellidos" runat="server" AllowBlank="false" EnableKeyEvents="true" Width="456">
                                            <DirectEvents>
                                                <Change OnEvent="txtApellidos_change"></Change>
                                            </DirectEvents>
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
                                        <ext:Label runat="server" Text="RUC/CI:" Width="90"></ext:Label>
                                        <ext:TextField ID="txtRuc" runat="server" MarginSpec="0, 59, 0, 0" AllowBlank="false" EnableKeyEvents="true" MaskRe="/[0-9]/" MaxLength="13" EnforceMaxLength="true">
                                            <DirectEvents>
                                                <Change OnEvent="txtRuc_change"></Change>
                                            </DirectEvents>
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
                                    Layout="HBoxLayout" LabelWidth="85"
                                    FieldLabel="Dirección">
                                    <Defaults>
                                        <ext:Parameter Name="Flex" Value="1" Mode="Raw" />
                                        <ext:Parameter Name="HideLabel" Value="true" Mode="Raw" />
                                    </Defaults>
                                    <Items>
                                        <ext:TextField runat="server" ID="txtDireccion" EnableKeyEvents="true" AllowBlank="false" Width="456">
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
                                    Layout="HBoxLayout" LabelWidth="85"
                                    FieldLabel="Correo">
                                    <Defaults>
                                        <ext:Parameter Name="Flex" Value="1" Mode="Raw" />
                                        <ext:Parameter Name="HideLabel" Value="true" Mode="Raw" />
                                    </Defaults>
                                    <Items>
                                        <ext:Hidden runat="server" ID="hdnCliId"></ext:Hidden>
                                        <ext:TextField runat="server" ID="txtCorreo" EnableKeyEvents="true" AllowBlank="false" Width="456">
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
                                    Layout="HBoxLayout" LabelWidth="130">
                                    <Defaults>
                                        <ext:Parameter Name="Flex" Value="1" Mode="Raw" />
                                        <ext:Parameter Name="HideLabel" Value="true" Mode="Raw" />
                                    </Defaults>
                                    <Items>
                                        <ext:Label runat="server" Text="Estado:" Width="90"></ext:Label>
                                        <ext:Checkbox ID="chkEstadoCliente" runat="server" FieldLabel="Estado">
                                            <Listeners>
                                                <Tap Handler="focuscontrol()"></Tap>
                                            </Listeners>
                                        </ext:Checkbox>
                                    </Items>
                                </ext:FieldContainer>
                            </Items>
                        </ext:FieldSet>
                        <ext:FieldSet
                            runat="server"
                            Collapsible="false"
                            DefaultAnchor="100%"
                            MaxWidth="1100"
                            Height="264">
                            <Defaults>
                                <ext:Parameter Name="labelWidth" Value="89" Mode="Raw" />
                            </Defaults>
                            <Items>
                                <ext:GridPanel
                                    ID="gdClientes"
                                    runat="server"
                                    Header="true"
                                    Width="485"
                                    Height="256" Collapsible="true" Title="Lista de Clientes">
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
                                            <ext:Column runat="server" Text="Nombres" DataIndex="cli_nombres" Flex="1" />
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
                                </ext:GridPanel>
                            </Items>
                        </ext:FieldSet>
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
                        <ext:Button runat="server" ID="btnWndCrearCliente" Text="Nuevo Cliente">
                            <DirectEvents>
                                <Click OnEvent="btnWndCrearCliente_click"></Click>
                            </DirectEvents>
                        </ext:Button>
                        <ext:Button runat="server" ID="btnWndBuscarCliente" Text="Buscar">
                            <DirectEvents>
                                <Click OnEvent="btnWndBuscarCliente_click"></Click>
                            </DirectEvents>
                        </ext:Button>
                        <ext:Button ID="btnWndSalir" runat="server" Text="Salir">
                            <DirectEvents>
                                <Click OnEvent="btnWndSalir_click"></Click>
                            </DirectEvents>
                        </ext:Button>
                        <ext:Button runat="server" ID="btnWndGuardarCliente" Text="Guardar">
                            <DirectEvents>
                                <Click OnEvent="btnWndGuardarCliente_click"></Click>
                            </DirectEvents>
                        </ext:Button>
                        <ext:Button runat="server" ID="btnWndCancelar" Text="Cancelar">
                            <DirectEvents>
                                <Click OnEvent="btnWndCancelar_click"></Click>
                            </DirectEvents>
                        </ext:Button>
                    </Items>
                </ext:FieldContainer>
            </Content>
        </ext:Window>

    </form>
</body>
</html>
