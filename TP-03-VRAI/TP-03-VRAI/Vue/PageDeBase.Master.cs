using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_03_VRAI.Vue
{
    public partial class PageDeBase : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Si le membre n'est pas conecté:
            if (Session["membre"] == null)
            {
                this.menuSiNonConn.InnerHtml = "<form class=\"navbar-form navbar-right\"><div class=\"form-group\"><input type=\"text\" placeholder=\"Email\" class=\"form-control\"></div><div class=\"form-group\"><input type=\"password\" placeholder=\"Password\" class=\"form-control\"></div><button type=\"submit\" class=\"btn btn-success\">Sign in</button></form>";
            }
            else
            {
                this.menuSiNonConn.InnerHtml = "";
            }
        }
    }
}