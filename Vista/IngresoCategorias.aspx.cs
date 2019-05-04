using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controlador;
using Ext.Net;
using Modelo;

namespace Vista
{
    public partial class IngresoCategorías : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
       {
            try
            {
                String nombre = Session["usuario"].ToString();
                if (!X.IsAjaxRequest)
                {
                    claseFamilias cf = new claseFamilias();
                    storeCategorias.DataSource = cf.storeFamilias();
                    storeCategorias.DataBind();
                    chkEstadoCategoria.Checked = true;
                    btnGuardar.Hidden = true;
                    btnCancelar.Hidden = true;
                    foreach (var item in cf.storeFamilias())
                    {
                        txNombreCategoría.Text = item.fam_descripcion;
                        hdnFamId.Text = item.fam_id.ToString();
                        break;
                    }

                }
            }
            catch
            {
                Response.Redirect("Login.aspx?men=1");
            }
        }


        protected void gdCategorias_click(object sender, DirectEventArgs e)
        {
            btnNuevaCategoria.Hidden = false;
            btnEliminar.Hidden = false;
            btnGuardar.Hidden = true;
            btnCancelar.Hidden = true;
            claseFamilias cf = new claseFamilias();
            tbl_Familias familias = new tbl_Familias();
            string json = e.ExtraParams["Values"];
            Dictionary<string, string>[] v1 = JSON.Deserialize<Dictionary<string, string>[]>(json);
            foreach (Dictionary<string, string> row in v1)
            {
                familias = cf.buscarFamiliasPorDescripcion(row["fam_descripcion"]);
            }
            hdnFamId.Text = familias.fam_id.ToString();
            txNombreCategoría.Text = familias.fam_descripcion;
            if (familias.fam_estado.Equals("Activo"))
            {
                chkEstadoCategoria.Checked = true;
            }
            if (familias.fam_estado.Equals("Inactivo"))
            {
                chkEstadoCategoria.Checked = false;
            }

        }

        protected void btnGuardar_click(object sender, DirectEventArgs e)
        {
            claseFamilias cf = new claseFamilias();
            String estado = "";
            if (chkEstadoCategoria.Checked)
            {
                estado = "Activo";
            }
            else
            {
                estado = "Inactivo";
            }
            
            tbl_Familias familias = new tbl_Familias
            {
                fam_descripcion = txNombreCategoría.Text,
                fam_estado = estado,
                fam_usuario = Session["usuario"].ToString()
        };
            int fam_id;
            try
            {
                fam_id = int.Parse(hdnFamId.Text);
            }catch(Exception ex)
            {
                fam_id = 0;
            }
            String respuesta = cf.crearFamilia(familias, fam_id);
            if (respuesta == "OK")
            {
                //X.MessageBox.Alert("Guardado Correcto!!", "La categoría se guardo correctamente.").Show();
                storeCategorias.DataSource = cf.storeFamilias();
                storeCategorias.DataBind();
                //gdCategorias.Reload();
                hdnFamId.Text = "";
                txNombreCategoría.Text = "";
                chkEstadoCategoria.Checked = true;
                btnGuardar.Hidden = true;
                btnCancelar.Hidden = true;
                btnNuevaCategoria.Hidden = false;
                btnEliminar.Hidden = false;
                this.rmCategorias.AddScript("Ext.Msg.notify('Guardado Correcto!!', 'Registro guardado correctamente');");
            }
            else
            {
                if (respuesta.Contains("Violation of UNIQUE KEY constraint") == true)
                {
                    X.MessageBox.Alert("Error al guardar!!", "La categoría " + txNombreCategoría.Text + " ya existe!!").Show();
                }
                else
                {
                    X.MessageBox.Alert("Error al guardar!!", respuesta).Show();
                }
            }
        }

        protected void btnCancelar_click(object sender, EventArgs e)
        {
            btnCancelar.Hidden = true;
            btnGuardar.Hidden = true;
            btnNuevaCategoria.Hidden = false;
            btnEliminar.Hidden = false;
            chkEstadoCategoria.Checked = true;
            claseFamilias cf = new claseFamilias();
            foreach (var item in cf.storeFamilias())
            {
                txNombreCategoría.Text = item.fam_descripcion;
                break;
            }
        }

        protected void btnNuevaCategoria_click(object sender, EventArgs e)
        {
            txNombreCategoría.Text = "";
            btnNuevaCategoria.Hidden = true;
            btnEliminar.Hidden = true;
            chkEstadoCategoria.Checked = true;
            hdnFamId.Text = "";
            btnGuardar.Hidden = false;
            btnCancelar.Hidden = false;
        }

        protected void btnEliminar_click(object sender, EventArgs e)
        {
            String json = "";
            json = "[{fam_id:" + hdnFamId.Text + "}]";
            X.Msg.Confirm("Atención!!", "Esta seguro de eliminar la categoría " + txNombreCategoría.Text + "?", new MessageBoxButtonsConfig
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
        public void mostrarBotonGuardar()
        {
            btnCancelar.Hidden = false;
            btnGuardar.Hidden = false;
            btnNuevaCategoria.Hidden = true;
            btnEliminar.Hidden = true;
        }

        [DirectMethod]
        public void yes(String json)
        {
            String fam_id = "";
            claseFamilias cf = new claseFamilias();

            Dictionary<string, string>[] fcp = JSON.Deserialize<Dictionary<string, string>[]>(json);
            foreach (Dictionary<string, string> row in fcp)
            {
                fam_id = row["fam_id"];
            }
            tbl_Familias familias = cf.buscarFamiliasPorId(int.Parse(fam_id));
            String respuesta = cf.eliminarFamilia(familias);
            if (respuesta.Equals("OK"))
            {
                storeCategorias.DataSource = cf.storeFamilias();
                storeCategorias.DataBind();
                chkEstadoCategoria.Checked = true;
                txNombreCategoría.Text = "";
                this.rmCategorias.AddScript("Ext.Msg.notify('Eliminación correcta!!', 'Registro eliminado correctamente');");
            }
            else
            {
                X.MessageBox.Alert("Error al eliminar proveedor!!", respuesta).Show();
            }
        }

        protected void txtBuscarCategoria_change(object sender, EventArgs e)
        {
            claseFamilias cf = new claseFamilias();
            List<tbl_Familias> familias= cf.buscarFamiliasPorDescripcionContains(txtBuscarCategoria.Text);
            storeCategorias.DataSource = familias;
            storeCategorias.DataBind();
        }
    }
}