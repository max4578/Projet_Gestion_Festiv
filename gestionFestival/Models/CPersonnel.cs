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
        private string prénom;
        private string téléphone;
        private DateTime dateNaiss;
        private string mail;
        private string spécialisation;
        private string infoCompétence;


        /*******************/
        /*   Propriétés    */
        /*******************/

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Prénom
        {
            get { return prénom; }
            set { prénom = value; }
        }

        public string Téléphone
        {
            get { return téléphone; }
            set { téléphone = value; }
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

        public string Spécialisation
        {
            get { return spécialisation; }
            set { spécialisation = value; }
        }

        public string InfoCompétence
        {
            get { return infoCompétence; }
            set { infoCompétence = value; }
        }

        /*******************/
        /*  Constructeur   */
        /*******************/

        public CPersonnel()
        {

        }


        /*******************/
        /*    Méthodes     */
        /*******************/

        public void CréePersonnel()
        {

        }

        public void ModifierPersonnel()
        {

        }


        public void SupprimerPersonnel()
        {

        }

        public bool Connexion(string email, string pass)
        {
            DataContextDataContext db = new DataContextDataContext();

            if (db.VérificationLogin(email, pass).Count() > 0)
            {
                return true;
            }
            else
                return false;
        }
    }
}