using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestionFestival.Models
{
    public class CMateriel
    {

        /*******************/
        /*    Attribut     */
        /*******************/
        private string nom;
        private double prix;
        private int quantite;


        /*******************/
        /*   Proprietes    */
        /*******************/

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


        public int Quantite
        {
            get { return quantite; }
            set { quantite = value; }
        }



        /*******************/
        /*  Constructeur   */
        /*******************/

        public CMateriel()
        {

        }

        public CMateriel(string nom, double prix, int quantite)
        {
            this.nom = nom;
            this.prix = prix;
            this.quantite = quantite;
        }

        /*******************/
        /*    Methodes     */
        /*******************/
        
    }
}