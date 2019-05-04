using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Controlador;
using System.Net;
using Modelo;

namespace Vista
{
    public partial class RegistroPuntoEmision : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                btnGuardar.Hidden = true;
                btnCancelar.Hidden = true;
                clasePuntoEmision cpe = new clasePuntoEmision();
                storeEstablecimiento.DataSource = cpe.storeEstablecimiento();
                storeEstablecimiento.DataBind();
               
                tbl_Punto_Emision pem = cpe.buscarPuntoEmisionPorIP(cpe.getIP());
                if (pem!=null)
                {
                    cbxEstablecimiento.SetValue(pem.pem_emp_id);
                    txtDireccionIP.Text = cpe.getIP();
                    txtPuntoEmision.Text = pem.pem_punto_emision;
                    hdnPemId.Text = pem.pem_id.ToString();
                }
                else
                {
                    txtDireccionIP.Text = cpe.getIP();
                }
                storePuntoEmision.DataSource = cpe.storeVtaPuntoEmision();
                storePuntoEmision.DataBind();
            }
        }

        [DirectMethod]
        public void mostrarBotonGuardar()
        {
            btnCancelar.Hidden = false;
            btnGuardar.Hidden = false;
            btnNuevoPuntoEmision.Hidden = true;
            btnEliminar.Hidden = true;
        }

        protected void btnGuardar_click(object sender, EventArgs e)
        {
            clasePuntoEmision cpe = new clasePuntoEmision();
            tbl_Punto_Emision pemExistente = cpe.buscarPuntoEmisionPorEstablecimientoPuntoEmision(int.Parse(cbxEstablecimiento.SelectedItem.Value), txtPuntoEmision.Text);
            if (pemExistente == null)
            {
                tbl_Punto_Emision pem = new tbl_Punto_Emision();
                pem.pem_emp_id = int.Parse(cbxEstablecimiento.SelectedItem.Value);
                pem.pem_direccion_ip = txtDireccionIP.Text;
                pem.pem_punto_emision = txtPuntoEmision.Text;
                int pem_id;
                try
                {
                    pem_id = int.Parse(hdnPemId.Text);
                }
                catch
                {
                    pem_id = 0;
                }
                string respuesta = cpe.crearPuntoEmision(pem, pem_id);
                if (respuesta == "OK")
                {
                    storePuntoEmision.DataSource = cpe.storeVtaPuntoEmision();
                    storePuntoEmision.DataBind();
                    btnGuardar.Hidden = true;
                    btnCancelar.Hidden = true;
                    btnNuevoPuntoEmision.Hidden = false;
                    btnEliminar.Hidden = false;
                    txtDireccionIP.Text = "";
                    cbxEstablecimiento.Reset();
                    txtPuntoEmision.Text ="";
                    this.rmPuntoEmision.AddScript("Ext.Msg.notify('Guardado Correcto!!', 'Registro guardado correctamente');");
                }
                else
                {
                    if (respuesta.Contains("Violation of UNIQUE KEY constraint") == true)
                    {
                        X.MessageBox.Alert("Error al guardar!!", "El terminal " + txtDireccionIP.Text + " ya tiene asignado un punto de emisión.").Show();
                    }
                    else
                    {
                        X.MessageBox.Alert("Error al guardar!!", respuesta).Show();
                    }
                }
            }
            else
            {
                X.MessageBox.Alert("Error al guardar!!", "Ya existe el punto de emisión "+txtPuntoEmision.Text+ " para el establecimiento "+cbxEstablecimiento.SelectedItem.Text+".").Show();
            }      
        }

        protected void btnCancelar_click(object sender, EventArgs e)
        {
            btnCancelar.Hidden = true;
            btnGuardar.Hidden = true;
            btnNuevoPuntoEmision.Hidden = false;
            btnEliminar.Hidden = false;
            txtDireccionIP.ReadOnly = true;
            clasePuntoEmision cpe = new clasePuntoEmision();
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }
            tbl_Punto_Emision pem = cpe.buscarPuntoEmisionPorIP(localIP);
            if (pem != null)
            {
                cbxEstablecimiento.SetValue(pem.pem_emp_id);
                txtDireccionIP.Text = localIP;
                txtPuntoEmision.Text = pem.pem_punto_emision;
            }
            else
            {
                txtDireccionIP.Text = localIP;
            }
        }

        protected void btnNuevoPuntoEmision_click(object sender, EventArgs e)
        {
            btnNuevoPuntoEmision.Hidden = true;
            btnEliminar.Hidden = true;
            btnGuardar.Hidden = false;
            btnCancelar.Hidden = false;
            cbxEstablecimiento.Reset();
            txtDireccionIP.Text = "";
            txtDireccionIP.ReadOnly = false;
            txtPuntoEmision.Text = "";
        }

        protected void gdPuntoEmision_click(object sender, DirectEventArgs e)
        {

            string json = e.ExtraParams["Values"];
            Dictionary<string, string>[] v1 = JSON.Deserialize<Dictionary<string, string>[]>(json);
            clasePuntoEmision cpe = new clasePuntoEmision();
            tbl_Punto_Emision pem = new tbl_Punto_Emision();
            foreach (Dictionary<string, string> row in v1)
            {
                pem = cpe.buscarPuntoEmisionPorIP(row["pem_direccion_ip"]);
            }
            cbxEstablecimiento.SetValue(pem.pem_emp_id);
            txtDireccionIP.ReadOnly = true;
            txtDireccionIP.Text = pem.pem_direccion_ip;
            txtPuntoEmision.Text = pem.pem_punto_emision;
            hdnPemId.Text = pem.pem_id.ToString();
        }

        protected void txtBuscarPorEstablecimiento_change(object sender, EventArgs e)
        {
            clasePuntoEmision cpe = new clasePuntoEmision();
            storePuntoEmision.DataSource = cpe.buscarPuntoEmisionPorEstablecimientoContains(txtBuscarPorEstablecimiento.Text);
            storePuntoEmision.DataBind();
        }

        protected void txtBuscarPorDireccionIp_change(object sender, EventArgs e)
        {
            clasePuntoEmision cpe = new clasePuntoEmision();
            storePuntoEmision.DataSource = cpe.buscarPuntoEmisionPorDireccionIpContains(txtBuscarPorDireccionIp.Text);
            storePuntoEmision.DataBind();
        }

        protected void txtBuscarPorPuntoEmision_change(object sender, EventArgs e)
        {
            clasePuntoEmision cpe = new clasePuntoEmision();
            storePuntoEmision.DataSource = cpe.buscarPuntoEmisionPorPuntoEmisionContains(txtBuscarPorPuntoEmision.Text);
            storePuntoEmision.DataBind();
        }

        protected void btnEliminar_click(object sender, EventArgs e)
        {
            String json = "";
            json = "[{pem_id:" + hdnPemId.Text + "}]";
            X.Msg.Confirm("Atención!!", "Esta seguro de eliminar el punto de emisión asignado a la dirección IP " + txtDireccionIP.Text + "?", new MessageBoxButtonsConfig
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
            String pem_id = "";
            clasePuntoEmision cpe = new clasePuntoEmision();

            Dictionary<string, string>[] fcp = JSON.Deserialize<Dictionary<string, string>[]>(json);
            foreach (Dictionary<string, string> row in fcp)
            {
                pem_id = row["pem_id"];
            }
            tbl_Punto_Emision  puntoEmision = cpe.buscarPuntoEmisionPorId(int.Parse(pem_id));
            String respuesta = cpe.eliminarPuntoEmision(puntoEmision);
            if (respuesta.Equals("OK"))
            {
                storePuntoEmision.DataSource = cpe.storeVtaPuntoEmision();
                storePuntoEmision.DataBind();
                txtDireccionIP.Text = "";
                txtDireccionIP.ReadOnly = false;
                txtPuntoEmision.Text = "";
                hdnPemId.Text = "";
                cbxEstablecimiento.Reset();
                this.rmPuntoEmision.AddScript("Ext.Msg.notify('Eliminación correcta!!', 'Registro eliminado correctamente');");
            }
            else
            {
                X.MessageBox.Alert("Error al eliminar proveedor!!", respuesta).Show();
            }
        }
    }
}