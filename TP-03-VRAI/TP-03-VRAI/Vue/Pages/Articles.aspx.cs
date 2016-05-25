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
                        double prixEnchere = ObtenirMeilleurOffreSurProduit(item).PRIX_OFFRE;

                        Panel divThumbnail = new Panel();
                        divThumbnail.CssClass = "col-xs-12 col-sm-3";

                        Panel divThumbnailContainer = new Panel();
                        divThumbnailContainer.CssClass = "thumbnail";

                        Label pNombreEnchere = new Label();
                        pNombreEnchere.Text = "<p>Nombre d'offre <span class=\"label label-primary\">" + item.OFFRE.Count() + "</span></p>";

                        if (Convert.ToString(Session["userStatut"]) == "Acheteur" || Convert.ToString(Session["userStatut"]) == "Vendeur")
                        {
                            if (ObtenirMeilleurOffreSurProduit(item).ID_MEMBRE == Convert.ToInt16(Session["userID"]))
                            {
                                pNombreEnchere.Text = "<p>Nombre d'offre <span class=\"label label-primary\">" + item.OFFRE.Count() + "</span><span class=\"label label-success label-right\">En tête</span></p>";
                            }
                            else
                            {
                                pNombreEnchere.Text = "<p>Nombre d'offre <span class=\"label label-primary\">" + item.OFFRE.Count() + "</span><span class=\"label label-danger label-right\">Dépassé</span></p>";
                            }
                        }

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
                        pPrixEnchere.Text = "Offre actuelle";

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
                        btnDescription.Attributes["itemid"] = item.ID_ITEM.ToString();

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
                        else if (Convert.ToString(Session["userStatut"]) == "Acheteur" || Convert.ToString(Session["userStatut"]) == "Vendeur")
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
                            btnEncherir.Attributes["itemid"] = item.ID_ITEM.ToString();

                            inputGrpButton.Controls.Add(btnEncherir);

                            divInputGroup.Controls.Add(inputGrpButton);

                            TextBox txtOffre = new TextBox();
                            txtOffre.ID = "txtOffre" + item.ID_ITEM.ToString();
                            txtOffre.Attributes["name"] = "txtOffre" + item.ID_ITEM.ToString();
                            txtOffre.CssClass = "form-control";
                            txtOffre.Attributes["placeholder"] = "Entrez votre offre...";
                            txtOffre.Attributes["type"] = "number";
                            txtOffre.Attributes["itemid"] = item.ID_ITEM.ToString();
                            txtOffre.Attributes["minbid"] = (prixEnchere == 0 ? item.PRIX_PLANCHER : prixEnchere).ToString();
                            txtOffre.Text = (prixEnchere == 0 ? item.PRIX_PLANCHER + 1 : prixEnchere + 1).ToString();

                            divInputGroup.Controls.Add(txtOffre);

                            Label addon = new Label();
                            addon.CssClass = "input-group-addon";
                            addon.Text = "$";

                            divInputGroup.Controls.Add(addon);

                            divCaption.Controls.Add(divInputGroup);
                        }

                        divThumbnailContainer.Controls.Add(divCaption);

                        divThumbnail.Controls.Add(divThumbnailContainer);

                        affichageItem.Controls.Add(divThumbnail);
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
            Button btnEncherir = (Button)sender;
            string itemID = btnEncherir.Attributes["itemid"];
            double prixOffert = Convert.ToDouble(Request["ctl00$ContentPlaceHolder1$txtOffre" + itemID].Trim());
            OFFRE offre = new OFFRE();
            offre.ID_ITEM = Convert.ToInt16(itemID);
            offre.ID_MEMBRE = Convert.ToInt16(Session["userID"]);
            offre.PRIX_OFFRE = prixOffert;
            offre.DATE_OFFRE = DateTime.Now;

            BD_Entities maBd = new BD_Entities();
            maBd.OFFRE.Add(offre);
            maBd.SaveChanges();
            AjouterMessage(false, "Votre offre a bien été ajoutée! Merci.");
            Response.Redirect(Request.RawUrl);
        }

        private ITEM ObtenirItemParID(int idItem)
        {
            using (BD_Entities monEntity = new BD_Entities())
            {
                try
                {
                    ITEM itemRetour = (from item in monEntity.ITEM
                                where item.ID_ITEM == idItem
                                select item).FirstOrDefault();
                    return itemRetour;
                }
                catch (Exception e) { return null; }
            }
        }

        void btnRejeter_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnDescription_Click(object sender, EventArgs e)
        {
            Button btnDesc = (Button)sender;
            Server.Transfer("ArticleUnique.aspx?item=" + btnDesc.Attributes["itemid"], true);
        }

        private OFFRE ObtenirMeilleurOffreSurProduit(ITEM item)
        {
            OFFRE offreMaxObjet = null;
            double offreMax = 0;
            foreach (OFFRE offre in item.OFFRE)
            {
                if (offre.PRIX_OFFRE > offreMax)
                {
                    offreMax = offre.PRIX_OFFRE;
                    offreMaxObjet = offre;
                }
            }
            return offreMaxObjet;
        }

        private void AjouterMessage(bool erreur, string message)
        {
            this.divConnErreur.InnerHtml = "<div class=\"alert alert-" + (erreur == true ? "danger" : "success") + "\" role=\"alert\">" + message + "</div>";
        }
    }
}