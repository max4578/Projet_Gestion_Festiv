using System;
using gestionFestival.DAL;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "Le nom du poste doit être saisi")]
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
        public CPoste()
        {

        }
        public CPoste(int idPers)
        {
            
            var result= db.GetRespAndPoste(idPers).FirstOrDefault();
            this.id = result.idPoste.Value;
            this.nomPoste = result.nomPoste;
            this.budgetActuel = (double)result.budgetActuel;
            this.budgetDepart = (double)result.budgetDepart;
            depense = new CDepense(id);
            recette = new CRecette(id);
        }

        public CPoste(int id,string nomPoste,string description,double budget)
        {
            this.id = id;
            this.nomPoste = nomPoste;
            this.description = description;
            budgetDepart = budget;
            BudgetActuel = budget;
        }
        public CPoste(int idPoste, string nomPoste, double budgetDepart, double budgetActuel, string description)
        {
            this.id = idPoste;
            this.nomPoste = nomPoste;
            this.BudgetDepart = budgetDepart;
            this.budgetActuel = budgetActuel;
            this.description = description;
        }

        public CPoste(string nomPoste, string description, double budget)
        {
       
            this.nomPoste = nomPoste;
            this.description = description;
            budgetDepart = budget;
            BudgetActuel = budget;
        }

        /*******************/
        /*    Methodes     */
        /*******************/

        public void CreerPoste(string nomPoste, string descriptionPoste)
        {
            db = new DataContextDataContext();
            db.AjouterPoste(nomPoste, descriptionPoste);
        }

        public void ModifierInfoPoste(string nom, string description)
        {
            db = new DataContextDataContext();
            db.ModifierPoste(id, nom, description);
        }
        public void AllouerBudget(double budget)
        {
            BudgetDepart = budget;
            BudgetActuel = budget;
        }
        public void ModifierBudget(double budget)
        {
           //appel procédure stocké update budget
        }
        public CPoste GetPost(int id)
        {
            CPoste poste = new CPoste();
            db = new DataContextDataContext();
            return poste=(CPoste)db.GetPoste(id);
        }
        public void SupprimerUnPoste()
        {
            db = new DataContextDataContext();
            db.SupprimerPoste(id);
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