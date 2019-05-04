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
    public partial class IngresoProveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String nombre = Session["usuario"].ToString();
                if (!X.IsAjaxRequest)
                {
                    claseProveedores cp = new claseProveedores();

                    storeProveedores.DataSource = cp.storeProveedores();
                    storeProveedores.DataBind();
                    btnGuardar.Hidden = true;
                    btnCancelar.Hidden = true;
                    claseProveedores clProv = new claseProveedores();

                    foreach (var item in clProv.storeProveedores())
                    {
                        txtRazonSocial.Text = item.prv_razon_social;
                        txtRuc.Text = item.prv_ruc;
                        txtTelefono.Text = item.prv_telefono;
                        txtDireccion.Text = item.prv_direccion;
                        txtCorreo.Text = item.prv_email;
                        txtPaginaWeb.Text = item.prv_pagina_web;
                        if (item.prv_estado.Equals("Activo"))
                        {
                            chkEstadoProveedor.Checked = true;
                        }
                        if (item.prv_estado.Equals("Inactivo"))
                        {
                            chkEstadoProveedor.Checked = false;
                        }
                        hdnProvId.Text = item.prv_id.ToString();
                        break;
                    }


                }
            }
            catch
            {
                Response.Redirect("Login.aspx?men=1");
            }

        }

  
        protected void btnGuardar_click(object sender, EventArgs e)
        {
            claseProveedores cp = new claseProveedores();
            TpvSignoEntities tse = new TpvSignoEntities();
            Boolean checkeado = chkEstadoProveedor.Checked;
            String estadoProveedor = "";
            if (checkeado==true)
            {
                estadoProveedor = "Activo";
            }
            else
            {
                estadoProveedor = "Inactivo";
            }
            tbl_Proveedores proveedores = new tbl_Proveedores
            {
                prv_ruc = txtRuc.Text,
                prv_razon_social = txtRazonSocial.Text,
                prv_direccion = txtDireccion.Text,
                prv_estado = estadoProveedor,
                prv_email = txtCorreo.Text,
                prv_pagina_web = txtPaginaWeb.Text,
                prv_telefono = txtTelefono.Text,
                prv_usuario = Session["usuario"].ToString()
        };
            int prv_id;
            try
            {
                prv_id = int.Parse(hdnProvId.Text);
            }
            catch
            {
                prv_id = 0;
            }
            String respuesta = cp.crearProveedores(proveedores, prv_id);
            if (respuesta=="OK")
            {
                storeProveedores.DataSource = cp.storeProveedores();
                storeProveedores.DataBind();

                btnGuardar.Hidden = true;
                btnCancelar.Hidden = true;
                btnNuevoProveedor.Hidden = false;
                btnEliminar.Hidden = false;
                txtRazonSocial.Text = "";
                txtRuc.Text = "";
                txtTelefono.Text = "";
                txtDireccion.Text = "";
                txtCorreo.Text = "";
                txtPaginaWeb.Text = "";
                chkEstadoProveedor.Checked = true;
                hdnProvId.Text = "";
                this.rmProveedores.AddScript("Ext.Msg.notify('Guardado Correcto!!', 'Registro guardado correctamente');");
            }
            else
            {
                if (respuesta.Contains("Violation of UNIQUE KEY constraint") == true)
                {
                    X.MessageBox.Alert("Error al guardar!!", "Ya existe un proveedor con RUC " + txtRuc.Text ).Show();
                }
                else
                {
                    X.MessageBox.Alert("Error al guardar!!", respuesta).Show();
                }
            }
        }

        protected void btnEliminar_click(object sender, EventArgs e)
        {
            String json = "";
            json = "[{RUC:" + txtRuc.Text + "}]";
            X.Msg.Confirm("Atención!!", "Esta seguro de eliminar el proveedor " + txtRazonSocial.Text + "?", new MessageBoxButtonsConfig
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
            String ruc = "";
            claseProveedores cp = new claseProveedores();
            
            Dictionary<string, string>[] fcp = JSON.Deserialize<Dictionary<string, string>[]>(json);
            foreach (Dictionary<string, string> row in fcp)
            {
                ruc = row["RUC"];
            }
            tbl_Proveedores proveedores = cp.buscarProveedoresPorRUC(ruc);
            String respuesta=cp.eliminarProveedor(proveedores);
            if (respuesta.Equals("OK"))
            {
                storeProveedores.DataSource = cp.storeProveedores();
                storeProveedores.DataBind();

                txtRuc.Text = "";
                txtRazonSocial.Text = "";
                txtTelefono.Text = "";
                txtDireccion.Text = "";
                txtCorreo.Text = "";
                txtPaginaWeb.Text = "";
                chkEstadoProveedor.Checked = true;
                this.rmProveedores.AddScript("Ext.Msg.notify('Eliminación correcta!!', 'Registro eliminado correctamente');");
            }
            else
            {
                X.MessageBox.Alert("Error al eliminar proveedor!!", respuesta).Show();
            }
        }
        

        protected void gdProveedores_click(object sender, DirectEventArgs e)
        {
            btnGuardar.Hidden = true;
            btnEliminar.Hidden = false;
            btnNuevoProveedor.Hidden = false;
            btnCancelar.Hidden = true;
            claseProveedores cp = new claseProveedores();
            tbl_Proveedores prov= new tbl_Proveedores();
            string json = e.ExtraParams["Values"];
            Dictionary<string, string>[] v1 = JSON.Deserialize<Dictionary<string, string>[]>(json);
            foreach (Dictionary<string, string> row in v1)
            {
                prov = cp.buscarProveedoresPorRUC(row["prv_ruc"]);
            }
            txtRazonSocial.Text = prov.prv_razon_social;
            txtRuc.Text = prov.prv_ruc;
            txtTelefono.Text = prov.prv_telefono;
            txtDireccion.Text = prov.prv_direccion;
            txtCorreo.Text = prov.prv_email;
            txtPaginaWeb.Text = prov.prv_pagina_web;
            hdnProvId.Text = prov.prv_id.ToString();
            if (prov.prv_estado.Equals("Activo"))
            {
                chkEstadoProveedor.Checked = true;
            }
            if (prov.prv_estado.Equals("Inactivo"))
            {
                chkEstadoProveedor.Checked = false;
            }

        }

        protected void btnNuevoProveedor_click(object sender, EventArgs e)
        {
            hdnProvId.Text = "";
            txtRuc.Text = "";
            txtRazonSocial.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtCorreo.Text = "";
            txtPaginaWeb.Text = "";
            chkEstadoProveedor.Checked = true;
            btnNuevoProveedor.Hidden = true;
            btnEliminar.Hidden = true;
            btnGuardar.Hidden = false;
            btnCancelar.Hidden = false;
            
        }

        protected void btnCancelar_click(object sender, EventArgs e)
        {
            btnCancelar.Hidden = true;
            btnGuardar.Hidden = true;
            btnNuevoProveedor.Hidden = false;
            btnEliminar.Hidden = false;
            claseProveedores clProv = new claseProveedores();

            foreach (var item in clProv.storeProveedores())
            {
                txtRazonSocial.Text = item.prv_razon_social;
                txtRuc.Text = item.prv_ruc;
                txtTelefono.Text = item.prv_telefono;
                txtDireccion.Text = item.prv_direccion;
                txtCorreo.Text = item.prv_email;
                txtPaginaWeb.Text = item.prv_pagina_web;
                if (item.prv_estado.Equals("Activo"))
                {
                    chkEstadoProveedor.Checked = true;
                }
                if (item.prv_estado.Equals("Inactivo"))
                {
                    chkEstadoProveedor.Checked = false;
                }
                break;
            }
        }

        [DirectMethod]
        public void mostrarBotonGuardar()
        {
            btnNuevoProveedor.Hidden = true;
            btnEliminar.Hidden = true;
            btnGuardar.Hidden = false;
            btnCancelar.Hidden = false;
        }

        protected void txtBuscarPorRuc_change(object sender, EventArgs e)
        {
            claseProveedores cp = new claseProveedores();
            storeProveedores.DataSource = cp.buscarProveedoresPorRUCContains(txtBuscarPorRuc.Text);
            storeProveedores.DataBind();
        }

        protected void txtBuscarPorRazonSocial_change(object sender, EventArgs e)
        {
            claseProveedores cp = new claseProveedores();
            storeProveedores.DataSource = cp.buscarProveedoresPorRazonSocialContains(txtBuscarPorRazonSocial.Text);
            storeProveedores.DataBind();
        }
    }
}