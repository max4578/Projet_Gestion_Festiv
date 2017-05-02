using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestionFestival.Models
{
    public class CPoste:IPrévision
    {
        /*******************/
        /*    Attribut     */
        /*******************/
        private string nomPoste;
        private string description;
        private double budgetDépart;
        private double budgetActuel;
        private CResponsable responsable;
        private CDepense dépense;
        private CRecette recette;


        /*******************/
        /*   Propriétés    */
        /*******************/

        public string NomPoste
        {
            get { return nomPoste; }
            set { nomPoste = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public double BudgetDepart
        {
            get { return budgetDépart; }
            set { budgetDépart = value; }
        }

        public double BudgetActuel
        {
            get { return budgetActuel; }
            set { budgetActuel = value; }
        }

        public CResponsable Responsable
        {
            get { return responsable; }
            set { responsable = value; }
        }

        public CDepense Depense
        {
            get { return dépense; }
            set { dépense = value; }
        }
        public CRecette Recette
        {
            get { return recette; }
            set { recette = value; }
        }


        /*******************/
        /*  Constructeur   */
        /*******************/

        public CPoste()
        {

        }

        /*******************/
        /*    Méthodes     */
        /*******************/

        public void CreerPoste()
        {

        }

        public void ModifInfoPoste()
        {

        }


        public void SupprimerPoste()
        {

        }

        public void AssignerReponsable(CPoste p)
        {

        }

        public void ModifierBudget()
        {

        }

        public void Print()
        {
            throw new NotImplementedException();
        }

        public void ConsultGraph()
        {
            throw new NotImplementedException();
        }

        public void ConsultNum()
        {
            throw new NotImplementedException();
        }
    }
}