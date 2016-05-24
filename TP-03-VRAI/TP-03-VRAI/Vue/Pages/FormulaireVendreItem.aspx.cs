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

            Label lblTitreItem = new Label();
            lblTitreItem.Text = "Titre de l'item";
            Label lblDescription = new Label();
            lblDescription.Text = "Description";
            Label lblPrix = new Label();
            lblPrix.Text = "Prix plancher:";
            Button btnPosterItem = new Button();
            btnPosterItem.Text = "Publier l'annonce";

            //Input
            TextBox txtTitre = new TextBox();
            TextBox txtDescription = new TextBox();
            TextBox txtPrixPlancher = new TextBox();
            Image image = new Image();

            //DESIGN / ESTHÉTIQUE
            txtTitre.Width = 300;
            txtDescription.Width = 600;
            txtDescription.Height = 200;
            txtPrixPlancher.Width = 80;

            this.formAjoutItem.Controls.Add(lblTitreItem);
            this.formAjoutItem.Controls.Add(txtTitre);
            this.formAjoutItem.Controls.Add(lblDescription);
            this.formAjoutItem.Controls.Add(txtDescription);
            this.formAjoutItem.Controls.Add(image);
            this.formAjoutItem.Controls.Add(lblPrix);
            this.formAjoutItem.Controls.Add(txtPrixPlancher);
            this.formAjoutItem.Controls.Add(btnPosterItem);

        }
    }
}