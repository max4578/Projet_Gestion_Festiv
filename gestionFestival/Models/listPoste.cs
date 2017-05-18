using System;
using gestionFestival.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestionFestival.ViewModel;

namespace gestionFestival.Models
{
    public class listPoste
    {
        /*******************/
        /*    Attribut     */
        /*******************/
        private List<CPoste> listP;
        private DataContextDataContext db;

        /*******************/
        /*   Propriétés    */
        /*******************/

        public List<CPoste> ListePoste
        {
            get { return listP; }
            set { listP = value; }
        }


        /*******************/
        /*  Constructeur   */
        /*******************/

        public listPoste()
        {
            listP = new List<CPoste>();
        }


        /*******************/
        /*    Méthodes     */
        /*******************/
        public List<CPoste> GetList()
        {
            db = new DataContextDataContext();
            List<CPoste> listPoste = new List<CPoste>();
            var chargerListePoste = db.GetAllPoste();
            foreach (var poste in chargerListePoste)
            {
                listPoste.Add(new CPoste(poste.idPoste,poste.nomPoste,(double)poste.budgetActuel,(double)poste.budgetDepart,poste.description,new CDepense(poste.idPoste),new CRecette(poste.idPoste)));
            }
            return listPoste;
        }
        public List<CPoste> GetListPoste()
        {
            db = new DataContextDataContext();
            var chargerListePoste = db.AfficherPoste();
            foreach (var poste in chargerListePoste)
                listP.Add(new CPoste(poste.idPoste, poste.nomPoste, poste.description, 0));
            return listP;
        }

        public List<CPoste> GetListPosteNonAssigne()
        {
            db = new DataContextDataContext();
            var chargerListePoste = db.AfficherPosteNonAssigne();
            foreach (var poste in chargerListePoste)
                listP.Add(new CPoste(poste.idPoste, poste.nomPoste, poste.description, 0));
            return listP;
        }

        public List<CPoste> GetListPosteAssigne()
        {
            db = new DataContextDataContext();
            List<CPoste> listPosteAssigne = new List<CPoste>();
            var chargerListePoste = db.AfficherPosteAssigne();
            foreach (var item in chargerListePoste) {
                CResponsable resp = new CResponsable(item.idPersonnel,item.nomPersonnel,item.prenomPersonnel,item.libelRole, (int)item.nbrHeure, (double)item.salaireHoraire);
                listPosteAssigne.Add(new CPoste((int)item.idPoste,item.nomPoste,(double)item.budgetDepart,(double)item.budgetActuel,item.description, resp));
               }
            return listPosteAssigne;
        }

        public double GetTotalDisponible()
        {
            db = new DataContextDataContext();
            double totalDepense = 0;
            List<CPoste> listPoste = new List<CPoste>();
            var chargerListePoste = db.GetAllPoste();
            foreach (var poste in chargerListePoste)
            {
                listPoste.Add(new CPoste(poste.idPoste, poste.nomPoste, (double)poste.budgetActuel, (double)poste.budgetDepart, poste.description, new CDepense(poste.idPoste), new CRecette(poste.idPoste)));
                totalDepense += (double)poste.budgetActuel;

            }
            return totalDepense;
        }
    }
}