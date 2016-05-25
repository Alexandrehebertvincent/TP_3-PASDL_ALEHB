using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_03_VRAI.Vue.Pages
{
    public partial class Inscription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
            else
            {
                MEMBRES nouveau = new MEMBRES();
                nouveau.CONTACT = txtEmail.Text;
                nouveau.NOM_MEMBRE = txtNom.Text;
                nouveau.MOT_DE_PASSE = txtMdp.Text;
                nouveau.STATUT = cmbType.Value;
                try
                {
                    BD_Entities bd = new BD_Entities();
                    bd.MEMBRES.Add(nouveau);
                    bd.SaveChanges();

                    MEMBRES membreWithId = (from membre in bd.MEMBRES
                                            orderby membre.ID_MEMBRE descending
                                            select membre).FirstOrDefault();

                    Session["user"] = membreWithId.NOM_MEMBRE.Trim();
                    Session["userID"] = membreWithId.ID_MEMBRE;
                    Session["userStatut"] = membreWithId.STATUT.Trim();

                    Response.Redirect("Articles.aspx");
                }
                catch (Exception exc) { }
            }
        }
    }
}