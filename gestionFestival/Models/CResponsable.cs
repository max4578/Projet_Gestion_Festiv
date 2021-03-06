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
        private int heureTravail;
        private double salaireResp;
        private DataContextDataContext db = new DataContextDataContext();

        /*******************/
        /*   Proprietes    */
        /*******************/

        public int Heure
        {
            get { return heureTravail; }
            set { heureTravail = value; }
        }
        public double Salaire
        {
            get { return salaireResp; }
            set { salaireResp = value; }
        }

        /*******************/
        /*  Constructeur   */
        /*******************/
        public CResponsable() { }
        public CResponsable(int id)
        {
            var charger = db.GetResponsable(id).FirstOrDefault();
            Id = charger.idPersonnel;
            Nom = charger.nomPersonnel;
            Role = charger.libelRole;


        }

        public CResponsable(int id,int ht, double salaireResp):base(id)
        {
            this.heureTravail = ht;
            this.Salaire = salaireResp;
        }

        public CResponsable(int id, string nom, string prenom, string libelRole, int ht, double salaireResp): base(id, nom, prenom, libelRole)
        {
            this.heureTravail = ht;
            this.salaireResp = salaireResp;

        }

        public CResponsable(int id, string nom, string prenom, string telephone,
        DateTime dateNaiss, string mail, string specialisation,string libelRole,int ht,double salaireResp)
        :base(id,nom,prenom, telephone,dateNaiss,mail,specialisation,libelRole)
        {

            this.heureTravail = ht;
            this.salaireResp = salaireResp;
            
        }

        /*******************/
        /*    Methodes     */
        /*******************/
        public bool DemandeAjoutMateriel(CMateriel mat,int idPoste)
        {
            return mat.CreerMateriel(idPoste);
        }


        public bool DemandeModificationMateriel(CMateriel mat,string nom,double prix, int qtt,int idPoste)
        {
           
            return mat.ModifMateriel(idPoste,nom,prix,qtt);
        }

        public void DemandeSuppressionMateriel(CMateriel mat)
        {
            mat.SupprimerMateriel();
        }

        public bool DemandeAjoutParticipant(CParticipant part,int idPoste)
        {
           return part.CreerParticipant(idPoste);
        }


        public bool DemandeModificationParticipant(CParticipant p,double salaire, int heureTravail,int idPoste)
        {
            p.Salaire = salaire;
            p.HeureTravail = heureTravail;
            return p.ModifParticipant(idPoste);
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

        public void DemandeAugmentBudget(CDemande dem)
        {
            dem.CreerDemande(Id);
        }

        public List<CPersonnel> ConsultListPersonnel()
        {
            return new listPersonnel().ListePersonnel;

        }

        public List<CMateriel> ConsultListMateriel(int idPost)
        {
            return new listMateriel(idPost).ListeMat;
        }
        public List<CParticipant> ConsultListParticipant(int idPost)
        {
            return new listParticipant(idPost).ListePart;

        }

        public List<CRevenu> ConsultListRevenu(int idPost)
        {
            return new listRevenu(idPost).ListeRev;
        }

        public List<CDemande> ConsultListDemande()
        {
            return new listDemande(Id).ListeDem;
        }

        public CResponsable GetResponsable(int id)
        {
            var charger = db.GetResponsable(id).FirstOrDefault();
            CResponsable responsable = new CResponsable(charger.idPersonnel, charger.nomPersonnel, charger.prenomPersonnel, charger.libelRole, 0, 0);
            return responsable;
        }
    }
}