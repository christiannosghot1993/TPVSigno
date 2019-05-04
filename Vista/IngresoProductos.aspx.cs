using Ext.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;
using Ext.Net;
using Controlador;
using System.Drawing;

namespace Vista
{
    public partial class IngresoProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String nombre = Session["usuario"].ToString();
                if (!X.IsAjaxRequest)
                {
                    txtBuscarDescripcion.Focus();
                    btnCancelar.Hidden = true;
                    btnGuardar.Hidden = true;
                    claseProductos cp = new claseProductos();
                    storeProductos.DataSource = cp.storeProductos();
                    storeProductos.DataBind();
                    claseProveedores cprv = new claseProveedores();
                    storeProveedor.DataSource = cprv.storeProveedoresActivos();
                    storeProveedor.DataBind();
                    claseFamilias cf = new claseFamilias();
                    storeCategorias.DataSource = cf.storeFamilias();
                    storeCategorias.DataBind();
                    storeProductos.DataSource = cp.storeProductos();
                    storeProductos.DataBind();
                    List<tbl_Productos> prod = cp.storeProductos();
                    if (prod.Count() != 0)
                    {
                        foreach (var item in prod)
                        {
                            hdnIdProducto.Text = item.pro_id.ToString();
                            hdnPathImg.Text = item.pro_imagen_path;
                            txtCodigoProducto.Text = item.pro_codigo;
                            txDescripcion.Text = item.pro_descripcion;
                            cbxProveedores.SetValue(item.pro_prv_id);
                            cbxCategorias.SetValue(item.pro_fam_id);
                            nmbCoste.Number = (double)item.pro_coste;
                            nmbPrecioVenta.Number = (double)item.pro_precio_venta;
                            nmbStockActual.Number = (double)item.pro_stock_actual;
                            nmbStockMinimo.Number = (double)item.pro_stock_minimo;
                            txtImpuesto.Text = item.pro_impuesto.ToString();
                            txtCodBarras.Text = item.pro_codigo_barras;
                            try
                            {
                                this.imgProducto.ImageUrl = "data:image;base64," + Convert.ToBase64String(item.pro_imagen);
                            }
                            catch
                            {
                            }
                            if (item.pro_estado == "Activo")
                            {
                                chkEstadoProdcuto.Checked = true;
                            }
                            else
                            {
                                chkEstadoProdcuto.Checked = false;
                            }
                            break;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Login.aspx?men=1");
            }
}

        protected void fuFotografia_click(object sender, DirectEventArgs e)
        {

        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        protected void fuFotografia_change(object sender, EventArgs e)
        {
            hdnPathImg.Text = "";
            string filename = Path.GetFileName(fuFotografia.PostedFile.FileName);
            string filePath = HttpContext.Current.Server.MapPath("~/Archivos/" + filename);
            Session["path"] = filePath;
            System.Drawing.Image newImage;
            fuFotografia.PostedFile.SaveAs(filePath);
            newImage = System.Drawing.Image.FromFile(filePath);
            byte[] imageByteArray = imageToByteArray(newImage);//esto se guarda en la base
            this.imgProducto.ImageUrl = "data:image;base64," + Convert.ToBase64String(imageByteArray);
            fuFotografia.Text = filePath;
        }

        protected void btnNuevoProducto_click(object sender, EventArgs e)
        {
            hdnPathImg.Text="";
            hdnIdProducto.Text = "";
            btnEliminar.Hidden = true;
            btnNuevoProducto.Hidden = true;
            btnGuardar.Hidden = false;
            btnCancelar.Hidden = false;
            txtCodBarras.Text = "";
            txtCodigoProducto.Text = "";
            txDescripcion.Text = "";
            cbxProveedores.Clear();
            cbxCategorias.Clear();
            nmbCoste.Clear();
            nmbPrecioVenta.Clear();
            nmbStockActual.Clear();
            nmbStockMinimo.Clear();
            txtImpuesto.Text = "";
            chkEstadoProdcuto.Checked = true;
            this.imgProducto.ImageUrl = "";
            chkEstadoProdcuto.Checked = true;
        }

        private static System.Drawing.Image RedimensionarImagen(System.Drawing.Image imagen)
        {
            // Se crea un objeto Image, que contiene las propiedades de la imagen
            System.Drawing.Image img = imagen;

            // Tamaño máximo de la imagen (altura o anchura)
            const int max = 200;

            int h = img.Height;
            int w = img.Width;
            int newH, newW;

            if (h > w && h > max)
            {
                // Si la imagen es vertical y la altura es mayor que max,
                // se redefinen las dimensiones.
                newH = max;
                newW = (w * max) / h;
            }
            else if (w > h && w > max)
            {
                // Si la imagen es horizontal y la anchura es mayor que max,
                // se redefinen las dimensiones.
                newW = max;
                newH = (h * max) / w;
            }
            else
            {
                newH = h;
                newW = w;
            }
            if (h != newH && w != newW)
            {
                // Si las dimensiones cambiaron, se modifica la imagen
                Bitmap newImg = new Bitmap(img, newW, newH);
                Graphics g = Graphics.FromImage(newImg);
                g.InterpolationMode =
                  System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                g.DrawImage(img, 0, 0, newImg.Width, newImg.Height);
                return newImg;
            }
            else
                return img;
        }

        protected void btnGuardar_click(object sender, EventArgs e)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            claseProductos cp = new claseProductos();
            Boolean checkeado = chkEstadoProdcuto.Checked;
            String estado = "";
            if (checkeado==true)
            {
                estado = "Activo";
            }
            else
            {
                estado = "Inactivo";
            }
            tbl_Productos productos = new tbl_Productos();
            productos.pro_usuario = Session["usuario"].ToString();
            productos.pro_codigo = txtCodigoProducto.Text;
            productos.pro_descripcion = txDescripcion.Text;
            productos.pro_prv_id = int.Parse(cbxProveedores.SelectedItem.Value);
            productos.pro_fam_id = int.Parse(cbxCategorias.SelectedItem.Value);
            productos.pro_coste = decimal.Parse(nmbCoste.Number.ToString());
            productos.pro_precio_venta = decimal.Parse(nmbPrecioVenta.Number.ToString());
            productos.pro_estado = estado;
            productos.pro_stock_actual = int.Parse(nmbStockActual.Number.ToString());
            productos.pro_stock_minimo = int.Parse(nmbStockMinimo.Number.ToString());
            productos.pro_impuesto = decimal.Parse(txtImpuesto.Text);
            productos.pro_codigo_barras = txtCodBarras.Text;
            if (hdnPathImg.Text != "")
            {
                System.Drawing.Image newImage;
                newImage = System.Drawing.Image.FromFile(hdnPathImg.Text);
                System.Drawing.Image newImageRedimensionada = RedimensionarImagen(newImage);
                byte[] imageByteArray = imageToByteArray(newImageRedimensionada);
                productos.pro_imagen_path = hdnPathImg.Text;
                productos.pro_imagen = imageByteArray;
            }
            else
            {
                try {
                    var filePath = Session["path"].ToString();
                    System.Drawing.Image newImage;
                    newImage = System.Drawing.Image.FromFile(filePath);
                    System.Drawing.Image newImageRedimensionada = RedimensionarImagen(newImage);
                    byte[] imageByteArray = imageToByteArray(newImageRedimensionada);
                    productos.pro_imagen_path = filePath;
                    productos.pro_imagen = imageByteArray;
                }catch{
                   
                }
                
            }
            int pro_id;
            try
            {
                pro_id = int.Parse(hdnIdProducto.Text);
            }catch(Exception ex)
            {
                pro_id = 0;
            }
            
            String respuesta = cp.crearProductos(productos, pro_id);
            if (respuesta=="OK")
            {
                this.rmProductos.AddScript("Ext.Msg.notify('Guardado Correcto!!', 'Registro guardado correctamente');");
                hdnPathImg.Text = "";
                Session["path"] = "";
                txtCodigoProducto.Text = "";
                txDescripcion.Text = "";
                cbxProveedores.Clear();
                cbxCategorias.Clear();
                nmbCoste.Clear();
                nmbPrecioVenta.Clear();
                txtCodBarras.Text = "";
                nmbStockActual.Clear();
                nmbStockMinimo.Clear();
                txtImpuesto.Text = "";
                this.imgProducto.ImageUrl = "";
                chkEstadoProdcuto.Checked = true;
                storeProductos.DataSource = cp.storeProductos();
                storeProductos.DataBind();
            }
            else
            {
                if (respuesta.Contains("Violation of UNIQUE KEY constraint")==true)
                {
                    X.MessageBox.Alert("Error al guardar!!", "Ya existe un producto con descripción "+txDescripcion.Text+" o con código "+txtCodigoProducto.Text).Show();
                }
                else
                {
                    X.MessageBox.Alert("Error al guardar!!", respuesta).Show();
                }
                
            }
        }

        protected void btnCancelar_click(object sender, EventArgs e)
        {
            claseProductos cp = new claseProductos();
            List<tbl_Productos> prod = cp.storeProductos();
            if (prod.Count() != 0)
            {
                foreach (var item in prod)
                {
                    txtCodigoProducto.Text = item.pro_codigo;
                    txDescripcion.Text = item.pro_descripcion;
                    cbxProveedores.SetValue(item.pro_prv_id);
                    cbxCategorias.SetValue(item.pro_fam_id);
                    txtCodBarras.Text = item.pro_codigo_barras;
                    nmbCoste.Number = (double)item.pro_coste;
                    nmbPrecioVenta.Number = (double)item.pro_precio_venta;
                    nmbStockActual.Number = (double)item.pro_stock_actual;
                    nmbStockMinimo.Number = (double)item.pro_stock_minimo;
                    txtImpuesto.Text = item.pro_impuesto.ToString();
                    this.imgProducto.ImageUrl = "data:image;base64," + Convert.ToBase64String(item.pro_imagen);
                    hdnPathImg.Text = item.pro_imagen_path;
                    if (item.pro_estado == "Activo")
                    {
                        chkEstadoProdcuto.Checked = true;
                    }
                    else
                    {
                        chkEstadoProdcuto.Checked = false;
                    }
                    break;
                }
                btnCancelar.Hidden = true;
                btnGuardar.Hidden = true;
                btnNuevoProducto.Hidden = false;
                btnEliminar.Hidden = false;
            }
        }

        protected void gpProductos_click(object sender, DirectEventArgs e)
        {
            string json = e.ExtraParams["Values"];
            Dictionary<string, string>[] v1 = JSON.Deserialize<Dictionary<string, string>[]>(json);
            claseProductos cp = new claseProductos();
            tbl_Productos prod = new tbl_Productos();
            foreach (Dictionary<string, string> row in v1)
            {
                prod = cp.buscarProductosPorCod(row["pro_codigo"]);
            }
            hdnPathImg.Text=prod.pro_imagen_path;
            hdnIdProducto.Text = prod.pro_id.ToString(); 
            txtCodigoProducto.Text = prod.pro_codigo;
            txDescripcion.Text = prod.pro_descripcion;
            cbxProveedores.SetValue(prod.pro_prv_id);
            cbxCategorias.SetValue(prod.pro_fam_id);
            txtCodBarras.Text = prod.pro_codigo_barras;
            nmbCoste.Number = (double)prod.pro_coste;
            nmbPrecioVenta.Number = (double)prod.pro_precio_venta;
            nmbStockActual.Number = (double)prod.pro_stock_actual;
            nmbStockMinimo.Number = (double)prod.pro_stock_minimo;
            txtImpuesto.Text = prod.pro_impuesto.ToString();
            try
            {
                this.imgProducto.ImageUrl = "data:image;base64," + Convert.ToBase64String(prod.pro_imagen);
            }
            catch
            {
                this.imgProducto.ImageUrl = "";
            }
            string cheched = prod.pro_estado;
            if (cheched.Equals("Activo"))
            {
                chkEstadoProdcuto.Checked = true;
            }
            else
            {
                chkEstadoProdcuto.Checked = false;
            }
            btnGuardar.Hidden = true;
            btnCancelar.Hidden = true;
            btnNuevoProducto.Hidden = false;
            btnEliminar.Hidden = false;
        }

        [DirectMethod]
        public void mostrarBotonGuardar()
        {
            btnNuevoProducto.Hidden = true;
            btnEliminar.Hidden = true;
            btnGuardar.Hidden = false;
            btnCancelar.Hidden = false;
        }

        protected void btnEliminar_click(object sender, EventArgs e)
        {
            String json = "";
            json = "[{pro_id:" + hdnIdProducto.Text + "}]";
            X.Msg.Confirm("Atención!!", "Esta seguro de eliminar el producto " + txDescripcion.Text + "?", new MessageBoxButtonsConfig
            {
                Yes = new MessageBoxButtonConfig
                {
                    Handler = "App.direct.yes(" + json + ")",
                    Text = "Yes"
                },
                No = new MessageBoxButtonConfig
                {
                    Handler = "WndwEdit.close()",
                    Text = "No"
                }
            }).Show();
        }

        [DirectMethod]
        public void yes(String json)
        {
            String pro_id = "";
            claseProductos cp = new claseProductos();

            Dictionary<string, string>[] fcp = JSON.Deserialize<Dictionary<string, string>[]>(json);
            foreach (Dictionary<string, string> row in fcp)
            {
                pro_id = row["pro_id"];
            }
            tbl_Productos productos = cp.buscarProductosPorId(int.Parse(pro_id));
            String respuesta = cp.eliminarProductos(productos);
            if (respuesta.Equals("OK"))
            {
                storeProductos.DataSource = cp.storeProductos();
                storeProductos.DataBind();
                txtCodigoProducto.Text = "";
                txDescripcion.Text = "";
                txtCodBarras.Text = "";
                cbxProveedores.Clear();
                cbxCategorias.Clear();
                nmbCoste.Clear();
                nmbPrecioVenta.Clear();
                nmbStockActual.Clear();
                nmbStockMinimo.Clear();
                txtImpuesto.Text = "";
                this.imgProducto.ImageUrl = "";
                chkEstadoProdcuto.Checked = true;
                this.rmProductos.AddScript("Ext.Msg.notify('Eliminación correcta!!', 'Registro eliminado correctamente');");
            }
            else
            {
                X.MessageBox.Alert("Error al eliminar proveedor!!", respuesta).Show();
            }
        }

        protected void txtBuscarDescripcion_change(object sender, EventArgs e)
        {
            claseProductos cp = new claseProductos();
            storeProductos.DataSource = cp.buscarProductosPorDescripcionActivoInactivo(txtBuscarDescripcion.Text);
            storeProductos.DataBind();
        }

        protected void txtBuscarCodigo_change(object sender, EventArgs e)
        {
            claseProductos cp = new claseProductos();
            storeProductos.DataSource = cp.buscarProductosPorCodActivoInactivo(txtBuscarCodigo.Text);
            storeProductos.DataBind();
        }
    }
}