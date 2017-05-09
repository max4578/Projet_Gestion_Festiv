using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestionFestival.Models
{
    public class CAdministrateur : CPersonnel
    {

        /*******************/
        /*    Attribut     */
        /*******************/

        private CComptable comptable;
        private double salaire = 3000;

        /*******************/
        /*   Proprietes    */
        /*******************/

        public double Salaire
         {
            get { return salaire; }
         }

        /*******************/
        /*  Constructeur   */
        /*******************/

        public CAdministrateur()
        {

        }

        public CAdministrateur( string nom ,string prenom,string telephone,DateTime dateNaiss ,string mail,string specialisation):base(nom,prenom, telephone,dateNaiss,mail,specialisation)
        {
            Nom = nom;
            Prenom = prenom;
            Telephone = telephone;
            DateNaiss = dateNaiss;
            Mail = mail;
            Specialisation = specialisation;
        }

        /*******************/
        /*    Methodes     */
        /*******************/

        public void DefinirBudgetFestival(double budget)
        {
            comptable.DemandeModifierBudget(budget);
        }
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

        

        public void AjouterResponsable()
        {

        }

        public void ChangerResponsablePoste()
        {

        }
    }
}