using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestionFestival.DAL;

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
        public DateTime DateDebutFestival
        {
            get { return dateDebutFestival; }
            set { dateDebutFestival = value; }
        }
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
        public CFestival GetFestival()
        {
            CFestival festival = new CFestival();
            db = new DataContextDataContext();
            // var charger = procédure
            // CFestival festival = new CFestival(charger.idFestival,charger.nomFestival,charger.dateDebut,charger.dateFin,(double)charger.budget);
            return festival;
        }
    }
}