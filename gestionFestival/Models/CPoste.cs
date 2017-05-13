using System;
using gestionFestival.DAL;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace gestionFestival.Models
{
    public class CPoste :IPrevision
    {
        /*******************/
        /*    Attribut     */
        /*******************/

        private int id;
        private string  nomPoste;
        private string  description;
        private double  budgetDepart;
        private double  budgetActuel;
        private CResponsable responsable;
        private CDepense depense;
        private CRecette recette;
        private DataContextDataContext db;


        /*******************/
        /*   Proprietes    */
        /*******************/

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

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
            get { return budgetDepart; }
            set { budgetDepart = value; }
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
            get { return depense; }
            set { depense = value; }
        }
        public CRecette Recette
        {
            get { return recette; }
            set { recette = value; }
        }



        /*******************/
        /*  Constructeur   */
        /*******************/

        public CPoste(int idPers)
        {
            db = new DAL.DataContextDataContext();
           var result= db.GetRespAndPoste(idPers).FirstOrDefault();
            this.id = result.idPoste;
            this.nomPoste = result.nomPoste;

        }

        public CPoste(string nomPoste,string description,double budget)
        {
            this.nomPoste = nomPoste;
            this.description = description;
            budgetDepart = budget;
            BudgetActuel = budget;
            // Ajouter le responsable
            
        }

        /*******************/
        /*    Methodes     */
        /*******************/

        public void CreerPoste(string nomPoste, string descriptionPoste)
        {
            db = new DataContextDataContext();
            db.AjouterPoste(nomPoste, descriptionPoste);
        }

        public void AfficherLesPostes()
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