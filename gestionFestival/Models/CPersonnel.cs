using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestionFestival.DAL;

namespace gestionFestival.Models
{
    public class CPersonnel
    {

        /*******************/
        /*    Attribut     */
        /*******************/
        private int id;
        private string nom;
        private string prenom;
        private string telephone;
        private DateTime dateNaiss;
        private string mail;
        private string specialisation;
        private string libelRole;
        private DataContextDataContext db = new DataContextDataContext();


        /*******************/
        /*   Proprietes    */
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

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }

        public DateTime DateNaiss
        {
            get { return dateNaiss; }
            set { dateNaiss = value; }
        }

        internal bool AjouterPersonnel(string pass)
        {
            throw new NotImplementedException();
        }

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        public string Specialisation
        {
            get { return specialisation; }
            set { specialisation = value; }
        }

        public string Role
        {
            get { return libelRole; }
            set { libelRole = value; }
        }



        /*******************/
        /*  Constructeur   */
        /*******************/

        public CPersonnel()
        {

        }

        public CPersonnel(int id)
        {
            this.id = id;
        }

        public CPersonnel(int id, string nom, string prenom, string telephone,
            DateTime dateNaiss, string mail, string specialisation)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.telephone = telephone;
            this.dateNaiss = dateNaiss;
            this.mail = mail;
            this.specialisation = specialisation;

        }

        public CPersonnel(string nom, string prenom, string telephone, DateTime dateNaiss, string mail, string specialisation)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.telephone = telephone;
            this.dateNaiss = dateNaiss;
            this.mail = mail;
            this.specialisation = specialisation;
        }


        /*******************/
        /*    Methodes     */
        /*******************/


        public void ModifierPersonnel()
        {

        }


        public void SupprimerPersonnel()
        {

        }

        public object Connexion(string email, string pass)
        {
            VérificationLoginResult query = db.VérificationLogin(email, pass).FirstOrDefault();
            if (query != null)
            {
                id = query.idPersonnel;
                nom = query.nomPersonnel;
                prenom = query.prenomPersonnel;
                telephone = query.telephone;
                dateNaiss = query.dateNaissance;
                email = query.email;
                specialisation = query.specialisation;
                libelRole = query.libelRole;
                return FindStatut(query);
            }
            else
                return null;
           
        }







        private object FindStatut(VérificationLoginResult q)
        {

            var sal=db.GetSalaire(id).FirstOrDefault();

            if (q.libelRole=="Admin")
                return new CAdministrateur(q.nomPersonnel, q.prenomPersonnel, q.telephone, q.dateNaissance, q.email, q.specialisation);
            else if (q.libelRole=="Comptable")
                return new CComptable(q.nomPersonnel, q.prenomPersonnel, q.telephone, q.dateNaissance, q.email, q.specialisation, (double)sal.salaireHoraire, sal.nbrHeure);
            else if (q.libelRole == "Responsable")
                return new CResponsable(q.idPersonnel, q.nomPersonnel, q.prenomPersonnel, q.telephone, q.dateNaissance, q.email, q.specialisation,sal.nbrHeure,(double)sal.salaireHoraire);
            else if (q.libelRole == "Participant")
                return new CParticipant(q.idPersonnel, q.nomPersonnel, q.prenomPersonnel, q.telephone, q.dateNaissance, q.email, q.specialisation, (double)sal.salaireHoraire,sal.nbrHeure);
            else
                return new CPersonnel(q.idPersonnel, q.nomPersonnel, q.prenomPersonnel, q.telephone, q.dateNaissance, q.email, q.specialisation);


        }

        public bool AjoutPersonnel(string pass)
        {
            if (db.VérificatioCompteExistant(mail).First().Column1 == 0)
            {
                db.AjouterPersonnel(nom, prenom, dateNaiss, mail, telephone, specialisation, pass);
                return true;
            }
            else
            {
                return false;
            }
        }


        public override string ToString(){
            return "test";
        }
    }
}