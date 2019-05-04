using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controlador;
using Ext.Net;

namespace Vista
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                if (Request.Params["men"] != null)
                {
                    String men = Request.Params["men"];
                    if (men == "1")
                    {
                        X.Msg.Alert("Advertencia!!", "Debe iniciar sesión para ingresar al sistema").Show();
                    }
                }
            }
            
        }

        [DirectMethod]
        public void focusBusqueda(int key)
        {
            if (key == 13)
            {
                ingresar();
            }
           
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            ingresar();
        }

        public void ingresar()
        {
            claseLogin cl = new claseLogin();
            String respuesta = cl.verificarUsuario(txtUsuario.Text, txtPassword.Text);
            if (respuesta == "OK")
            {
                Session["usuario"] = txtUsuario.Text;
                Response.Redirect("Default.aspx");
            }
            else
            {
                X.Msg.Alert("Error al iniciar sesión!!", respuesta).Show();
            }
        }
    }
}