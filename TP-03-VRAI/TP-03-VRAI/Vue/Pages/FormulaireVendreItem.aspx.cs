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

            Panel TresGrandDiv = new Panel();
            TresGrandDiv.CssClass = "row";

            Panel GrandDiv = new Panel();
            GrandDiv.CssClass = "col-xs-12 col-sm-6";
            //GrandDiv.CssClass = "form-inline";

            Label lblTitreItem = new Label();
            lblTitreItem.Text = "Titre de l'item";
            Label lblDescription = new Label();
            lblDescription.Text = "Description";
            Label lblImage = new Label();
            lblImage.Text = "Ajouter une image"; 
            Label lblPrix = new Label();
            lblPrix.Text = "Prix plancher:";
            Button btnPosterItem = new Button();
            btnPosterItem.Text = "Publier l'annonce";

            //Input
            TextBox txtTitre = new TextBox();
            txtTitre.CssClass = "form-control";
            TextBox txtDescription = new TextBox();
            txtDescription.CssClass = "form-control";
            FileUpload image = new FileUpload();
            TextBox txtPrixPlancher = new TextBox();
            
            //DESIGN / ESTHÉTIQUE
            txtTitre.Width = 300;
            txtDescription.Width = 600;
            txtDescription.Height = 200;
            txtPrixPlancher.Width = 80;

            Panel divTitre = new Panel();
            divTitre.CssClass = "form-group";
            divTitre.Controls.Add(lblTitreItem);
            divTitre.Controls.Add(txtTitre);
            GrandDiv.Controls.Add(divTitre);

            Panel divDescription = new Panel();
            divDescription.CssClass = "form-group";
            divDescription.Controls.Add(lblDescription);
            divDescription.Controls.Add(txtDescription);
            GrandDiv.Controls.Add(divDescription);

            Panel divPrix = new Panel();
            divPrix.CssClass = "form-group";
            divPrix.Controls.Add(lblPrix);
            divPrix.Controls.Add(txtPrixPlancher);
            GrandDiv.Controls.Add(divPrix);

            Panel divImage = new Panel();
            divImage.CssClass = "form-group";
            divImage.Controls.Add(lblImage);
            divImage.Controls.Add(image);
            GrandDiv.Controls.Add(divImage);

            TresGrandDiv.Controls.Add(GrandDiv);
            


  //           <div class="form-group">
  //  <label for="exampleInputFile">File input</label>
  //  <input type="file" id="exampleInputFile">
  //  <p class="help-block">Example block-level help text here.</p>
  //</div>



         
            

            //this.formAjoutItem.Controls.Add(lblTitreItem);
            //this.formAjoutItem.Controls.Add(txtTitre);
            //this.formAjoutItem.Controls.Add(lblDescription);
            //this.formAjoutItem.Controls.Add(txtDescription);
            //this.formAjoutItem.Controls.Add(image);
            //this.formAjoutItem.Controls.Add(lblPrix);
            //this.formAjoutItem.Controls.Add(txtPrixPlancher);
            //this.formAjoutItem.Controls.Add(btnPosterItem);

            this.formAjoutItem.Controls.Add(TresGrandDiv);
        }
    }
}