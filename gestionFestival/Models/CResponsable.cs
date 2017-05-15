﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestionFestival.DAL;
namespace gestionFestival.Models
{
    public class CResponsable:CPersonnel
    {

        /*******************/
        /*    Attribut     */
        /*******************/
        private string fonction;
        private double salaireResp;


        /*******************/
        /*   Proprietes    */
        /*******************/

        public string Fonction
        {
            get { return fonction; }
            set { fonction = value; }
        }

        public double Salaire
        {
            get { return salaireResp; }
            set { salaireResp = value; }
        }

        /*******************/
        /*  Constructeur   */
        /*******************/

        public CResponsable()
        {

        }

        public CResponsable(int id,string fonction, double salaireResp):base(id)
        {
            this.fonction = fonction;
            this.Salaire = salaireResp;
        }

        public CResponsable(int id, string nom, string prenom, string telephone,
        DateTime dateNaiss, string mail, string specialisation,string fonction,double salaireResp)
        :base(id,nom,prenom, telephone,dateNaiss,mail,specialisation)
        {

            this.fonction = fonction;
            this.salaireResp = salaireResp;
            
        }

        /*******************/
        /*    Methodes     */
        /*******************/

        public void CreerResponsable(int idPoste)
        {
            AjouterResponsable(Id,fonction,(decimal)salaireResp,idPoste);
        }

        public void DemandeAjoutMateriel(CMateriel mat,int idPoste)
        {
            mat.CreerMateriel(Id, idPoste);
        }


        public void DemandeModificationMateriel(CMateriel mat,string nom,double prix, int qtt)
        {
            mat.Nom = nom;
            mat.Prix = prix;
            mat.Quantite = qtt;
            mat.ModifMateriel();
        }

        public void DemandeSuppressionMateriel(CMateriel mat)
        {
            mat.SupprimerMateriel();
        }

        public void DemandeAjoutParticipant(CParticipant part,int idPoste)
        {
            part.CreerParticipant(Id,idPoste);
        }


        public void DemandeModificationParticipant(CParticipant p,double salaire, int heureTravail)
        {
            p.Salaire = salaire;
            p.HeureTravail = heureTravail;
            p.ModifParticipant();
        }

        public void DemandeSuppressionParticipant(CParticipant part)
        {
            part.SupprimerParticipant();
        }

        public void DemandeAjoutRevenu(CRevenu rev,int idPoste)
        {
            rev.AjouterRevenu(Id,idPoste);
        }


        public void DemandeModificationRevenu(CRevenu rev,string description,double montant)
        {
            rev.Description = description;
            rev.Montant = montant;
            rev.ModifierRevenu();
        }

        public void DemandeSuppressionRevenu(CRevenu rev)
        {
            rev.SupprimerRevenu();
        }

        public void DemandeAugmentBudget()
        {

        }

        public List<CPersonnel> ConsultListPersonnel()
        {
            return new listPersonnel().GetList(); ;

        }

        public List<CMateriel> ConsultListMateriel()
        {
            return new listMateriel(Id).ListeMat;
        }
        public List<CParticipant> ConsultListParticipant()
        {
            return new listParticipant(Id).ListePart;

        }

        public List<CRevenu> ConsultListRevenu()
        {
            return new listRevenu().GetList(Id);
        }
    }
}