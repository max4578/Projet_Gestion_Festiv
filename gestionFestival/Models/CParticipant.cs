using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestionFestival.Models
{
    public class CParticipant:CPersonnel
    {


        /*******************/
        /*    Attribut     */
        /*******************/
        private double salaireParticipation;
        private int heureTravail;


        /*******************/
        /*   Propriétés    */
        /*******************/

        public double Salaire
        {
            get { return salaireParticipation; }
            set { salaireParticipation = value; }
        }


        public int HeureTravail
        {
            get { return heureTravail; }
            set { heureTravail = value; }
        }



        /*******************/
        /*  Constructeur   */
        /*******************/

        public CParticipant()
        {

        }

        public CParticipant(string nom, string prénom, string téléphone,
        DateTime dateNaiss, string mail, string spécialisation,
        double salaireParticipation,int heureTravail)
        :base(nom,prénom, téléphone,dateNaiss,mail,spécialisation)
        {
            this.salaireParticipation = salaireParticipation;
            this.heureTravail = heureTravail;
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