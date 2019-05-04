using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String nombre = Session["usuario"].ToString();
            }
            catch
            {
                Response.Redirect("Login.aspx?men=1");
            }
        }

        protected void treeNodo_click(object sender, DirectEventArgs e)
        {
            string node = e.ExtraParams["id"] ?? "";
            string[] nod = node.Split('-');
            int cont = nod.Count();
            string subMenu = nod[cont - 1].ToString();
            switch (subMenu)
            {

                case "nodeIngrProductos":
                    this.Center.Loader.Url = "IngresoProductos.aspx";
                    break;
                case "nodeIngrCategorias":
                    this.Center.Loader.Url = "IngresoCategorias.aspx";
                    break;
                case "nodeIngrProveedores":
                    this.Center.Loader.Url = "IngresoProveedores.aspx";
                    break;
                case "nodeIngrClientes":
                    this.Center.Loader.Url = "IngresoClientes.aspx";
                    break;
                case "nodeIngrEmpresa":
                    this.Center.Loader.Url = "Empresa.aspx";
                    break;
                case "nodeFacturacion":
                    this.Center.Loader.Url = "Facturacion.aspx";
                    break;
                case "nodeRegistroPuntoEmision":
                    this.Center.Loader.Url = "RegistroPuntoEmision.aspx";
                    break;
                case "nodeIngrEmpl":
                    this.Center.Loader.Url = "ingresoCasosEspeciales.aspx";
                    break;
                case "nodeQuitarRegHuella":
                    this.Center.Loader.Url = "ingresoCasosEspeciales.aspx";
                    break;
                case "nodeAdministrarHorarios":
                    this.Center.Loader.Url = "gestionHorarios.aspx";
                    break;
                case "nodeAsigTurAlmEmpl":
                    this.Center.Loader.Url = "asignacionTurnosAlmuerzosEmpleados.aspx";
                    break;
                case "nodeParametros":
                    this.Center.Loader.Url = "parametros.aspx";
                    break;
                case "nodeProveedores":
                    this.Center.Loader.Url = "ingresoProveedores.aspx";
                    break;
                case "nodeIngLugCons":
                    this.Center.Loader.Url = "ingresoLugarConsumo.aspx";
                    break;
                case "nodeIngDescCargo":
                    this.Center.Loader.Url = "ingresoValorDescuentoCargo.aspx";
                    break;
                case "nodeRepTotPer":
                    this.Center.Loader.Url = "reporteTotalesPorPersona.aspx";
                    break;
                case "nodeRepComDet":
                    this.Center.Loader.Url = "reporteComidasDetallado.aspx";
                    break;
                case "nodeRepTotDia":
                    this.Center.Loader.Url = "reporteTotalDiario.aspx";
                    break;
                case "nodeRepCentCos":
                    this.Center.Loader.Url = "reportePorCentroDeCosto.aspx";
                    break;
                case "nodeFechasCorteProv":
                    this.Center.Loader.Url = "fechasCorteProveedores.aspx";
                    break;
                case "nodeCerrarSesion":
                    desaparecerArbol();
                    Session.RemoveAll();
                    Response.Redirect("Login.aspx");
                    break;
            }
            this.Center.Loader.Mode = LoadMode.Frame;
            this.Center.Loader.DisableCaching = true;
            this.Center.LoadContent();
            Center.Loader.LoadMask.ShowMask = true;

        }

        public void desaparecerArbol()
        {
            try
            {
                contenedor.Hidden = true;
            }
            catch
            {
                contenedor.Hidden = true;
            }

        }


    }
}