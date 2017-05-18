using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestionFestival.DAL;
using System.ComponentModel.DataAnnotations;

namespace gestionFestival.Models
{
    public class CFestival
    {
        private int idFestival;
        private string nomFestival;
        private DateTime dateDebutFestival;
        private DateTime dateFinFestival;
        private double budgetFestival;
        DataContextDataContext db;


        /*******************/
        /*   Proprietes    */
        /*******************/

        public int IdFestival
        {
            get { return idFestival; }
            set { idFestival = value;}
        }
        public string NomFestival
        {
            get { return nomFestival; }
            set { nomFestival = value; }
        }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateDebutFestival
        {
            get { return dateDebutFestival; }
            set { dateDebutFestival = value; }
        }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateFinFestival
        {
            get { return dateFinFestival; }
            set { dateFinFestival = value; }
        }
        public double BudgetFestival
        {
            get { return budgetFestival; }
            set { budgetFestival = value; }
        }

        /*******************/
        /*   Constructeur  */
        /*******************/

        public CFestival() { }
        public CFestival(int idFestival,string nomFestival,DateTime debutFestival, DateTime finFestival, double budgetFestival)
        {
            this.idFestival = idFestival;
            this.nomFestival = nomFestival;
            dateDebutFestival = debutFestival;
            dateFinFestival = finFestival;
            this.budgetFestival = budgetFestival;
        }

        /*******************/
        /*     Méthodes    */
        /*******************/

        public void CreerUnFestival()
        {
            db = new DataContextDataContext();
            // ajout de la procédure stockée
        }
        public void InfoFestival()
        {
            db = new DataContextDataContext();
            var data=db.GetFestival().FirstOrDefault();
            idFestival = data.idFestival;
            nomFestival = data.nomFest;
            dateDebutFestival = data.dateDebut;
            dateFinFestival = data.dateFin;
            budgetFestival = (double)data.budget;
        }
    }
}