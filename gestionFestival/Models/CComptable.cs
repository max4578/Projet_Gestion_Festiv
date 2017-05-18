using System;
using gestionFestival.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestionFestival.Models
{
    public class CComptable:CPersonnel
    {

        /*******************/
        /*    Attribut     */
        /*******************/
        private double salaire;
        private listPoste listP;
        private listDemande listD;
        private double budgetDisponible;
        DataContextDataContext db;
    


        /*******************/
        /*   Proprietes    */
        /*******************/

        public double Salaire
        {
            get { return salaire; }
            set { salaire = value; }
        }

        public listPoste ListPoste
        {
            get { return listP; }
            set { listP = value; }
        }

        public double BudgetDisponible
        {
            get { return budgetDisponible; }
            set { budgetDisponible = value; }
        }

        /*******************/
        /*  Constructeur   */
        /*******************/

        public CComptable()
        {

        }

        public CComptable(int id,string nom, string prenom, string telephone,
          DateTime dateNaiss, string mail, string specialisation, string libelRole, double salaire):base(id,nom,prenom, telephone,dateNaiss,mail,specialisation,libelRole)
        {
            this.salaire = salaire;
            
            
        }

        /*******************/
        /*    Methodes     */
        /*******************/

        public void DemandeModifierBudget(double budget)
        {
            db = new DataContextDataContext();
            budgetDisponible = budget;
            db.BudgetFestival((decimal)budget);
        }

        public void AccepterDemandeBudget(int idPers,double budget,int idDemande)
        {
            db = new DataContextDataContext();
            //procédure qui ajoute le budget au budget de départ du poste
            //procédure qui efface la demande dans la table
        }
        public void RefuserDemandeBudget(int idDemande)
        {
            db = new DataContextDataContext();
            //procédure qui efface la demande dans la table
        }

        public List<CPoste> ConsulterListePoste()
        {
            listP = new listPoste();
            
            return listP.GetList();
        }

        public double ConsultertotalDisponible()
        {
            listP = new listPoste();

            return listP.GetTotalDisponible();
        }

    }
}