using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_03_VRAI.Vue.Pages
{
    public partial class FormulaireVendreItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
            else
            {
                ITEM nouveau = new ITEM();
                nouveau.CATEGORIE = txtCat.Text;
                nouveau.DATE_INSCRIPTION = DateTime.Now;
                nouveau.DESCRIPTION = txtDescription.Value.ToString();
                nouveau.TITRE = txtTitre.Text;
                nouveau.VENDEUR = Session["user"].ToString().Trim();
                nouveau.STATUT = "EnVente";
                nouveau.PRIX_PLANCHER = Convert.ToDouble(txtPrix.Text);
                fileImage.PostedFile.SaveAs(Server.MapPath("~") + "img/" + fileImage.FileName);
                nouveau.PHOTO_URL = fileImage.FileName;
                try
                {
                    BD_Entities bd = new BD_Entities();
                    bd.ITEM.Add(nouveau);
                    bd.SaveChanges();

                    Response.Redirect("Articles.aspx");
                }
                catch (Exception exc) { }
            }
        }
    }
}