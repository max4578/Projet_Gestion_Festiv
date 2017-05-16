using System;
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


        /*******************/
        /*   Propriétés    */
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

        public CResponsable()
        {

        }

        public CResponsable(int id, string nom, string prénom, string téléphone,
        DateTime dateNaiss, string mail, string spécialisation,int ht,double salaireResp)
        :base(id,nom,prénom, téléphone,dateNaiss,mail,spécialisation)
        {

            this.heureTravail = ht ;
            this.salaireResp = salaireResp;
            
        }

        /*******************/
        /*    Méthodes     */
        /*******************/

        public void CreerReponsable()
        {
            
        }

        public void DemandeAjoutMateriel(CMateriel mat,int idPoste)
        {
            mat.CreerMateriel(idPoste);
        }


        public void DemandeModificationMateriel(CMateriel mat,string nom,double prix, int qtt)
        {
            mat.Nom = nom;
            mat.Prix = prix;
            mat.Quantité = qtt;
            mat.ModifMateriel();
        }

        public void DemandeSuppressionMateriel(CMateriel mat)
        {
            mat.SupprimerMateriel();
        }

        public void DemandeAjoutParticipant(CParticipant part,int idPoste)
        {
            part.CreerParticipant(idPoste);
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
            return new listPersonnel().GetList();

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
    }
}