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
    
    public partial class ITEM
    {
        public ITEM()
        {
            this.OFFRE = new HashSet<OFFRE>();
        }
    
        public int ID_ITEM { get; set; }
        public string VENDEUR { get; set; }
        public string DESCRIPTION { get; set; }
        public string PHOTO_URL { get; set; }
        public string CATEGORIE { get; set; }
        public Nullable<double> PRIX_PLANCHER { get; set; }
        public string STATUT { get; set; }
        public string TITRE { get; set; }
        public Nullable<System.DateTime> DATE_INSCRIPTION { get; set; }
    
        public virtual ICollection<OFFRE> OFFRE { get; set; }
    }
}
