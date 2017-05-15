using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestionFestival.DAL;
namespace gestionFestival.Models
{
    public class CMateriel:DataContextDataContext
    {

        /*******************/
        /*    Attribut     */
        /*******************/
        private int id;
        private string nom;
        private double prix;
        private int quantité;


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

        public void CreerMateriel(int idPers,int idPoste)
        {
            AjouterMateriel(nom, Convert.ToDecimal(prix), quantité, idPers, idPoste);
        }

        public void ModifMateriel()
        {
            UpdateMateriel(nom,(decimal)prix,quantité,id);
        }


        public void SupprimerMateriel()
        {
            DeleteMateriel(id);
        }
    }
}
 