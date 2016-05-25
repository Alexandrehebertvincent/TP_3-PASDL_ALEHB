using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_03_VRAI.Vue.Pages
{
    public partial class ArticleUnique : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string IdItemQueryString = Request.QueryString["item"].ToString().Trim();
            

            using (BD_Entities monEntity = new BD_Entities())
            {
                try
                {
                    var leItem = (from item in monEntity.ITEM
                                       orderby item.DATE_INSCRIPTION descending
                                       where item.ID_ITEM.ToString().Trim() == IdItemQueryString
                                       select item).FirstOrDefault();

                    Label lblTitre = new Label();
                    lblTitre.Text = "<h2>Fiche de l'article: " + leItem.TITRE + "LE TITRE DEVRAIT S'AFFICHER ICI" + 
                        "</h2>";
                    
                    Label afflblDescription = new Label();
                    afflblDescription.Text = "Description: ";
                    Label lblDescription = new Label();
                    lblDescription.Text = leItem.DESCRIPTION.ToString();
                    Panel panDesc = new Panel();
                    panDesc.CssClass = "caption";
                    panDesc.Controls.Add(afflblDescription);
                    panDesc.Controls.Add(lblDescription);

                    
                    Label afflblPrixPlancher = new Label();
                    afflblPrixPlancher.Text = "Prix plancher: ";
                    Label lblPrixPlancher = new Label();
                    lblPrixPlancher.Text = leItem.PRIX_PLANCHER.ToString();
                    Panel panPrix = new Panel();
                    panPrix.CssClass = "caption";
                    panPrix.Controls.Add(afflblPrixPlancher);
                    panPrix.Controls.Add(lblPrixPlancher);

                    Image image = new Image();
                    image.ImageUrl = "../../img/" + leItem.PHOTO_URL.Trim();

                    Panel grandDiv = new Panel();
                    grandDiv.CssClass = "col-xs-12 col-sm-10";
                    grandDiv.Controls.Add(lblTitre);
                    grandDiv.Controls.Add(image);
                    grandDiv.Controls.Add(panPrix);
                    grandDiv.Controls.Add(panDesc);

                    Panel TresGrandDiv = new Panel();
                    TresGrandDiv.CssClass = "row";
                    TresGrandDiv.Controls.Add(grandDiv);

                    affichageItem.Controls.Add(TresGrandDiv);
                    
                }
                catch (EntityDataSourceValidationException exc)
                {
                    messageErreur.Text = exc.Message;
                }
            }

                
                
            }

    }
}