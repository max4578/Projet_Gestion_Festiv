﻿using System;
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
                CResponsable resp = new CResponsable(item.idPersonnel1,item.nomPersonnel,item.prenomPersonnel, item.telephone, item.dateNaissance, item.email, item.specialisation, item.libelRole, item.nbrHeure, (double)item.salaireHoraire);
                listPosteAssigne.Add(new CPoste((int)item.idPoste,item.nomPoste,(double)item.budgetDepart,(double)item.budgetActuel,item.description, resp));
               }

            return listPosteAssigne;
        }
    }
}