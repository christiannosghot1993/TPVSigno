using Ext.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;
using Controlador;

namespace Vista
{
    public partial class IngresoClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String nombre = Session["usuario"].ToString();
                if (!X.IsAjaxRequest)
                {
                    claseClientes cc = new claseClientes();
                    storeClientes.DataSource = cc.storeClientes();
                    storeClientes.DataBind();
                    btnGuardar.Hidden = true;
                    btnCancelar.Hidden = true;
                    foreach (var item in cc.storeClientes())
                    {
                        txtNombres.Text = item.cli_nombres;
                        txtApellidos.Text = item.cli_apellidos;
                        txtRuc.Text = item.cli_cedula_ruc;
                        txtTelefono.Text = item.cli_telefono;
                        txtDireccion.Text = item.cli_direccion;
                        txtCorreo.Text = item.cli_correo;
                        hdnCliId.Text = item.cli_id.ToString();
                        if (item.cli_estado == "Activo")
                        {
                            chkEstadoCliente.Checked = true;
                        }
                        else
                        {
                            chkEstadoCliente.Checked = false;
                        }
                        break;
                    }
                }
            }
            catch
            {
                Response.Redirect("Login.aspx?men=1");
            }
        }

        protected void btnNuevoCliente_click(object sender, EventArgs e)
        {
            btnNuevoCliente.Hidden = true;
            btnEliminar.Hidden = true;
            btnGuardar.Hidden = false;
            btnCancelar.Hidden = false;
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtRuc.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtCorreo.Text = "";
            hdnCliId.Text = "";
            chkEstadoCliente.Checked = true;
        }

        protected void btnGuardar_click(object sender, EventArgs e)
        {
            claseClientes cc = new claseClientes();
            tbl_Clientes cliente = new tbl_Clientes();
            cliente.cli_usuario= Session["usuario"].ToString();
            cliente.cli_nombres = txtNombres.Text;
            cliente.cli_apellidos = txtApellidos.Text;
            cliente.cli_cedula_ruc = txtRuc.Text;
            cliente.cli_telefono = txtTelefono.Text;
            cliente.cli_direccion = txtDireccion.Text;
            cliente.cli_correo = txtCorreo.Text;
            if (chkEstadoCliente.Checked==true)
            {
                cliente.cli_estado = "Activo";
            }
            else
            {
                cliente.cli_estado = "Inactivo";
            }
            int cliId;
            try
            {
                cliId = int.Parse(hdnCliId.Text);
            }
            catch
            {
                cliId = 0;
            }
            String respuesta = cc.crearClientes(cliente, cliId);
            if (respuesta.Equals("OK"))
            {
                txtNombres.Text = "";
                txtApellidos.Text = "";
                txtRuc.Text = "";
                txtTelefono.Text = "";
                txtDireccion.Text = "";
                txtCorreo.Text = "";
                chkEstadoCliente.Checked = true;
                hdnCliId.Text = "";
                btnNuevoCliente.Hidden = false;
                btnEliminar.Hidden = false;
                btnGuardar.Hidden = true;
                btnCancelar.Hidden = true;
                storeClientes.DataSource = cc.storeClientes();
                storeClientes.DataBind();
                this.rmClientes.AddScript("Ext.Msg.notify('Guardado Correcto!!', 'Registro guardado correctamente');");
            }
            else
            {
                if (respuesta.Contains("Violation of UNIQUE KEY constraint") == true)
                {
                    X.MessageBox.Alert("Error al guardar!!", "El cliente ingresado ya existe").Show();
                }
                else
                {
                    X.MessageBox.Alert("Error al guardar!!", respuesta).Show();
                }
            }
        }

        protected void btnCancelar_click(object sender, EventArgs e)
        {
            claseClientes cc = new claseClientes();
            btnGuardar.Hidden = true;
            btnCancelar.Hidden = true;
            btnNuevoCliente.Hidden = false;
            btnEliminar.Hidden = false;
            foreach (var item in cc.storeClientes())
            {
                txtNombres.Text = item.cli_nombres;
                txtApellidos.Text = item.cli_apellidos;
                txtRuc.Text = item.cli_cedula_ruc;
                txtTelefono.Text = item.cli_telefono;
                txtDireccion.Text = item.cli_direccion;
                txtCorreo.Text = item.cli_correo;
                hdnCliId.Text = item.cli_id.ToString();
                if (item.cli_estado == "Activo")
                {
                    chkEstadoCliente.Checked = true;
                }
                else
                {
                    chkEstadoCliente.Checked = false;
                }
                break;
            }
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
            txtNombres.Text = cli.cli_nombres;
            txtApellidos.Text = cli.cli_apellidos;
            txtRuc.Text = cli.cli_cedula_ruc;
            txtTelefono.Text = cli.cli_telefono;
            txtDireccion.Text = cli.cli_direccion;
            txtCorreo.Text = cli.cli_correo;
            hdnCliId.Text = cli.cli_id.ToString();
            if (cli.cli_estado=="Activo")
            {
                chkEstadoCliente.Checked = true;
            }
            else
            {
                chkEstadoCliente.Checked = false;
            }
        }

        [DirectMethod]
        public void mostrarBotonGuardar()
        {
            btnNuevoCliente.Hidden = true;
            btnEliminar.Hidden = true;
            btnGuardar.Hidden = false;
            btnCancelar.Hidden = false;
        }

        protected void btnEliminar_click(object sender, EventArgs e)
        {
            String json = "";
            json = "[{cli_id:" + hdnCliId.Text + "}]";
            X.Msg.Confirm("Atención!!", "Esta seguro de eliminar el cliente " + txtNombres.Text +" "+txtApellidos.Text+ "?", new MessageBoxButtonsConfig
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
            String cli_id = "";
            claseClientes cc = new claseClientes();

            Dictionary<string, string>[] fcp = JSON.Deserialize<Dictionary<string, string>[]>(json);
            foreach (Dictionary<string, string> row in fcp)
            {
                cli_id = row["cli_id"];
            }
            tbl_Clientes clientes = cc.buscarClientesPorId(int.Parse(cli_id));
            String respuesta = cc.eliminarClientes(clientes);
            if (respuesta.Equals("OK"))
            {
                storeClientes.DataSource = cc.storeClientes();
                storeClientes.DataBind();
                txtNombres.Text = "";
                txtApellidos.Text = "";
                txtRuc.Text = "";
                txtTelefono.Text = "";
                txtDireccion.Text = "";
                txtCorreo.Text = "";
                hdnCliId.Text = "";
                chkEstadoCliente.Checked = true;
                this.rmClientes.AddScript("Ext.Msg.notify('Eliminación correcta!!', 'Registro eliminado correctamente');");
            }
            else
            {
                X.MessageBox.Alert("Error al eliminar proveedor!!", respuesta).Show();
            }
        }

        protected void txtBuscarPorCiRuc_change(object sender, EventArgs e)
        {
            claseClientes cc = new claseClientes();
            storeClientes.DataSource = cc.buscarClientesPorRucCiContains(txtBuscarPorCiRuc.Text);
            storeClientes.DataBind();
        }

        protected void txtBuscarPorNombresApellidos_change(object sender, EventArgs e)
        {
            claseClientes cc = new claseClientes();
            storeClientes.DataSource = cc.buscarClientesPorNombresApellidosContains(txtBuscarPorNombresApellidos.Text);
            storeClientes.DataBind();
        }
    }
}