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

        public CParticipant(int id, string nom, string prénom, string téléphone,
        DateTime dateNaiss, string mail, string spécialisation,
        double salaireParticipation,int heureTravail)
        :base(id,nom,prénom, téléphone,dateNaiss,mail,spécialisation)
        {
            this.salaireParticipation = salaireParticipation;
            this.heureTravail = heureTravail;
        }

        public CParticipant(int id, string nom, string prenom, string telephone, DateTime dateNaiss, string mail, string specialisation) : base(id, nom, prenom, telephone, dateNaiss, mail, specialisation)
        {
        }

        /*******************/
        /*    Méthodes     */
        /*******************/

        public void CreerParticipant(int idResp,int idPoste)
        {
            AjouterParticipant(Id,(decimal)salaireParticipation,heureTravail,idResp,idPoste);
        }

        public void ModifParticipant()
        {
            UpdateParticipant((decimal)salaireParticipation,heureTravail,Id);
        }


        public void SupprimerParticipant()
        {
            DeleteParticipant(Id);
        }
    }
}