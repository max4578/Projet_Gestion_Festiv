using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestionFestival.DAL;
namespace gestionFestival.Models
{
    public class CMateriel
    {

        /*******************/
        /*    Attribut     */
        /*******************/
        private int id;
        private string nom;
        private double prix;
        private int quantité;
        private DataContextDataContext db = new DataContextDataContext();

        /*******************/
        /*   Propriétés    */
        /*******************/


        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public double Prix
        {
            get { return prix; }
            set { prix = value; }
        }


        public int Quantité
        {
            get { return quantité; }
            set { quantité = value; }
        }

        public int Quantite { get; internal set; }



        /*******************/
        /*  Constructeur   */
        /*******************/

        public CMateriel(int id,string nom, double prix, int qtt)
        {
            this.id = id;
            this.nom = nom;
            this.prix = prix;
            this.quantité = qtt;
        }

        public CMateriel(string nom, double prix, int qtt)
        {
            this.nom = nom;
            this.prix = prix;
            this.quantité = qtt;
        }

        /*******************/
        /*    Méthodes     */
        /*******************/

        public bool CreerMateriel(int idPoste)
        {
            if (db.VerifMontant(idPoste, (decimal)prix*quantité).FirstOrDefault().Column1 >= 0)
            {
                db.AjouterMateriel(nom, Convert.ToDecimal(prix), quantité, idPoste);
                return true;
            }
            else
                return false;
        }

        public bool ModifMateriel(int idPoste)
        {

            if (db.VerifMontant(idPoste, (decimal)prix*quantité).FirstOrDefault().Column1 >= 0)
            {
                db.UpdateMateriel(nom, (decimal)prix, quantité, id);
                return true;
            }
            else
                return false;
            
        }


        public void SupprimerMateriel()
        {
            db.DeleteMateriel(id);
        }
    }
}
 