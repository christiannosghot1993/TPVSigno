<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IngresoCategorias.aspx.cs" Inherits="Vista.IngresoCategorías" %>

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
        
        .contenedor{
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
    <ext:ResourceManager runat="server" ID="rmCategorias"/>
    <ext:FormPanel
        ID="FormPanel1"
        runat="server"
        Title="INGRESO DE CATEGORÍAS asd"
        Width="1150"
        BodyPadding="10"
        DefaultAnchor="100%">
        <Items>
            
            <ext:FieldContainer
                        runat="server"
                        MsgTarget="Side"
                        CombineErrors="false"
                        Layout="HBoxLayout" LabelWidth="130"
                       >
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
                        FieldLabel="Nombre Categoría" Height="483">
                        <Defaults>
                            <ext:Parameter Name="Flex" Value="1" Mode="Raw" />
                            <ext:Parameter Name="HideLabel" Value="true" Mode="Raw" />
                        </Defaults>
                        <Items>
                            <ext:Hidden ID="hdnFamId" runat="server"></ext:Hidden>
                            <ext:TextField ID="txNombreCategoría" runat="server" MarginSpec="0, 50, 0, 0" MinWidth="280" AllowBlank="false" EnableKeyEvents="true">
                                <Listeners>
                                    <%--<SpecialKey Handler="if(e.getKey()==13) {focuscontrol()};"></SpecialKey>--%>
                                    <Tap Handler=" focuscontrol();"></Tap>
                                </Listeners>
                            </ext:TextField>
                            <ext:Label runat="server" Text="Estado:" MaxWidth="50" MarginSpec="5, 0, 0, 0"></ext:Label>
                            <ext:Checkbox ID="chkEstadoCategoria" runat="server">
                                <Listeners>
                                    <Tap Handler=" focuscontrol();"></Tap>
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
                 MaxWidth="900"
                Height="505">
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
                                        <ext:TextField runat="server" ID="txtBuscarCategoria" Note="Buscar por nombre" MaxWidth="250"> 
                                            <DirectEvents>
                                                <Change OnEvent="txtBuscarCategoria_change"></Change>
                                            </DirectEvents>
                                        </ext:TextField>
                                    </Items>
                                </ext:FieldContainer>
                    <ext:GridPanel
            ID="gdCategorias"
            runat="server"
                Header="true"
            Width="650"
            Height="440" Collapsible="true" Title="Lista de Categorías">
            <Store>
                <ext:Store runat="server" ID="storeCategorias">
                    <Model>
                        <ext:Model runat="server" IDProperty="ID">
                            <Fields>
                                <ext:ModelField Name="fam_descripcion" Type="String" />
                                <ext:ModelField Name="fam_estado" Type="String" />
                            </Fields>
                        </ext:Model>
                    </Model>
                </ext:Store>
            </Store>

            <ColumnModel runat="server">
                <Columns>
                    <ext:Column runat="server" Text="Descripción" DataIndex="fam_descripcion" Width="35" Flex="1"/>    
                    <ext:Column runat="server" Text="Estado" DataIndex="fam_estado" Width="35" Flex="1" Focusable="false"/> 
                </Columns>
            </ColumnModel>
                        <DirectEvents>
                            <ItemClick OnEvent="gdCategorias_click">
                                <ExtraParams>
                                     <ext:Parameter Name="Values" Value="Ext.encode(#{gdCategorias}.getRowsValues({selectedOnly:true}))" Mode="Raw" />
                                 </ExtraParams>
                            </ItemClick>
                        </DirectEvents>
              
<%--                                <Plugins>
                    <ext:RowEditing runat="server" SaveBtnText="actualizar" CancelBtnText="cancelar">
                    </ext:RowEditing>
                </Plugins>--%>
                 <BottomBar>
                 <ext:PagingToolbar runat="server" HideRefresh="true"/>
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
            <ext:Button runat="server" ID="btnNuevaCategoria" Text="Nueva Categoría">
                <DirectEvents>
                    <Click OnEvent="btnNuevaCategoria_click"></Click>
                </DirectEvents>
            </ext:Button>
            <ext:Button runat="server" ID="btnEliminar" Text="Eliminar">
                <DirectEvents>
                    <Click OnEvent="btnEliminar_click"></Click>
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
