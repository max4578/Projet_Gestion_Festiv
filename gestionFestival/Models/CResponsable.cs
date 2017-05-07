using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestionFestival.DAL;
namespace gestionFestival.Models
{
    public class CResponsable:CPersonnel
    {

        /*******************/
        /*    Attribut     */
        /*******************/
        private string fonction;
        private double salaireResp;


        /*******************/
        /*   Propriétés    */
        /*******************/

        public string Fonction
        {
            get { return fonction; }
            set { fonction = value; }
        }

        public double Salaire
        {
            get { return salaireResp; }
            set { salaireResp = value; }
        }

        /*******************/
        /*  Constructeur   */
        /*******************/

        public CResponsable()
        {

        }

        public CResponsable(int id, string nom, string prénom, string téléphone,
        DateTime dateNaiss, string mail, string spécialisation,string fonction,double salaireResp)
        :base(id,nom,prénom, téléphone,dateNaiss,mail,spécialisation)
        {

            this.fonction = fonction;
            this.salaireResp = salaireResp;
            
        }

        /*******************/
        /*    Méthodes     */
        /*******************/

        public void CreerReponsable()
        {
            
        }

        public void DemandeAjoutMateriel(string nom)
        {
           
        }


        public void DemandeModificationMateriel()
        {

        }

        public void DemandeSuppressionMateriel()
        {

        }

        public void DemandeAjoutParticipant()
        {

        }


        public void DemandeModificationParticipant()
        {

        }

        public void DemandeSuppressionParticipant()
        {

        }

        public void DemandeAjoutRevenu()
        {

        }


        public void DemandeModificationRevenu()
        {

        }

        public void DemandeSuppressionRevenu()
        {

        }

        public void DemandeAugmentBudget()
        {

        }

        public void ConsultListPersonnel()
        {

        }

        public void ConsultListMateriel()
        {

        }
        public void ConsultListParticipant()
        {

        }


    }
}