using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MetierSharedMemory.Model
{
    public class Memoire
    {
        [Key]
        public int IdMemoire {get;set;}
        // Titre,Annee,statut,Auteur,Path,DatePublication
        [MaxLength(300, ErrorMessage = "taille maximale 300"), Required(ErrorMessage = "*")]
        [Display(Name = "Titre")]
        public string Titre { get; set; }

        [Display(Name = "Annee memoire")]
        [Required(ErrorMessage = "*")]
        public int Annee { get; set; }


        [Display(Name = "Statut memoire")]
        [MaxLength(10, ErrorMessage = "taille maximale 10")]
        public string Statut { get; set; }


        [Display(Name = "Auteur memoire")]
        [MaxLength(80, ErrorMessage = "taille maximale 80"), Required(ErrorMessage = "*")]
        public string Auteur { get; set; }


        
        [Display(Name = "fichier")]
        [MaxLength(30, ErrorMessage = "taille maximale 30"), Required(ErrorMessage = "*")]
        
        public string fileName { get; set; }

        // extension
        [Display(Name = "extension")]
        [MaxLength(10, ErrorMessage = "taille maximale 10"), Required(ErrorMessage = "*")]
        public string extension { get; set; }



        [DataType(DataType.Date),Required(ErrorMessage="*")]
        [Display(Name = "Date publication memoire")]

        public DateTime? DatePublication {get;set;}

        // public virtual ICollection<Jury> Jury {get;set;}

    }
}