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

                        // Affichage du prix plancher.

                        Panel divPrixPlancher = new Panel();
                        divPrixPlancher.CssClass = "col-xs-6";
                        divPrixPlancher.Style["padding"] = "0 5px 0 5px";

                        Panel divPrixPlancherContainer = new Panel();
                        divPrixPlancherContainer.CssClass = "panel panel-primary";

                        Panel divPrixPlancherHeader = new Panel();
                        divPrixPlancherHeader.CssClass = "panel-heading";

                        Label pPrixPlancher = new Label();
                        pPrixPlancher.Text = "Prix plancher";

                        divPrixPlancherHeader.Controls.Add(pPrixPlancher);

                        Panel divPrixPlancherBody = new Panel();
                        divPrixPlancherBody.CssClass = "panel-body";

                        Label pPrixValeur = new Label();
                        pPrixValeur.Text = item.PRIX_PLANCHER.ToString() + "$";

                        divPrixPlancherBody.Controls.Add(pPrixValeur);

                        divPrixPlancherContainer.Controls.Add(divPrixPlancherHeader);
                        divPrixPlancherContainer.Controls.Add(divPrixPlancherBody);

                        divPrixPlancher.Controls.Add(divPrixPlancherContainer);

                        divCaption.Controls.Add(divPrixPlancher);

                        // Affichage du prix de l'offre la plus haute.

                        Panel divPrixEnchere = new Panel();
                        divPrixEnchere.CssClass = "col-xs-6";
                        divPrixEnchere.Style["padding"] = "0 5px 0 5px";

                        Panel divPrixEnchereContainer = new Panel();
                        divPrixEnchereContainer.CssClass = "panel panel-success";

                        Panel divPrixEnchereHeader = new Panel();
                        divPrixEnchereHeader.CssClass = "panel-heading";

                        Label pPrixEnchere = new Label();
                        pPrixEnchere.Text = "Prix plancher";

                        divPrixEnchereHeader.Controls.Add(pPrixEnchere);

                        Panel divPrixEnchereBody = new Panel();
                        divPrixEnchereBody.CssClass = "panel-body";

                        Label pPrixEValeur = new Label();
                        pPrixEValeur.Text = (prixEnchere == 0 ? item.PRIX_PLANCHER : prixEnchere) + "$";

                        divPrixEnchereBody.Controls.Add(pPrixEValeur);

                        divPrixEnchereContainer.Controls.Add(divPrixEnchereHeader);
                        divPrixEnchereContainer.Controls.Add(divPrixEnchereBody);

                        divPrixEnchere.Controls.Add(divPrixEnchereContainer);

                        divCaption.Controls.Add(divPrixEnchere);

                        Label hTitre = new Label();
                        hTitre.Text = "<h3>" + item.TITRE + "</h3>";

                        divCaption.Controls.Add(hTitre);

                        Label pDescription = new Label();
                        pDescription.Text = "<p>" + item.DESCRIPTION + "</p>";

                        divCaption.Controls.Add(pDescription);

                        Button btnDescription = new Button();
                        btnDescription.CssClass = "btn btn-primary btn-down-10";
                        btnDescription.ID = "btnDescription" + item.ID_ITEM;
                        btnDescription.Click += btnDescription_Click;
                        btnDescription.Text = "Description";
                        btnDescription.Attributes["itemID"] = item.ID_ITEM.ToString();

                        divCaption.Controls.Add(btnDescription);

                        if (Convert.ToString(Session["userStatut"]) == "Admin")
                        {
                            Button btnRejeter = new Button();
                            btnRejeter.CssClass = "btn btn-danger btn-right btn-down-10";
                            btnRejeter.ID = "btnRejeter" + item.ID_ITEM;
                            btnRejeter.Click += btnRejeter_Click;
                            btnRejeter.Text = "Rejeter";

                            divCaption.Controls.Add(btnRejeter);
                        }
                        else if (Convert.ToString(Session["userStatut"]) == "Acheteur")
                        {
                            Panel divInputGroup = new Panel();
                            divInputGroup.CssClass = "input-group";

                            Label inputGrpButton = new Label();
                            inputGrpButton.CssClass = "input-group-btn";

                            Button btnEncherir = new Button();
                            btnEncherir.CssClass = "btn btn-success";
                            btnEncherir.ID = "btnEncherir" + item.ID_ITEM;
                            btnEncherir.Click += btnEncherir_Click;
                            btnEncherir.Text = "Enchérir!";

                            inputGrpButton.Controls.Add(btnEncherir);

                            divInputGroup.Controls.Add(inputGrpButton);

                            TextBox txtOffre = new TextBox();
                            txtOffre.CssClass = "form-control";
                            txtOffre.Attributes["placeholder"] = "Entrez votre offre...";
                            txtOffre.Attributes["type"] = "number";

                            divInputGroup.Controls.Add(txtOffre);

                            Label addon = new Label();
                            addon.CssClass = "input-group-addon";
                            addon.Text = "$";

                            divInputGroup.Controls.Add(addon);

                            divCaption.Controls.Add(divInputGroup);

                            //<div class=\"input-group\"><span class=\"input-group-btn\"><button class=\"btn btn-success\"
                            //type=\"button\">Enchérir!</button></span><input type=\"text\" class=\"form-control\" 
                            //placeholder=\"Mettre votre offre...\"><span class=\"input-group-addon\">$</span></div>";
                        }

                        divThumbnailContainer.Controls.Add(divCaption);

                        divThumbnail.Controls.Add(divThumbnailContainer);

                        affichageItem.Controls.Add(divThumbnail);


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

        void btnEncherir_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void btnRejeter_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnDescription_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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