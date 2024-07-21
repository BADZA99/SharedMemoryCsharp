using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetierSharedMemory.Model
{
    //jury herite de personne (:personne)
    public class Jury:Personne
    {
        // string garde et specialiste
        [MaxLength(20, ErrorMessage = "taille maximale 20"), Required(ErrorMessage = "*")]
        [Display(Name = "grade membre jury")]
        public string Garde { get; set; }
        [MaxLength(50, ErrorMessage = "taille maximale 50"), Required(ErrorMessage = "*")]
        [Display(Name = "specialite membre jury")]
        public string Specialiste { get; set; }

        // public virtual ICollection<Memoire> Memoires { get; set; }


    }
}