﻿using System;
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

        private CPoste poste;
        private double salaire = 3000;
        private int heureTravail = 3000;
        private CComptable comptable;


        /*******************/
        /*   Proprietes    */
        /*******************/

        public double Salaire
         {
            get { return salaire; }
         }


        public double HeureTravail
        {
            get { return HeureTravail; }
        }
        /*******************/
        /*  Constructeur   */
        /*******************/

        public CAdministrateur()
        {

        }

        public CAdministrateur(int id, string nom ,string prenom,string telephone,DateTime dateNaiss ,string mail,string specialisation,string libelRole):base(id,nom,prenom, telephone,dateNaiss,mail,specialisation,libelRole)
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
            comptable = new CComptable();
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