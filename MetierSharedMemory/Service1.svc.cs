using MetierSharedMemory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace MetierSharedMemory
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        BdSharedMemoryContext db= new BdSharedMemoryContext();
        
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        /// <summary>
        /// Ajoute un nouveau membre du jury à la base de données.
        /// </summary>
        /// <param name="jury">L'objet Jury à ajouter.</param>
        /// <returns>Vrai si le membre du jury a été ajouté avec succès, faux en cas d'exception.</returns>
        public bool AddJury(Jury jury)
        {
           try
           {
            db.Jurys.Add(jury);
            db.SaveChanges();
            return true;
           }
           catch (Exception ex)
           {
            // afficher ex sur la console
            Console.WriteLine("Service1-AddJury",ex.ToString());

            return false;
           }
           

        }

        /// <summary>
        /// Modifie un membre du jury existant dans la base de données.
        /// </summary>
        /// <param name="jury">L'objet Jury contenant les informations mises à jour.</param>
        /// <returns>Vrai si le membre du jury a été mis à jour avec succès, faux sinon.</returns>

        public bool EditJury(Jury jury)
        {
            try
            {
                var lejury= db.Jurys.Find(jury.IdPersonne);
                if (lejury != null)
                {
                    lejury.Nom = jury.Nom;
                    lejury.Prenom = jury.Prenom;
                    lejury.Garde = jury.Garde;
                    lejury.Specialiste = jury.Specialiste;
                    db.SaveChanges();
                    
                return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Service1-editJury",ex.ToString());
                return false;
            }
            return false;

        }

        /// <summary>
        /// Récupère un membre du jury à partir de son identifiant.
        /// 
        /// </summary>
        /// 
        /// <param name="id">L'identifiant du membre du jury à supprimer.</param>
        /// 
        /// <returns>Vrai si le membre du jury a été supprimé avec succès, faux sinon.</returns>
        /// 
        public bool DeleteJury(int IdJury)
        {
            try
            {
                var lejury = db.Jurys.Find(IdJury);
                if (lejury != null)
                {
                    db.Jurys.Remove(lejury);
                    db.SaveChanges();
                return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Service1-deleteJury",ex.ToString());
                return false;
            }
            return false;
        
        }


        /// <summary>
        /// Récupère un membre du jury à partir de son identifiant.
        ///     
        /// </summary>
        ///     
        /// <returns>Une liste de tous les membres du jury dans la base de données.</returns>
        /// 
        public List<Jury> GetJurys()
        {
            try
            {
                return db.Jurys.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Service1-getJurys",ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// 
        /// Récupère un membre du jury à partir de son nom,specialite,prenom.
        /// 
        /// </summary>
        /// 
        /// <param name="nom">Le nom du membre du jury à récupérer.</param>
        /// 
        /// <param name="specialite">La specialite du membre du jury à récupérer.</param>
        /// 
        /// <param name="prenom">Le prenom du membre du jury à récupérer.</param>
        /// 
        /// <returns>Le membre du jury correspondant aux critères de recherche.</returns>
        /// 
        public Jury GetsJury(string nom, string specialite, string prenom)
        {
            try
            {
                // Vérifier si les paramètres ne sont pas vides
                if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(specialite) || string.IsNullOrEmpty(prenom))
                {
                    return null;
                }

                // Filtrer la liste selon les critères fournis
                var liste = db.Jurys.AsQueryable();
                if (!string.IsNullOrEmpty(nom))
                {
                    liste = liste.Where(j => j.Nom.ToUpper().Contains(nom.ToUpper()));
                }
                if (!string.IsNullOrEmpty(specialite))
                {
                    liste = liste.Where(j => j.Specialiste.ToUpper().Contains(specialite.ToUpper()));
                }
                if (!string.IsNullOrEmpty(prenom))
                {
                    liste = liste.Where(j => j.Prenom.ToUpper().Contains(prenom.ToUpper()));
                }

                // Retourner le premier Jury correspondant ou null si aucun n'est trouvé
                return liste.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Service1-getJury", ex.ToString());
                return null;
            }
        }


    }
}
