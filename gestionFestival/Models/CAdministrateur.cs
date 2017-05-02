using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestionFestival.Models
{
    public class CAdministrateur
    {

        /*******************/
        /*    Attribut     */
        /*******************/
        private string nom;
        private string prénom;
        private string téléphone;
        private DateTime dateNaiss;


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


        /*******************/
        /*  Constructeur   */
        /*******************/

        public CAdministrateur()
        {

        }

        /*******************/
        /*    Méthodes     */
        /*******************/

        public void AjouterPoste()
        {

        }

        public void DemandeModifPoste()
        {

        }


        public void DemandeSuppressionPoste()
        {

        }

        public void AssignerPoste(CPoste p)
        {

        }

        public void DefinirBudget()
        {

        }

        public void AjouterResponsable()
        {

        }

        public void ChangerResponsablePoste()
        {

        }
    }
}