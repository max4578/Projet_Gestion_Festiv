using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestionFestival.Models
{
    public class CResponsable
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

        /*******************/
        /*    Méthodes     */
        /*******************/

        public void CreerReponsable()
        {

        }

        public void DemandeAjoutMateriel()
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