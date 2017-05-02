﻿using System;
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
        private double budgetDisponible;
    


        /*******************/
        /*   Propriétés    */
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

        /*******************/
        /*    Méthodes     */
        /*******************/

        public void DemandeModifierBudget(CResponsable resp)
        {

        }

        public void AllouéBudget()
        {

        }


        public void ConsulterListePoste()
        {

        }
    }
}