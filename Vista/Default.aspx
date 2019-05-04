<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Vista.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" ShowWarningOnAjaxFailure="false">
        </ext:ResourceManager>
        <ext:Viewport ID="contenedor" runat="server"  >
        <Items>
        <ext:Window ID="Window1" runat="server" Layout="border" Maximized="true" Closable="false" Frame="false" Draggable="False" Header="False" UI="Info" Modal="true" >
            <Items>
                <ext:Panel ID="West" runat="server" Title="MENU" Region="West" Width="185" Collapsible="true"
                    Layout="AccordionLayout" Split="true">
                    <Items>
                        <ext:TreePanel ID="m_Mantenimiento" runat="server" UseArrows="false" AutoScroll="true"
                            Animate="true" RootVisible="false" AllowLeafDrop="true" ContainerScroll="true"
                            Border="true" Collapsed="false" Icon="User" Title="Mantenimiento" AutoHeight="true">
                            <Root>
                                <ext:Node>
                                    <Children>
                                        <ext:Node NodeID="nodeIngrProductos" Text="Productos" Leaf="true" Icon="ApplicationFormAdd">                                        </ext:Node>
                                        <ext:Node NodeID="nodeIngrCategorias" Text="Categorias" Leaf="true" Icon="Box" ></ext:Node>
                                        <ext:Node NodeID="nodeIngrProveedores" Text="Proveedores" Leaf="true" Icon="PhotoAdd" ></ext:Node>
                                        <ext:Node NodeID="nodeIngrClientes" Text="Clientes" Leaf="true" Icon="PhotoAdd" ></ext:Node>
                                        <ext:Node NodeID="nodeIngrEmpresa" Text="Empresa" Leaf="true" Icon="PhotoAdd" ></ext:Node>
                                        <ext:Node NodeID="nodeRegistroPuntoEmision" Text="Punto Emisión" Leaf="true" Icon="PhotoAdd" ></ext:Node>
                                    </Children>
                                </ext:Node>
                            </Root>
                            <DirectEvents>
                                <ItemClick OnEvent="treeNodo_click" Before="if(!record.data.leaf){return false;};">
                                    <EventMask ShowMask="true" MinDelay="100"></EventMask>
                                    <ExtraParams>
                                         <ext:Parameter Name="id" Value="record.data.id" Mode="Raw"/>
                                    </ExtraParams>
                                </ItemClick>
                            </DirectEvents>
                        </ext:TreePanel>
                        <ext:TreePanel ID="m_Tpv" runat="server" UseArrows="false" AutoScroll="true"
                            Animate="true" RootVisible="false" AllowLeafDrop="true" ContainerScroll="true"
                            Border="true" Collapsed="false" Icon="DateNext" Title="TPV" AutoHeight="true">
                            <Root>
                                <ext:Node NodeID="node_app">
                                    <Children>
                                        <ext:Node NodeID="nodeFacturacion" Text="Facturación" Leaf="true" Icon="UserBrown" >
                                        </ext:Node>
                                        <ext:Node NodeID="nodeIngLugCons" Text="Ingr. Lugar Consumo" Leaf="true" Icon="House"></ext:Node>
                                        <ext:Node  NodeID="nodeIngDescCargo" Text="Ingr. Desc por Cargo" Leaf="true" Icon="MoneyDelete">
                                        </ext:Node>
                                        <ext:Node NodeID="nodeFechasCorteProv" Text="Fechas Corte por Proveedores" Leaf="true" Icon="UserSuit"></ext:Node>
                                       <ext:Node NodeID="nodeAdministrarHorarios" Text="Administrar Horarios" Leaf="true" Icon="Clock" >
                                        </ext:Node>
                                        <ext:Node NodeID="nodeAsigTurAlmEmpl" Text="Asign. Turnos Almuerzos Empl." Leaf="true" Icon="ClockAdd" >
                                        </ext:Node>
                                        
                                        </Children>
                                </ext:Node>
                            </Root>
                             <DirectEvents>
                                <ItemClick OnEvent="treeNodo_click" Before="if(!record.data.leaf){return false;};">
                                    <EventMask ShowMask="true" MinDelay="100"></EventMask>
                                    <ExtraParams>
                                         <ext:Parameter Name="id" Value="record.data.id" Mode="Raw"/>
                                    </ExtraParams>
                                </ItemClick>
                            </DirectEvents>
                        </ext:TreePanel>
                        <ext:TreePanel ID="m_Reportes" runat="server" UseArrows="false" AutoScroll="true"
                            Animate="true" RootVisible="false" AllowLeafDrop="true" ContainerScroll="true"
                            Border="true" Collapsed="true" Icon="Report" Title="REPORTES" AutoHeight="true">
                            <Root>
                                <ext:Node>
                                    <Children>
                                        <ext:Node NodeID="nodeRepTotPer" Text="Rep. Totales por Persona" Leaf="true" Icon="UserTick">
                                        </ext:Node>
                                        <ext:Node NodeID="nodeRepComDet" Text="Rep. Comidas Detallado" Leaf="true" Icon="BoxError">
                                        </ext:Node>
                                        <ext:Node NodeID="nodeRepTotDia" Text="Rep. Totales Diarios" Leaf="true" Icon="CalendarSelectDay">
                                        </ext:Node>
                                        <ext:Node NodeID="nodeRepCentCos" Text="Rep. por Centro Costos" Leaf="true" Icon="MoneyDollar">
                                        </ext:Node>
                                    </Children>
                                </ext:Node>
                            </Root>
                             <DirectEvents>
                                <ItemClick OnEvent="treeNodo_click" Before="if(!record.data.leaf){return false;};">
                                    <EventMask ShowMask="true" MinDelay="100"></EventMask>
                                    <ExtraParams>
                                         <ext:Parameter Name="id" Value="record.data.id" Mode="Raw"/>
                                    </ExtraParams>
                                </ItemClick>
                            </DirectEvents>
                        </ext:TreePanel>                
                        

                        <ext:TreePanel ID="TreePanel1" runat="server" UseArrows="false" AutoScroll="true"
                            Animate="true" RootVisible="false" AllowLeafDrop="true" ContainerScroll="true"
                            Border="true" Collapsed="true" Icon="UserDelete" Title="CERRAR SESIÓN" AutoHeight="true">
                            <Root>
                                <ext:Node>
                                    <Children>
                                        <ext:Node NodeID="nodeCerrarSesion" Text="Cerrar Sesión" Leaf="true" Icon="UserDelete">
                                        </ext:Node>
                                    </Children>
                                </ext:Node>
                            </Root>
                             <DirectEvents>
                                <ItemClick OnEvent="treeNodo_click" Before="if(!record.data.leaf){return false;};">
                                    <EventMask ShowMask="true" MinDelay="100"></EventMask>
                                    <ExtraParams>
                                         <ext:Parameter Name="id" Value="record.data.id" Mode="Raw"/>
                                    </ExtraParams>
                                </ItemClick>
                            </DirectEvents>
                        </ext:TreePanel>      

                    </Items>
                    
                </ext:Panel>
                <ext:Panel ID="Center" runat="server" Region="Center" Border="true" AutoScroll="true">
                     <Loader ID="Loader1" runat="server" Url="home.aspx" Mode="Frame">
                        <LoadMask ShowMask="true"></LoadMask>
                    </Loader>
                </ext:Panel>
            </Items>
        </ext:Window>
            </Items>
    </ext:Viewport>
    </form>
</body>
</html>
