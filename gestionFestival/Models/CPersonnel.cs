using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestionFestival.DAL;

namespace gestionFestival.Models
{
    public class CPersonnel:DataContextDataContext
    {

        /*******************/
        /*    Attribut     */
        /*******************/
        private string nom;
        private string prenom;
        private string telephone;
        private DateTime dateNaiss;
        private string mail;
        private string specialisation;
        


        /*******************/
        /*   Proprietes    */
        /*******************/

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

       

        /*******************/
        /*  Constructeur   */
        /*******************/

        public CPersonnel()
        {

        }

        public CPersonnel(string nom, string prenom, string telephone,
            DateTime dateNaiss, string mail, string specialisation)
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
        internal bool AjouterPersonnel(string pass)
        {
            throw new NotImplementedException();
        }
        public void CreePersonnel()
        {

        }

        public void ModifierPersonnel()
        {

        }


        public void SupprimerPersonnel()
        {

        }

        public object Connexion(string email, string pass)
        {
            VérificationLoginResult querry = VérificationLogin(email, pass).FirstOrDefault();
            if (querry != null)
            {
                return FindStatut(querry.idPers, querry);
            }
            else
                return null;

        }





        

        private object FindStatut(int id, VérificationLoginResult q)
        {


            var querry1 = isAdmin(id).FirstOrDefault();
            var querry2 = isCompt(id).FirstOrDefault();
            var querry3 = isResponsable(id).FirstOrDefault();
            var querry4 = isParticipant(id).FirstOrDefault();


            if (querry1 != null)
                return new CAdministrateur(q.nomPers, q.prenomPers, q.telephone, q.dateNaiss, q.email, q.specialisation);
            else if (querry2 != null)
                return new CComptable(q.nomPers, q.prenomPers, q.telephone, q.dateNaiss, q.email, q.specialisation, Convert.ToDouble(querry2.salaire), Convert.ToDouble(querry2.budgetDisp));
            else if (querry3 != null)
                return new CResponsable(q.nomPers, q.prenomPers, q.telephone, q.dateNaiss, q.email, q.specialisation, querry3.fonction, Convert.ToDouble(querry3.salaireResp));
            else if (querry4 != null)
                return new CParticipant(q.nomPers, q.prenomPers, q.telephone, q.dateNaiss, q.email, q.specialisation, Convert.ToDouble(querry4.salaire), querry4.heureTravail);
            else
                return new CPersonnel(q.nomPers, q.prenomPers, q.telephone, q.dateNaiss, q.email, q.specialisation);


        }

        public bool AjoutPersonnel(string pass)
        {
            if (VérificatioCompteExistant(mail).First().Column1 == 0)
            {
                AjouterPersonnel(nom, prenom, dateNaiss, mail, telephone, specialisation, pass);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}