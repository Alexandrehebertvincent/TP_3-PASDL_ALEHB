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

        #region "ATTRIBUTS"

        private MEMBRES _leMembre;

        #endregion

        #region "PROPRIÉTÉS"

        public MEMBRES LeMembre
        {
            get { return this._leMembre; }
            set { this._leMembre = value; }
        }

        #endregion

        #region "ÉVÈNEMENTS"

        protected void Page_Load(object sender, EventArgs e)
        {
            // Vérification d'une connexion existante.
            if (Session["user"] == null)
            {
                // Le membre n'est pas connecté.
                this.afficherFormConnexion(true);
            }
            else
            {
                // Le membre est connecté.
                // TODO :::
                // Le membre doit alors être initialisé.
                // LeMembre = new MEMBRES();
                this.afficherFormConnexion(false);
            }
            /*
            using (MagasinJouetsEntities1 monEntity = new MagasinJouetsEntities1())
            {
                try
                {

                    var tousLesJouets = from jouet in monEntity.Jouets
                                        where jouet.prix > 10
                                        orderby jouet.dateCreation descending
                                        select jouet;

                    gridJouets.DataSource = tousLesJouets;
                    //gridJouets.DataBind();

                }
                catch (EntityDataSourceValidationException exc)
                {
                    messageErreur.Text = exc.Message;
                }

            }
            */

        }

        private void AfficherLesItemsEnVente()
        {
            throw new NotImplementedException();
        }

        protected void btnInscription_Click(object sender, EventArgs e)
        {
            // Vérifier l'identité du membre.
            BD_Entities donnees = new BD_Entities();
            string requete = (from membre in donnees.MEMBRES
                            where membre.NOM_MEMBRE.Equals(this.txtUser.Text.Trim(), StringComparison.CurrentCultureIgnoreCase) && membre.MOT_DE_PASSE.Equals(this.txtPass.Text, StringComparison.CurrentCulture)
                            select membre.STATUT).FirstOrDefault();
            if (requete != null)
            {
                this.divConnErreur.InnerHtml = "<div class=\"alert alert-success\" role=\"alert\">Vous êtes connecté avec succès!</div>";
                Session["user"] = this.txtUser.Text.Trim();
                Session["userStatut"] = requete.ToString().Trim();

                afficherControlesMembreConnecte(requete.ToString().Trim());

                Response.Redirect(Request.RawUrl);
            }
            else
                this.divConnErreur.InnerHtml = "<div class=\"alert alert-danger\" role=\"alert\">Connexion impossible. Veuillez réessayer.</div>";
        }

        protected void btnDeconnexion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Articles.aspx");
        }

        #endregion

        #region "MÉTHODES"

        private void afficherFormConnexion(bool valeur)
        {
            this.divConnexion.Visible = valeur;
            this.divDeconnexion.Visible = !valeur;
        }

        private void afficherControlesMembreConnecte(string typeMembre)
        {
            // Vérifier la connexion du membre.
            this.lblTitreJumbo.InnerText = "Bonjour " + Session["user"];
            this.afficherFormConnexion(false);

            switch (typeMembre) {
                case "Admin":
                    break;
                case "Acheteur":
                    break;
                case "Vendeur":
                    break;
                default:
                    throw new Exception("Le membre doit être un administrateur, un vendeur ou un acheter pour activer les contrôles spécifiques.");
            }
        }

        #endregion
    }
}