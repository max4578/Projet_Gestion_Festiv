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
        private int quantité;


        /*******************/
        /*   Propriétés    */
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


        public int Quantité
        {
            get { return quantité; }
            set { quantité = value; }
        }



        /*******************/
        /*  Constructeur   */
        /*******************/

        public CMateriel()
        {

        }

        /*******************/
        /*    Méthodes     */
        /*******************/

        public void CreerParticipant()
        {

        }

        public void DemandeModifParticipant()
        {

        }


        public void SupprimerParticipant()
        {

        }
    }
}