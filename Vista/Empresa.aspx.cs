using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Controlador;
using Modelo;

namespace Vista
{
    public partial class Empresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                claseEmpresa ce = new claseEmpresa();
                btnGuardar.Hidden = true;
                btnCancelar.Hidden = true;
                storeEmpresas.DataSource = ce.storeEmpresas();
                storeEmpresas.DataBind();
                foreach (var item in ce.storeEmpresas())
                {
                    txtRuc.Text = item.emp_ruc;
                    txtRazonSocial.Text = item.emp_razon_social;
                    txtNombreComercial.Text = item.emp_nombre_comercial;
                    txtContribuyenteEspecial.Text = item.emp_contribuyente_especial;
                    txtNumeroEstablecimiento.Text = item.emp_numero_establecimiento;
                    hdnEmpId.Text = item.emp_id.ToString();
                    if (item.emp_obligada_contabilidad == true)
                    {
                        chkObligadoContabilidad.Checked = true;
                    }
                    else
                    {
                        chkObligadoContabilidad.Checked = false;
                    }
                    break;
                }
            }
        }
        [DirectMethod]
        public void mostrarBotonGuardar()
        {
            btnNuevaEmpresa.Hidden = true;
            btnEliminar.Hidden = true;
            btnGuardar.Hidden = false;
            btnCancelar.Hidden = false;
        }

        protected void btnGuardar_click(object sender, EventArgs e)
        {
            tbl_Empresa empresa = new tbl_Empresa();
            claseEmpresa ce = new claseEmpresa();
            empresa.emp_ruc = txtRuc.Text;
            empresa.emp_razon_social = txtRazonSocial.Text;
            empresa.emp_nombre_comercial = txtNombreComercial.Text;
            empresa.emp_contribuyente_especial = txtContribuyenteEspecial.Text;
            empresa.emp_numero_establecimiento = txtNumeroEstablecimiento.Text;
            if (chkObligadoContabilidad.Checked==true)
            {
                empresa.emp_obligada_contabilidad = true;
            }
            if (chkObligadoContabilidad.Checked==false)
            {
                empresa.emp_obligada_contabilidad = false;
            }
            int emp_id;
            try
            {
                emp_id =int.Parse(hdnEmpId.Text);
            }
            catch
            {
                emp_id = 0;
            }
            string res = ce.crearEmpresas(empresa, emp_id);
            if (res=="OK")
            {
                storeEmpresas.DataSource = ce.storeEmpresas();
                storeEmpresas.DataBind();
                hdnEmpId.Text = "";
                txtRuc.Text = "";
                txtRazonSocial.Text = "";
                txtNombreComercial.Text = "";
                txtContribuyenteEspecial.Text = "";
                txtNumeroEstablecimiento.Text = "";
                chkObligadoContabilidad.Checked = false;
                btnNuevaEmpresa.Hidden = false;
                btnEliminar.Hidden = false;
                btnGuardar.Hidden = true;
                btnCancelar.Hidden = true;
                this.rmClientes.AddScript("Ext.Msg.notify('Guardado Correcto!!', 'Registro guardado correctamente');");
            }
            else
            {
                if (res.Contains("Violation of UNIQUE KEY constraint") == true)
                {
                    X.MessageBox.Alert("Error al guardar!!", "No es posible ingresar una empresa con Ruc o Número de establecimento que ya existan.").Show();
                }
                else
                {
                    X.MessageBox.Alert("Error al guardar!!", res).Show();
                }
            }
        }

        protected void btnEliminar_click(object sender, EventArgs e)
        {
            String json = "";
            json = "[{emp_id:" + hdnEmpId.Text + "}]";
            X.Msg.Confirm("Atención!!", "Esta seguro de eliminar la empresa " + txtNombreComercial.Text +"?", new MessageBoxButtonsConfig
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
            String emp_id = "";
            claseEmpresa ce = new claseEmpresa();

            Dictionary<string, string>[] fcp = JSON.Deserialize<Dictionary<string, string>[]>(json);
            foreach (Dictionary<string, string> row in fcp)
            {
                emp_id = row["emp_id"];
            }
            tbl_Empresa empresa = ce.buscarEmpresaPorId(int.Parse(emp_id));
            String respuesta = ce.eliminarEmpresa(empresa);
            if (respuesta.Equals("OK"))
            {
                storeEmpresas.DataSource = ce.storeEmpresas();
                storeEmpresas.DataBind();
                txtRuc.Text = "";
                txtRazonSocial.Text = "";
                txtNombreComercial.Text = "";
                txtContribuyenteEspecial.Text = "";
                txtNumeroEstablecimiento.Text = "";
                hdnEmpId.Text = "";
                chkObligadoContabilidad.Checked = false;
                this.rmClientes.AddScript("Ext.Msg.notify('Eliminación correcta!!', 'Registro eliminado correctamente');");
            }
            else
            {
                X.MessageBox.Alert("Error al eliminar empresa!!", respuesta).Show();
            }
        }

        protected void btnCancelar_click(object sender, EventArgs e)
        {
            btnNuevaEmpresa.Hidden = false;
            btnEliminar.Hidden = false;
            btnGuardar.Hidden = true;
            btnCancelar.Hidden = true;
            claseEmpresa ce = new claseEmpresa();
            foreach (var item in ce.storeEmpresas())
            {
                txtRuc.Text = item.emp_ruc;
                txtRazonSocial.Text = item.emp_razon_social;
                txtNombreComercial.Text = item.emp_nombre_comercial;
                txtContribuyenteEspecial.Text = item.emp_contribuyente_especial;
                txtNumeroEstablecimiento.Text = item.emp_numero_establecimiento;
                hdnEmpId.Text = item.emp_id.ToString();
                if (item.emp_obligada_contabilidad == true)
                {
                    chkObligadoContabilidad.Checked = true;
                }
                else
                {
                    chkObligadoContabilidad.Checked = false;
                }
                break;
            }
        }

        protected void btnNuevaEmpresa_click(object sender, EventArgs e)
        {
            btnNuevaEmpresa.Hidden = true;
            btnEliminar.Hidden = true;
            btnGuardar.Hidden = false;
            btnCancelar.Hidden = false;
            hdnEmpId.Text = "";
            txtRuc.Text = "";
            txtRazonSocial.Text = "";
            txtNombreComercial.Text = "";
            txtContribuyenteEspecial.Text = "";
            txtNumeroEstablecimiento.Text = "";
            chkObligadoContabilidad.Checked = false;
        }

        protected void gdEmpresa_click(object sender, DirectEventArgs e)
        {
            string json = e.ExtraParams["Values"];
            Dictionary<string, string>[] v1 = JSON.Deserialize<Dictionary<string, string>[]>(json);
            claseEmpresa ce = new claseEmpresa();
            tbl_Empresa emp = new tbl_Empresa();
            foreach (Dictionary<string, string> row in v1)
            {
                emp = ce.buscarEmpresaPorRuc(row["emp_ruc"]);
            }
            hdnEmpId.Text = emp.emp_id.ToString();
            txtRuc.Text = emp.emp_ruc;
            txtRazonSocial.Text = emp.emp_razon_social;
            txtNombreComercial.Text = emp.emp_nombre_comercial;
            txtContribuyenteEspecial.Text = emp.emp_contribuyente_especial;
            txtNumeroEstablecimiento.Text = emp.emp_numero_establecimiento;
            if (emp.emp_obligada_contabilidad==true)
            {
                chkObligadoContabilidad.Checked = true;
            }
            if (emp.emp_obligada_contabilidad == false)
            {
                chkObligadoContabilidad.Checked = false;
            }
        }

        protected void txtBuscarPorRuc_change(object sender, EventArgs e)
        {
            claseEmpresa ce = new claseEmpresa();
            storeEmpresas.DataSource = ce.buscarEmpresaPorRucContains(txtBuscarPorRuc.Text);
            storeEmpresas.DataBind();
        }

        protected void txtBuscarPorRazonSocial_change(object sender, EventArgs e)
        {
            claseEmpresa ce = new claseEmpresa();
            storeEmpresas.DataSource = ce.buscarEmpresaPorRazonSocialContains(txtBuscarPorRazonSocial.Text);
            storeEmpresas.DataBind();
        }

        protected void txtBuscarPorNombreComercial_change(object sender, EventArgs e)
        {
            claseEmpresa ce = new claseEmpresa();
            storeEmpresas.DataSource = ce.buscarEmpresaPorNombreComercialContains(txtBuscarPorNombreComercial.Text);
            storeEmpresas.DataBind();
        }
    }
}