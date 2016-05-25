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

        #region "ÉVÈNEMENTS"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                switch (Session["userStatut"].ToString())
                {
                    case "Admin":
                        break;
                    case "Acheteur":
                        nbDansPanierA.InnerText = ObtenirNbDansPanierMembreSelonID(Convert.ToInt16(Session["userID"])).ToString();
                        break;
                    case "Vendeur":
                        nbDansPanierV.InnerText = ObtenirNbDansPanierMembreSelonID(Convert.ToInt16(Session["userID"])).ToString();
                        spanNbVentesEnCours.InnerText = ObtenirNbItemEnVenteSelonMembreID(Session["user"].ToString()).ToString();
                        break;
                    default:
                        break;
                }
            }
        }

        protected void btnInscription_Click(object sender, EventArgs e)
        {
            // Vérifier l'identité du membre.
            using (BD_Entities monEntity = new BD_Entities())
            {
                try
                {
                    MEMBRES membreConnecte = (from membre in monEntity.MEMBRES
                                              where membre.NOM_MEMBRE.Equals(this.txtUser.Text.Trim(), StringComparison.CurrentCultureIgnoreCase) && membre.MOT_DE_PASSE.Equals(this.txtPass.Text, StringComparison.CurrentCulture)
                                              select membre).FirstOrDefault();
                    if (membreConnecte != null)
                    {
                        this.divConnErreur.InnerHtml = "<div class=\"alert alert-success\" role=\"alert\">Vous êtes connecté avec succès!</div>";
                        
                        Session["user"] = membreConnecte.NOM_MEMBRE.Trim();
                        Session["userStatut"] = membreConnecte.STATUT.Trim();
                        Session["userID"] = membreConnecte.ID_MEMBRE;

                        Response.Redirect(Request.RawUrl);
                    }
                    else
                        this.divConnErreur.InnerHtml = "<div class=\"alert alert-danger\" role=\"alert\">Connexion impossible. Veuillez réessayer.</div>";
                }
                catch (Exception exc) { }
            }
        }

        protected void btnDeconnexion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Articles.aspx");
        }

        #endregion

        #region "MÉTHODES"

        private int ObtenirNbDansPanierMembreSelonID(int ID)
        {
            using (BD_Entities monEntity = new BD_Entities())
            {
                try
                {
                    var offreRecherchee = (from offre in monEntity.OFFRE
                                             where offre.ID_MEMBRE == ID
                                             select offre.ID_ITEM).Distinct();
                    return offreRecherchee.Count();
                }
                catch (Exception exc) { return 0; }
            }
        }

        private int ObtenirNbItemEnVenteSelonMembreID(string NomVendeur)
        {
            using (BD_Entities monEntity = new BD_Entities())
            {
                try
                {
                    var itemRecherche = from item in monEntity.ITEM
                                        where item.VENDEUR == NomVendeur
                                        select item;
                    return itemRecherche.Count();
                }
                catch (Exception exc) { return 0; }
            }
        }

        #endregion
    }
}