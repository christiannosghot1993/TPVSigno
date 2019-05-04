using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controlador;
using Ext.Net;
using Modelo;

namespace Vista
{
    public partial class Facturacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                String nombre = Session["usuario"].ToString();
                if (!X.IsAjaxRequest)
                {
                    clasePuntoEmision cpe = new clasePuntoEmision();
                    claseEmpresa ce = new claseEmpresa();
                    lblUsuario.Text = nombre;
                    vta_Punto_Emision puntoEmision = cpe.buscarPuntoEmisionVistaPorIP(cpe.getIP());
                    
                    try
                    {
                        imgBtnCobrar.Hidden = false;
                        lblEstablecimiento.Text = puntoEmision.pem_emp_id;
                        tbl_Empresa empresa = ce.buscarEmpresaPorRazonSocial(lblEstablecimiento.Text);
                        string establecimiento = empresa.emp_numero_establecimiento;
                        String puntoEmi = puntoEmision.pem_punto_emision;
                        lblPuntoEmision.Text = establecimiento + "-" + puntoEmi;
                        hdnPuntoEmision.Text= establecimiento + "-" + puntoEmi;
                    }
                    catch
                    {
                        imgBtnCobrar.Hidden = true;
                        lblEstablecimiento.Text = "Registre punto de emisión";
                        
                        X.Msg.Alert("Error!!", "Es necesario registrar un punto de emisión para el terminal con dirección IP "+cpe.getIP()+" para poder facturar.").Show();
                    }
                    

                    claseFamilias cf = new claseFamilias();
                    claseProductos cp = new claseProductos();
                    lblFechaActual.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
                    storeCbxFamilias.DataSource = cf.familiasActivas();
                    storeCbxFamilias.DataBind();
                    storeProductos.DataSource = cp.productosActivos();
                    storeProductos.DataBind();
                    nmbModDescuento.Number = 0;
                    fsFinalizarVenta.Hidden = true;
                    txtCVFormaPagoSeleccionada.Text = "Sin utilización del Sistema Financiero";
                    txtBuscarDescripcion.Focus();
                    btnTerminarVenta.Hidden = true;
                    txtTelefono.ReadOnly = true;
                    txtDireccion.ReadOnly = true;
                    txtCorreo.ReadOnly = true;
                    txtCVClienteSeleccionado.Text = "Consumidor Final";
                    hdnRucClienteSeleccionado.Text = "9999999999999";
                    btnWndGuardarCliente.Hidden = true;
                    btnWndCancelar.Hidden = true;
                    claseFacturacion clFact = new claseFacturacion();
                    List<tbl_Factura_Cabecera> facturaCabecera = clFact.comprobarFacturaCbecera();
                    string fac_serie_numero = "";
                    if (facturaCabecera.Count() == 0)
                    {
                        String facActual = string.Format("{0:000000000}", 1);
                        lblFacturaActual.Text = facActual;
                        hdnFacturaActual.Text = facActual;
                    }
                    else
                    {
                        foreach (var item in facturaCabecera)
                        {
                            fac_serie_numero = item.fac_numero_serie;

                        }
                        String facActual = string.Format("{0:000000000}", int.Parse(fac_serie_numero) + 1);
                        lblFacturaActual.Text = facActual;
                        hdnFacturaActual.Text = facActual;
                    }
                }
            }
            catch(Exception ex)
            {
                Response.Redirect("Login.aspx?men=1");
            }

        }

        public List<string> getNombreImagenes()
        {
            claseProductos cp = new claseProductos();
            List<tbl_Productos> prod = cp.productosActivos();
            List<string> imageUrls = new List<string>();
            foreach (var item in prod)
            {
                imageUrls.Add(item.pro_imagen_path);
            }
            List<string> imageUrlSubstring = new List<string>();
            foreach (var item in imageUrls)
            {
                imageUrlSubstring.Add(item.Substring(36));
            }
            return imageUrlSubstring;
        }

        protected void gpProductos_click(object sender, DirectEventArgs e)
        {
            string json = e.ExtraParams["Values"];
            Dictionary<string, string>[] v1 = JSON.Deserialize<Dictionary<string, string>[]>(json);
            claseProductos cp = new claseProductos();
            tbl_Productos prod = new tbl_Productos(); ;
            foreach (Dictionary<string, string> row in v1)
            {
                prod = cp.buscarProductosPorCod(row["pro_codigo"]);
            }
            DetalleVenta detVentaProdNuevo = new DetalleVenta
            {
                codigo=prod.pro_codigo,
                cantidad=1,
                descripcion=prod.pro_descripcion,
                precio=(decimal)prod.pro_precio_venta,
                total= (decimal)prod.pro_precio_venta,
                descuento=0,
                porcentajeDescuento=0
            };
            string jsonDV = "";
            jsonDV = e.ExtraParams["gridDV"];
            Dictionary<string, string>[] v2 = JSON.Deserialize<Dictionary<string, string>[]>(jsonDV);

            List<DetalleVenta> listDv = new List<DetalleVenta>();
            foreach (Dictionary<string, string> row in v2)
            {
                DetalleVenta detVen = new DetalleVenta();
                detVen.codigo = row["codigo"];
                detVen.cantidad = int.Parse(row["cantidad"]);
                detVen.descripcion = row["descripcion"];
                detVen.precio = decimal.Parse(row["precio"]);
                detVen.total = decimal.Parse(row["total"]);
                detVen.descuento = decimal.Parse(row["descuento"]);
                detVen.porcentajeDescuento = double.Parse(row["porcentajeDescuento"]);
                listDv.Add(detVen);
            }
            foreach (var item in listDv)
            {
                if (item.codigo==detVentaProdNuevo.codigo)
                {
                    item.cantidad = item.cantidad + 1;
                    item.descuento = (item.cantidad * item.precio) * ((decimal)item.porcentajeDescuento / 100);
                    item.total = (item.cantidad * item.precio) - item.descuento;

                }
            }
            listDv.Add(detVentaProdNuevo);
            var sindup = listDv.GroupBy(elem => elem.descripcion).Select(group => group.First());
            storeDetalleVenta.DataSource = sindup;
            storeDetalleVenta.DataBind();
            decimal total = 0;
            foreach (var item in sindup)
            {
                total = total + item.total;
            }
            nmbTotal.Number = (double)total;
        }


        //protected void gpProductos_click(object sender, DirectEventArgs e)
        //{
        //    string json = e.ExtraParams["Values"];
        //    Dictionary<string, string>[] v1 = JSON.Deserialize<Dictionary<string, string>[]>(json);
        //    claseProductos cp = new claseProductos();
        //    tbl_Productos prod = new tbl_Productos(); ;
        //    foreach (Dictionary<string, string> row in v1)
        //    {
        //        prod = cp.buscarProductosPorCod(row["pro_codigo"]);
        //    }
        //    string jsonDV = e.ExtraParams["gridDV"];
        //    Dictionary<string, string>[] v2 = JSON.Deserialize<Dictionary<string, string>[]>(jsonDV);

        //    List<DetalleVenta> listDv = new List<DetalleVenta>();
        //    foreach (Dictionary<string, string> row in v2)
        //    {
        //        DetalleVenta detVen = new DetalleVenta();
        //        detVen.codigo = row["codigo"];
        //        detVen.cantidad = int.Parse(row["cantidad"]);
        //        detVen.descripcion = row["descripcion"];
        //        detVen.precio = decimal.Parse(row["precio"]);
        //        detVen.total = decimal.Parse(row["total"]);
        //        detVen.descuento = decimal.Parse(row["descuento"]);
        //        detVen.porcentajeDescuento = double.Parse(row["porcentajeDescuento"]);
        //        listDv.Add(detVen);
        //    }
        //    DetalleVenta dv = new DetalleVenta();
        //    decimal descuento = 0;
        //    double porcentajeDescuento=0;
        //    foreach (var item in listDv)
        //    {
        //        if (item.codigo == prod.pro_codigo)
        //        {
        //            descuento = item.descuento;
        //            porcentajeDescuento = item.porcentajeDescuento;
        //        }
        //    }
        //    dv.codigo = prod.pro_codigo;
        //    dv.cantidad = 1;
        //    dv.descripcion = prod.pro_descripcion;
        //    dv.precio = (Decimal)prod.pro_precio_venta;
        //    dv.total = (dv.cantidad * dv.precio)-descuento;
        //    dv.descuento = descuento;
        //    dv.porcentajeDescuento = porcentajeDescuento;


        //    foreach (var item in listDv)
        //    {
        //        if (item.descripcion==dv.descripcion)
        //        {
        //            dv.cantidad = item.cantidad + 1;
        //            dv.descuento = (dv.precio * dv.cantidad) * (decimal)(porcentajeDescuento / 100);
        //            dv.porcentajeDescuento = porcentajeDescuento;
        //        }else
        //        {
        //            dv.descuento = (dv.precio * dv.cantidad) * (decimal)(porcentajeDescuento / 100);
        //        }
        //    }

        //    listDv.Add(dv);
        //    var sindup=listDv.GroupBy(elem => elem.descripcion).Select(group => group.Last());
        //    foreach (var item in sindup)
        //    {
        //        item.total = item.cantidad * item.precio- dv.descuento;
        //    }
        //    storeDetalleVenta.DataSource = sindup;
        //    storeDetalleVenta.DataBind();
        //    decimal total = 0;
        //    foreach (var item in sindup)
        //    {
        //        total = total + item.total-dv.descuento;
        //    }
        //    nmbTotal.Number = (double)total;
        //}

        protected void cbxFamilias_Select(object sender, EventArgs e)
        {
            claseProductos cp = new claseProductos();
            String codCmb = cbxFamilias.SelectedItem.Value;
            if (codCmb == "0")
            {
                storeProductos.DataSource = cp.productosActivos();
                storeProductos.DataBind();
            }
            else
            {
                storeProductos.DataSource = cp.buscarProductosPorFamId(int.Parse(codCmb));
                storeProductos.DataBind();
            }

        }

        protected void gpDetalleVenta_click(object sender, DirectEventArgs e)
        {
            this.Window1.Show();
            string json = e.ExtraParams["ValuesDV"];
            Dictionary<string, string>[] v1 = JSON.Deserialize<Dictionary<string, string>[]>(json);
            DetalleVenta dv = new DetalleVenta();
            foreach (Dictionary<string, string> row in v1)
            {
                dv.codigo = row["codigo"];
                dv.cantidad = int.Parse(row["cantidad"]);
                dv.descripcion = row["descripcion"];
                dv.precio = decimal.Parse(row["precio"]);
                dv.total = decimal.Parse(row["total"]);
                dv.descuento= decimal.Parse(row["descuento"]);
                dv.porcentajeDescuento= double.Parse(row["porcentajeDescuento"]);
            }
            hdnModCodigoProducto.Text = dv.codigo;
            nmbModCantidad.Number = dv.cantidad;
            txtModDescripcion.Text = dv.descripcion;
            nmbModPrecio.Number = (double)dv.precio;
            nmbModDescuento.Number = (double)dv.porcentajeDescuento;
            nmbModCantidad.Focus();
        }

        protected void btnAplicarCambios_click(object sender, DirectEventArgs e)
        {
            string json = e.ExtraParams["pmtApliCam"];
            Dictionary<string, string>[] v1 = JSON.Deserialize<Dictionary<string, string>[]>(json);
            List<DetalleVenta> dvList = new List<DetalleVenta>();
            
            foreach (Dictionary<string, string> row in v1)
            {
                DetalleVenta dv = new DetalleVenta();
                dv.codigo = row["codigo"];
                dv.cantidad = int.Parse(row["cantidad"]);
                dv.descripcion = row["descripcion"];
                dv.precio = decimal.Parse(row["precio"]);
                dv.total = decimal.Parse(row["total"]);
                dv.descuento= decimal.Parse(row["descuento"]);
                dv.porcentajeDescuento = double.Parse(row["porcentajeDescuento"]);
                dvList.Add(dv);
            }
            DetalleVenta detV = new DetalleVenta();
            if (nmbModDescuento==null)
            {
                detV.codigo = hdnModCodigoProducto.Text;
                detV.cantidad = (int)nmbModCantidad.Number;
                detV.descripcion = txtModDescripcion.Text;
                detV.precio = (decimal)nmbModPrecio.Number;
                detV.total = detV.cantidad * detV.precio;
                detV.descuento = 0;
                detV.porcentajeDescuento = 0;
            }
            if (nmbModDescuento != null)
            {
                if (nmbModDescuento.Number != 0)
                {

                    detV.codigo = hdnModCodigoProducto.Text;
                    decimal desc = (decimal)nmbModDescuento.Number;
                    detV.cantidad = (int)nmbModCantidad.Number;
                    detV.descripcion = txtModDescripcion.Text;
                    detV.precio = (decimal)nmbModPrecio.Number;
                    decimal descuentoAplicado = (detV.cantidad * detV.precio) * (desc / 100);
                    detV.total = (detV.cantidad * detV.precio) - descuentoAplicado;
                    detV.descuento = descuentoAplicado;
                    detV.porcentajeDescuento = nmbModDescuento.Number;
                }
                else
                {
                    detV.codigo = hdnModCodigoProducto.Text;
                    detV.cantidad = (int)nmbModCantidad.Number;
                    detV.descripcion = txtModDescripcion.Text;
                    detV.precio = (decimal)nmbModPrecio.Number;
                    detV.total = detV.cantidad * detV.precio;
                    detV.descuento = 0;
                    detV.porcentajeDescuento = 0;
                }
               
            }
            
                dvList.Add(detV);
            var sindup = dvList.GroupBy(elem => elem.descripcion).Select(group => group.Last());
            nmbModDescuento.Number = 0;
            this.Window1.Close();
            storeDetalleVenta.DataSource = sindup;
            storeDetalleVenta.DataBind();
            decimal total = 0;
            foreach (var item in sindup)
            {
                total = total + item.total;
            }
            nmbTotal.Number = (double)total;
            fsCatProd.Hidden = false;
            fsFinalizarVenta.Hidden = true;
            nmbCVEntregaCliente.Clear();
            nmbCVDevolucion.Clear();
            btnTerminarVenta.Hidden = true;
        }

        protected void btnSalirSinCambios_click(object sender, EventArgs e)
        {
            nmbModDescuento.Number = 0;
            this.Window1.Close();
        }

        protected void btnBorrarLinea_click(object sender, DirectEventArgs e)
        {
            string json = e.ExtraParams["pmtApliCam"];
            Dictionary<string, string>[] v1 = JSON.Deserialize<Dictionary<string, string>[]>(json);
            List<DetalleVenta> dvList = new List<DetalleVenta>();

            foreach (Dictionary<string, string> row in v1)
            {
                DetalleVenta dv = new DetalleVenta();
                dv.codigo = row["codigo"];
                dv.cantidad = int.Parse(row["cantidad"]);
                dv.descripcion = row["descripcion"];
                dv.precio = decimal.Parse(row["precio"]);
                dv.total = decimal.Parse(row["total"]);
                dvList.Add(dv);
            }
            int cont = 0;
            var itemToRemove = dvList.Single(r => r.descripcion == txtModDescripcion.Text);
            dvList.Remove(itemToRemove);
            nmbModDescuento.Number = 0;
            this.Window1.Close();
            storeDetalleVenta.DataSource = dvList;
            storeDetalleVenta.DataBind();
            decimal total = 0;
            foreach (var item in dvList)
            {
                total = total + item.total;
            }
            nmbTotal.Number = (double)total;
            fsCatProd.Hidden = false;
            fsFinalizarVenta.Hidden = true;
            nmbCVEntregaCliente.Clear();
            nmbCVDevolucion.Clear();
            btnTerminarVenta.Hidden = true;
        }

        protected void imgBtnCobrar_click(object sender, EventArgs e)
        {
            
            if (nmbTotal.Text=="" || nmbTotal.Text=="0")
            {
                
            }
            else
            {
                fsFinalizarVenta.Hidden = false;
                fsCatProd.Hidden = true;
                nmbCVTotalVenta.Number = nmbTotal.Number;
                nmbCVEntregaCliente.Focus();
            }
            
        }

        protected void imgBtnEfectivo_click(object sender, EventArgs e)
        {
            txtCVFormaPagoSeleccionada.Text = "Efectivo";
            nmbCVEntregaCliente.Clear();
        }

        protected void imgBtnDebito_click(object sender, EventArgs e)
        {
            txtCVFormaPagoSeleccionada.Text = "Débito";
            nmbCVEntregaCliente.Number = nmbCVTotalVenta.Number;
        }

        protected void imgBtnCredito_click(object sender, EventArgs e)
        {
            txtCVFormaPagoSeleccionada.Text = "Crédito";
            nmbCVEntregaCliente.Number = nmbCVTotalVenta.Number;
        }

        protected void nmbCVEntregaCliente_change(object sender, EventArgs e)
        {
            if (nmbCVEntregaCliente.Text=="")
            {
                nmbCVDevolucion.Clear();
                btnTerminarVenta.Hidden = true;
            }
            if (nmbCVTotalVenta.Number==nmbCVEntregaCliente.Number)
            {
                nmbCVDevolucion.Number = 0;
                btnTerminarVenta.Hidden = false;
            }
            if (nmbCVTotalVenta.Number<nmbCVEntregaCliente.Number)
            {
                double devolucion = nmbCVEntregaCliente.Number - nmbCVTotalVenta.Number;
                nmbCVDevolucion.Number = devolucion;
                btnTerminarVenta.Hidden = false;
            }
            if (nmbCVEntregaCliente.Number<nmbCVTotalVenta.Number)
            {
                nmbCVDevolucion.Clear();
                btnTerminarVenta.Hidden = true;
            }
        }

        [DirectMethod]
        public void focusBusqueda(int key)
        {
            if (key==113)
            {
                txtBuscarDescripcion.Focus();
            }
            if (key==119)
            {
                txtBuscarCodigo.Focus();
            }
            if (key==121)
            {
                txtBuscarCodBarras.Focus();
            }
        }

        protected void txtBuscarDescripcion_change(object sender, EventArgs e)
        {
            claseProductos cp = new claseProductos();
            storeProductos.DataSource = cp.buscarProductosPorDescripcion(txtBuscarDescripcion.Text);
            storeProductos.DataBind();
        }

        protected void txtBuscarCodigo_change(object sender, EventArgs e)
        {
            claseProductos cp = new claseProductos();
            storeProductos.DataSource = cp.buscarProductosPorCodActivo(txtBuscarCodigo.Text);
            storeProductos.DataBind();
        }

        protected void btnRegresarVenta_click(object sender, EventArgs e)
        {
            fsCatProd.Hidden = false;
            fsFinalizarVenta.Hidden = true;
            nmbCVEntregaCliente.Clear();
            nmbCVDevolucion.Clear();
            btnTerminarVenta.Hidden = true;
        }

        protected void btnTerminarVenta_click(object sender, DirectEventArgs e)
        {
            //guardar Factura Cabecera
            string jsonDV = e.ExtraParams["Values"];
            Dictionary<string, string>[] v2 = JSON.Deserialize<Dictionary<string, string>[]>(jsonDV);
            decimal descuentoTotal = 0;
            foreach (Dictionary<string, string> row in v2)
            {
                descuentoTotal = descuentoTotal + decimal.Parse(row["descuento"]);
            }
            claseFacturacion cf = new claseFacturacion();
            tbl_Factura_Cabecera factCab = new tbl_Factura_Cabecera();
            if (txtCVFormaPagoSeleccionada.Text=="Tarjeta de Débito")
            {
                factCab.fac_forma_pago_codigo = "16";
            }
            if (txtCVFormaPagoSeleccionada.Text == "Tarjeta de Crédito")
            {
                factCab.fac_forma_pago_codigo = "19";
            }
            if (txtCVFormaPagoSeleccionada.Text == "Otros con utilización del Sistema Financiero")
            {
                factCab.fac_forma_pago_codigo = "20";
            }
            if (txtCVFormaPagoSeleccionada.Text == "Sin utilización del Sistema Financiero")
            {
                factCab.fac_forma_pago_codigo = "01";
            }
            if (txtCVFormaPagoSeleccionada.Text == "Compensación de deudas")
            {
                factCab.fac_forma_pago_codigo = "15";
            }
            if (txtCVFormaPagoSeleccionada.Text == "Dinero Electrónico")
            {
                factCab.fac_forma_pago_codigo = "17";
            }
            if (txtCVFormaPagoSeleccionada.Text == "Tarjeta Prepago")
            {
                factCab.fac_forma_pago_codigo = "18";
            }
            if (txtCVFormaPagoSeleccionada.Text == "Endoso de Títulos")
            {
                factCab.fac_forma_pago_codigo = "21";
            }
            factCab.fac_numero_serie = hdnFacturaActual.Text;
            factCab.fac_punto_emision = hdnPuntoEmision.Text;
            factCab.fac_descuento = descuentoTotal;
            factCab.fac_fecha_emision = DateTime.Now;
            factCab.fac_cli_cedula_ruc = hdnRucClienteSeleccionado.Text;
            if (hdnRucClienteSeleccionado.Text=="9999999999999")
            {
                factCab.fac_cli_nombres = "Consumidor";
                factCab.fac_cli_apellidos = "Final";
            }
            else
            {
                claseClientes cc = new claseClientes();
                tbl_Clientes cliente = cc.buscarClientesPorRucCi(hdnRucClienteSeleccionado.Text);
                factCab.fac_cli_nombres = cliente.cli_nombres;
                factCab.fac_cli_apellidos = cliente.cli_apellidos;
            }
            factCab.fac_total = (decimal)nmbTotal.Number;
            double totalImpuestos = nmbTotal.Number * 0.12 ;
            factCab.fac_total_impuestos = (decimal)totalImpuestos;
            factCab.fac_usuario = Session["usuario"].ToString(); 
            string res = cf.guardarFacturaCabecera(factCab);
            if (res=="OK")
            {
                //guardar Factura Detalle
                List<DetalleVenta> listDv = new List<DetalleVenta>();
                foreach (Dictionary<string, string> row in v2)
                {
                    DetalleVenta detVen = new DetalleVenta();
                    detVen.codigo = row["codigo"];
                    detVen.cantidad = int.Parse(row["cantidad"]);
                    detVen.descripcion = row["descripcion"];
                    detVen.precio = decimal.Parse(row["precio"]);
                    detVen.total = decimal.Parse(row["total"]);
                    detVen.descuento = decimal.Parse(row["descuento"]);
                    listDv.Add(detVen);
                }
                List<tbl_Factura_Detalle> facturaDetalle = new List<tbl_Factura_Detalle>();
                foreach (var item in listDv)
                {
                    tbl_Factura_Cabecera fc = cf.buscarFacturaCabeceraPorSerie(hdnFacturaActual.Text);
                    tbl_Factura_Detalle factDet = new tbl_Factura_Detalle();
                    factDet.fad_fac_id = fc.fac_id;
                    factDet.fad_fac_numero_serie = fc.fac_numero_serie;
                    factDet.fad_pro_codigo = item.codigo;
                    factDet.fad_pro_descripcion = item.descripcion;
                    factDet.fad_pro_cantidad = item.cantidad;
                    factDet.fad_pro_precio_venta = item.precio;
                    factDet.fad_pro_descuento = item.descuento;
                    claseProductos cp = new claseProductos();
                    tbl_Productos produc = cp.buscarProductosPorCod(item.codigo);
                    factDet.fac_pro_impuesto = produc.pro_impuesto;
                    facturaDetalle.Add(factDet);
                    
                }
                String resp = cf.guardarFacturaDetalle(facturaDetalle);
                if (resp=="OK")
                {
                    //this.rmProductos.AddScript("Ext.Msg.notify('Guardado Correcto!!', 'Factura generada correctamente!!');");
                    Response.Redirect("Facturacion.aspx");
                }
                
            }

        }

        protected void btnBuscarCliente_click(object sender, EventArgs e)
        {
            this.Window2.Show();
            txtRuc.Focus(true);
        }

        protected void btnWndBuscarCliente_click(object sender, EventArgs e)
        {
            claseClientes cc = new claseClientes();
            storeClientes.DataSource = cc.buscarClientesActivosAsc();
            storeClientes.DataBind();
        }

        protected void txtNombres_change(object sender, EventArgs e)
        {
            if (txtNombres.Text == "")
            {
                storeClientes.DataSource = "";
                storeClientes.DataBind();
            }
            claseClientes cc = new claseClientes();
            storeClientes.DataSource = cc.buscarClientesActivosPorNombreAsc(txtNombres.Text);
            storeClientes.DataBind();
        }

        protected void txtApellidos_change(object sender, EventArgs e)
        {
            if (txtApellidos.Text == "")
            {
                storeClientes.DataSource = "";
                storeClientes.DataBind();
            }
            claseClientes cc = new claseClientes();
            storeClientes.DataSource = cc.buscarClientesActivosPorApellidoAsc(txtApellidos.Text);
            storeClientes.DataBind();
        }

        protected void txtRuc_change(object sender, EventArgs e)
        {
            if (txtRuc.Text=="")
            {
                storeClientes.DataSource = "";
                storeClientes.DataBind();
            }
            claseClientes cc = new claseClientes();
            storeClientes.DataSource = cc.buscarClientesActivosPorRucCiAsc(txtRuc.Text);
            storeClientes.DataBind();
        }

        protected void btnWndSalir_click(object sender, EventArgs e)
        {
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtRuc.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtCorreo.Text = "";
            storeClientes.DataSource = "";
            storeClientes.DataBind();
            this.Window2.Close();
        }

        protected void gdClientes_click(object sender, DirectEventArgs e)
        {
            string json = e.ExtraParams["Values"];
            Dictionary<string, string>[] v1 = JSON.Deserialize<Dictionary<string, string>[]>(json);
            claseClientes cc = new claseClientes();
            tbl_Clientes cli = new tbl_Clientes();
            foreach (Dictionary<string, string> row in v1)
            {
                cli = cc.buscarClientesPorRucCi(row["cli_cedula_ruc"]);
            }
            this.Window2.Close();
            txtCVClienteSeleccionado.Text = cli.cli_nombres + " " + cli.cli_apellidos;
            hdnRucClienteSeleccionado.Text = cli.cli_cedula_ruc;
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtRuc.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtCorreo.Text = "";
            btnWndCrearCliente.Hidden = false;
            btnWndBuscarCliente.Hidden = false;
            btnWndSalir.Hidden = false;
            btnWndGuardarCliente.Hidden = true;
            btnWndCancelar.Hidden = true;
            storeClientes.DataSource = "";
            storeClientes.DataBind();
        }

        protected void btnWndCrearCliente_click(object sender, EventArgs e)
        {
            //txtRuc.Text = "";
            //txtNombres.Text = "";
            //txtApellidos.Text = "";
            //txtDireccion.Text = "";
            //txtTelefono.Text = "";
            //txtCorreo.Text = "";           
            txtTelefono.ReadOnly = false;
            txtDireccion.ReadOnly = false;
            txtCorreo.ReadOnly = false;
            chkEstadoCliente.Checked = true;
            btnWndGuardarCliente.Hidden = false;
            btnWndCancelar.Hidden = false;
            btnWndCrearCliente.Hidden = true;
            btnWndBuscarCliente.Hidden = true;
            btnWndSalir.Hidden = true;
            txtNombres.Focus();
        }

        protected void btnWndGuardarCliente_click(object sender, EventArgs e)
        {
            if (txtApellidos.Text!="" && txtNombres.Text != "" && txtRuc.Text != "" && txtTelefono.Text != "" && txtDireccion.Text != "" && txtCorreo.Text != "")
            {
                claseClientes cc = new claseClientes();
                tbl_Clientes cli = new tbl_Clientes();
                cli.cli_cedula_ruc = txtRuc.Text;
                cli.cli_nombres = txtNombres.Text;
                cli.cli_apellidos = txtApellidos.Text;
                cli.cli_telefono = txtTelefono.Text;
                cli.cli_direccion = txtDireccion.Text;
                cli.cli_correo = txtCorreo.Text;
                cli.cli_usuario= Session["usuario"].ToString();
                if (chkEstadoCliente.Checked == true)
                {
                    cli.cli_estado = "Activo";
                }
                else
                {
                    cli.cli_estado = "Inactivo";
                }
                tbl_Clientes clienteExistente = cc.buscarClientesPorRucCi(cli.cli_cedula_ruc);
                int cliId = 0;
                if (clienteExistente != null)
                {
                    X.MessageBox.Alert("Error al crear cliente!!", "El cliente ya existe!!").Show();
                }
                else
                {
                    string resp = cc.crearClientes(cli, 0);
                    if (resp == "OK")
                    {
                        txtNombres.Text = "";
                        txtApellidos.Text = "";
                        txtRuc.Text = "";
                        txtTelefono.Text = "";
                        txtDireccion.Text = "";
                        txtCorreo.Text = "";
                        chkEstadoCliente.Checked = true;
                        btnWndGuardarCliente.Hidden = true;
                        btnWndCancelar.Hidden = true;
                        btnWndCrearCliente.Hidden = false;
                        btnWndBuscarCliente.Hidden = false;
                        btnWndSalir.Hidden = false;
                        this.Window2.Close();
                        txtCVClienteSeleccionado.Text = cli.cli_nombres + " " + cli.cli_apellidos;
                        hdnRucClienteSeleccionado.Text = cli.cli_cedula_ruc;
                        this.rmProductos.AddScript("Ext.Msg.notify('Guardado Correcto!!', 'Registro guardado correctamente');");
                    }
                }
            }
        }

        protected void btnWndCancelar_click(object sender, EventArgs e)
        {
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtRuc.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtCorreo.Text = "";
            chkEstadoCliente.Checked = true;
            btnWndGuardarCliente.Hidden = true;
            btnWndCancelar.Hidden = true;
            btnWndCrearCliente.Hidden = false;
            btnWndBuscarCliente.Hidden = false;
            btnWndSalir.Hidden = false;
            txtRuc.Focus();
        }


        protected void txtBuscarCodBarras_change(object sender, DirectEventArgs e)
        {
            try
            {
                claseProductos cp = new claseProductos();
                tbl_Productos prod = cp.buscarProductosPorCodBarras(txtBuscarCodBarras.Text);

                string jsonDV = e.ExtraParams["gridDV"];
                Dictionary<string, string>[] v2 = JSON.Deserialize<Dictionary<string, string>[]>(jsonDV);

                List<DetalleVenta> listDv = new List<DetalleVenta>();
                foreach (Dictionary<string, string> row in v2)
                {
                    DetalleVenta detVen = new DetalleVenta();
                    detVen.cantidad = int.Parse(row["cantidad"]);
                    detVen.descripcion = row["descripcion"];
                    detVen.precio = decimal.Parse(row["precio"]);
                    detVen.total = decimal.Parse(row["total"]);
                    listDv.Add(detVen);
                }

                DetalleVenta dv = new DetalleVenta();

                dv.cantidad = 1;
                dv.descripcion = prod.pro_descripcion;
                dv.precio = (Decimal)prod.pro_precio_venta;
                dv.total = dv.cantidad * dv.precio;

                foreach (var item in listDv)
                {
                    if (item.descripcion == dv.descripcion)
                    {
                        dv.cantidad = item.cantidad + 1;
                    }
                }

                listDv.Add(dv);
                var sindup = listDv.GroupBy(elem => elem.descripcion).Select(group => group.Last());
                foreach (var item in sindup)
                {
                    item.total = item.cantidad * item.precio;
                }
                storeDetalleVenta.DataSource = sindup;
                storeDetalleVenta.DataBind();
                decimal total = 0;
                foreach (var item in sindup)
                {
                    total = total + item.total;
                }
                nmbTotal.Number = (double)total;
                txtBuscarCodBarras.Text = "";
                txtBuscarCodBarras.Focus();
            }catch(Exception ex)
            {

            }

        }

        protected void btnBorrarVenta_click(object sender, EventArgs e)
        {
            Response.Redirect("Facturacion.aspx");
        }

        protected void imgBtnSinUsoSF_click(object sender, EventArgs e)
        {
            txtCVFormaPagoSeleccionada.Text = "Sin utilización del Sistema Financiero";
            nmbCVEntregaCliente.Reset();
        }

        protected void imgBtnDineroElectronico_click(object sender, EventArgs e)
        {
            txtCVFormaPagoSeleccionada.Text = "Dinero Electrónico";
            nmbCVEntregaCliente.Number = nmbCVTotalVenta.Number;
        }

        protected void imgBtnTarjetaPrepago_click(object sender, EventArgs e)
        {
            txtCVFormaPagoSeleccionada.Text = "Tarjeta Prepago";
            nmbCVEntregaCliente.Number = nmbCVTotalVenta.Number;
        }

        protected void imgBtnCompensacionDeudas_click(object sender, EventArgs e)
        {
            txtCVFormaPagoSeleccionada.Text = "Compensación de deudas";
            nmbCVEntregaCliente.Reset();
        }

        protected void imgBtnEndosoTitulos_click(object sender, EventArgs e)
        {
            txtCVFormaPagoSeleccionada.Text = "Endoso de Títulos";
            nmbCVEntregaCliente.Reset();
        }

        protected void imgBtnOtrosConUsoSF_click(object sender, EventArgs e)
        {
            txtCVFormaPagoSeleccionada.Text = "Otros con utilización del Sistema Financiero";
            nmbCVEntregaCliente.Reset();
        }

        protected void imgBtnTarjetaCredito_click(object sender, EventArgs e)
        {
            txtCVFormaPagoSeleccionada.Text = "Tarjeta de Crédito";
            nmbCVEntregaCliente.Number = nmbCVTotalVenta.Number;
        }

        protected void imgBtnTarjetaDebito_click(object sender, EventArgs e)
        {
            txtCVFormaPagoSeleccionada.Text = "Tarjeta de Débito";
            nmbCVEntregaCliente.Number = nmbCVTotalVenta.Number;

        }
    }
}