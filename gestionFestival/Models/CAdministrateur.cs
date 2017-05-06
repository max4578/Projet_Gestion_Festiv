using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestionFestival.Models
{
    public class CAdministrateur:CPersonnel
    {

        /*******************/
        /*    Attribut     */
        /*******************/

        private DateTime dateFest;
        private string nomFest;
        private CComptable comptable;

        /*******************/
        /*   Propriétés    */
        /*******************/

        public string NomFest
        {
            get { return nomFest; }
            set { nomFest = value; }
        }

       
        public DateTime DateFest
        {
            get { return dateFest; }
            set { dateFest = value; }
        }


        /*******************/
        /*  Constructeur   */
        /*******************/

        public CAdministrateur()
        {

        }

        public CAdministrateur( string nom ,string prénom,string téléphone,
            DateTime dateNaiss ,string mail,string spécialisation,string nomFest, DateTime dateFest):base(nom,prénom, téléphone,dateNaiss,mail,spécialisation)
        {
            this.NomFest = NomFest;
            this.dateFest = dateFest;
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

        public void DefinirBudget(double budget)
        {
            comptable.DemandeModifierBudget(budget);
        }

        public void AjouterResponsable()
        {

        }

        public void ChangerResponsablePoste()
        {

        }
    }
}