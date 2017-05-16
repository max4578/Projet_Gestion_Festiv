using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestionFestival.DAL;


namespace gestionFestival.Models
{
    public class CParticipant:CPersonnel
    {


        /*******************/
        /*    Attribut     */
        /*******************/
        private double salaireParticipation;
        private int heureTravail;
        private DataContextDataContext db = new DataContextDataContext();

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
        DateTime dateNaiss, string mail, string spécialisation,string role,
        double salaireParticipation,int heureTravail)
        :base(id,nom,prénom, téléphone,dateNaiss,mail,spécialisation,role)
        {
            this.salaireParticipation = salaireParticipation;
            this.heureTravail = heureTravail;
        }

        public CParticipant(int id, string nom, string prenom, string telephone, DateTime dateNaiss, string mail, string specialisation,string role) : base(id, nom, prenom, telephone, dateNaiss, mail, specialisation,role)
        {
        }

        /*******************/
        /*    Méthodes     */
        /*******************/

        public void CreerParticipant(int idPoste)
        {
            db.AjouterParticipant(Id,(decimal)salaireParticipation,heureTravail,idPoste);
        }

        public void ModifParticipant()
        {
            db.UpdateParticipant((decimal)salaireParticipation,heureTravail,Id);
        }


        public void SupprimerParticipant()
        {
            db.DeleteParticipant(Id);
        }
    }
}