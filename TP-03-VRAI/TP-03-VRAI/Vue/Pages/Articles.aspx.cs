using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_03_VRAI.Vue.Pages
{
    public partial class Articles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AfficherItems();
        }

        private void AfficherItems()
        {
            // Nettoyer la page des items actuels.
            affichageItem.InnerHtml = "";
            // Pour chaque item de la BD, afficher dans un div html.
            
            using (BD_Entities monEntity = new BD_Entities())
            {
                try
                {

                    var tousLesItems = from item in monEntity.ITEM
                                        orderby item.DATE_INSCRIPTION descending
                                        select item;

                    foreach (var item in tousLesItems){
                        double prixEnchere = ObtenirMeilleurOffreSurProduit(item.ID_ITEM);

                        Panel divThumbnail = new Panel();
                        divThumbnail.CssClass = "col-xs-12 col-sm-3";

                        Panel divThumbnailContainer = new Panel();
                        divThumbnailContainer.CssClass = "thumbnail";

                        Label pNombreEnchere = new Label();
                        pNombreEnchere.Text = "<p>Nombre d'offre <span class=\"label label-primary\">" + ObtenirCompteOffreSurProduit(item.ID_ITEM) + "</span></p>";

                        divThumbnailContainer.Controls.Add(pNombreEnchere);

                        Image imgItem = new Image();
                        imgItem.ImageUrl = "../../img/" + item.PHOTO_URL.ToString().Trim();
                        imgItem.AlternateText = item.TITRE;

                        divThumbnailContainer.Controls.Add(imgItem);

                        Panel divCaption = new Panel();
                        divCaption.CssClass = "caption";

                        Panel divPrixPlancher = new Panel();
                        divPrixPlancher.CssClass = "col-xs-6";
                        divPrixPlancher.Style["padding"] = "0 5px 0 5px";

                        Panel divPrixPlancherContainer = new Panel();
                        divPrixPlancherContainer.CssClass = "panel panel-primary";

                        Panel divPrixPlancherHeader = new Panel();
                        divPrixPlancherHeader.CssClass = "panel-heading";


                        //<div class=\"col-xs-6\" style=\"padding:0 5px 0 5px;\"><div class=\"panel panel-primary\"><div class=\"panel-heading\">Prix plancher</div><div class=\"panel-body\">" + prix + "$</div></div></div>";
                        divThumbnail.Controls.Add(divThumbnailContainer);

                        affichageItem.Controls.Add(divThumbnail);

                        //affichageItem.InnerHtml += ObtenirPrixPlancherHTML(item.PRIX_PLANCHER);
                        //affichageItem.InnerHtml += ObtenirPrixMiseHauteHTML((prixEnchere == 0 ? item.PRIX_PLANCHER : prixEnchere));
                        //affichageItem.InnerHtml += ObtenirTitreItemHTML(item.TITRE);
                        //affichageItem.InnerHtml += ObtenirDescriptionHTML(item.DESCRIPTION);
                        //affichageItem.InnerHtml += "<p>";
                        //affichageItem.InnerHtml += ObtenirBoutonAfficherDescriptionHTML();
                        //if (Convert.ToString(Session["userStatut"]) == "Admin")
                        //{
                        //    affichageItem.InnerHtml += ObtenirBoutonRejeterHTML();
                        //}
                        //else if (Convert.ToString(Session["userStatut"]) == "Acheteur")
                        //{
                        //    affichageItem.InnerHtml += ObtenirControleEncherirHTML();
                        //}
                        //affichageItem.InnerHtml += "</p>";
                        //affichageItem.InnerHtml += "</div></div></div>";
                    }

                }
                catch (EntityDataSourceValidationException exc)
                {
                    //messageErreur.Text = exc.Message;
                }
            }
        }

        private double ObtenirMeilleurOffreSurProduit(int idProduit)
        {
            using (BD_Entities monEntity = new BD_Entities())
            {
                try
                {

                    var meilleurPrix = (from offre in monEntity.OFFRE
                                        where offre.ID_ITEM == idProduit
                                        orderby offre.PRIX_OFFRE descending
                                        select offre.PRIX_OFFRE).FirstOrDefault();
                    return meilleurPrix;
                }
                catch (Exception e)
                {
                    return 0;
                }
            }
        }

        private double ObtenirCompteOffreSurProduit(int idProduit)
        {
            using (BD_Entities monEntity = new BD_Entities())
            {
                try
                {

                    var meilleurPrix = from offre in monEntity.OFFRE
                                        where offre.ID_ITEM == idProduit
                                        select offre.PRIX_OFFRE;
                    return meilleurPrix.Count();
                }
                catch (Exception e)
                {
                    return 0;
                }
            }
        }

        private string ObtenirNombreEnchere(int idItem)
        {
            return "<p>Nombre d'offre <span class=\"label label-primary\">" + ObtenirCompteOffreSurProduit(idItem) + "</span></p>";
        }

        private string ObtenirPrixPlancherHTML(double? prix)
        {
            return "<div class=\"col-xs-6\" style=\"padding:0 5px 0 5px;\"><div class=\"panel panel-primary\"><div class=\"panel-heading\">Prix plancher</div><div class=\"panel-body\">" + prix + "$</div></div></div>";
        }

        private string ObtenirPrixMiseHauteHTML(double? prix)
        {
            return "<div class=\"col-xs-6\" style=\"padding:0 5px 0 5px;\"><div class=\"panel panel-success\"><div class=\"panel-heading\">Enchère</div><div class=\"panel-body\">" + prix + "$</div></div></div>";
        }

        private string ObtenirControleEncherirHTML()
        {
            return "<div class=\"input-group\"><span class=\"input-group-btn\"><button class=\"btn btn-success\" type=\"button\">Enchérir!</button></span><input type=\"text\" class=\"form-control\" placeholder=\"Mettre votre offre...\"><span class=\"input-group-addon\">$</span></div>";
        }

        private string ObtenirBoutonRejeterHTML()
        {
            return "<a href=\"#\" class=\"btn btn-danger\" role=\"button\">Rejeter</a>";
        }

        private string ObtenirBoutonAfficherDescriptionHTML()
        {
            return "<a href=\"#\" class=\"btn btn-primary\" role=\"button\" id=\"btnDescription\" runat=\"server\">Description</a>";
        }

        private void myButton_Click(object sender, EventArgs e)
        {
            affichageItem.InnerHtml = "";
        }

        private string ObtenirDescriptionHTML(string description)
        {
            return "<p>" + description + "</p>";
        }

        private string ObtenirImageThumbnailHTML(string photoUrl, string alt)
        {
            return "<img src=\"../../img/" + photoUrl + "\" alt=\"" + alt + "\">";
        }

        private string ObtenirTitreItemHTML(string titre)
        {
            return "<h3>" + titre + "</h3>";
        }
    }
}