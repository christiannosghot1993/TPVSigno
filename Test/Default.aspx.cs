using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Modelo;

namespace Test
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TpvSignoEntities tse = new TpvSignoEntities();
            this.Store1.DataSource = dc.Cocktails.ToList();
            this.Store1.DataBind();

        }
    }
}