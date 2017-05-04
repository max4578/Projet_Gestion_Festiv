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
        private string nom;
        private string prenom;
        private string telephone;
        private DateTime dateNaiss;
        private string mail;
        private string specialisation;
        private DALPersonnel DP;
        


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
            DP = new DALPersonnel();
            return DP.DB_Connexion(email,pass);         
        }


        public void Inscription(string pass)
        {
            DP = new DALPersonnel();
            DP.AjouterPersonnel(nom,prenom,dateNaiss,mail,telephone,specialisation,pass);
            
        }

    }
}