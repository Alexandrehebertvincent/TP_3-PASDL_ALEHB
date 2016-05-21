//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TP_03_VRAI
{
    using System;
    using System.Collections.Generic;
    
    public partial class MEMBRES
    {
        public MEMBRES()
        {
            this.OFFRE = new HashSet<OFFRE>();
        }
    
        public int ID_MEMBRE { get; set; }
        public string NOM_MEMBRE { get; set; }
        public string MOT_DE_PASSE { get; set; }
        public string STATUT { get; set; }
        public string CONTACT { get; set; }
    
        public virtual ICollection<OFFRE> OFFRE { get; set; }

        #region "MÉTHODES - ADMIN"

        /// <summary>
        /// TODO :::
        /// Seulement si le membre est un admin.
        /// </summary>
        /// <param name="unMembre">Membre à supprimer de la BD.</param>
        /// <returns>Valeur de retour de l'opération. (BOOL)</returns>
        public bool EffacerMembreBD(MEMBRES unMembre)
        {
            if (this.STATUT == "Admin")
            {
                return true;
            }
            else {
                throw new Exception("Le membre doit être un administrateur pour supprimer un autre membre.");
            }
        }

        /// <summary>
        /// TODO :::
        /// Seulement si le membre est un admin, pour rejeter un item en vente.
        /// </summary>
        /// <param name="unItem">L'item à rejeter</param>
        /// <returns>Valeur de retour de l'opération. (BOOL)</returns>
        public bool RejeterItemEnEnchere(ITEM unItem)
        {
            if (this.STATUT == "Admin")
            {
                return true;
            }
            else
            {
                throw new Exception("Le membre doit être un administrateur pour rejeter un item en vente.");
            }
        }

        #endregion

        #region "MÉTHODES - ACHETEUR & VENDEUR"

        /// <summary>
        /// TODO :::
        /// Lorsqu'un acheteur enchérit pour obtenir un item.
        /// </summary>
        /// <param name="unItem">L'item désiré</param>
        /// <param name="prixPropose">Prix proposé pour l'item</param>
        /// <returns>Vrai si le client est maintenant le premier dans l'enchère et faux si sa mise n'est pas assez grosse.</returns>
        public bool EnchérirItemAchat(ITEM unItem, double prixPropose)
        {
            if (this.STATUT == "Acheteur" || this.STATUT == "Vendeur")
            {
                // S'il s'agit d'un vendeur, il faut vérifier qu'il ne s'agit pas d'un objet qu'il possède.
                if (this.STATUT == "Vendeur")
                {
                    if (this.NOM_MEMBRE == unItem.VENDEUR)
                    {
                        throw new Exception("Le vendeur ne peut pas enchérir sur un item lui appartenant.");
                    }
                }

                // Après vérification, l'opération peut être effectuée.
                return true;
            }
            else
            {
                throw new Exception("Seulement un acheteur peut enchérir dans une vente d'un item.");
            }
        }

        #endregion

        #region "MÉTHODES - VENDEUR"

        /// <summary>
        /// TODO :::
        /// Ajouter un item en vente. Le membre doit être un vendeur.
        /// </summary>
        /// <param name="unItem">Item a ajouter en vente.</param>
        /// <returns>Résultat de l'opération. (BOOL)</returns>
        public bool AjouterItem(ITEM unItem)
        {
            if (this.STATUT == "Vendeur")
            {
                return true;
            }
            else
            {
                throw new Exception("Le membre doit être un vendeur pour ajouter un item en vente.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unItem"></param>
        /// <returns></returns>
        public bool AccepterUneOffre(ITEM unItem)
        {
            if (this.STATUT == "Vendeur")
            {
                // Il faut vérifier qu'il s'agit d'un item qu'il possède.
                if (this.NOM_MEMBRE != unItem.VENDEUR)
                {
                    throw new Exception("Le vendeur ne peut pas vendre un item ne lui appartenant pas.");
                }

                // Après vérification, l'opération peut être effectuée.
                return true;
            }
            else
            {
                throw new Exception("Le membre doit être un vendeur pour accepter une offre.");
            }
        }

        #endregion
    }
}
