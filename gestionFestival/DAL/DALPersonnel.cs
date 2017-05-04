using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestionFestival.Models;

namespace gestionFestival.DAL
{
    public class DALPersonnel:DataContextDataContext
    {
        public object DB_Connexion(string email, string pass)
        {
            VérificationLoginResult querry = VérificationLogin(email, pass).FirstOrDefault();

            if (querry != null)
            {
                return FindStatut(querry.idPers, querry);
            }
            else
                return null;
        }

        private object FindStatut(int id, VérificationLoginResult q)
        {

           
            var querry1 = isAdmin(id).FirstOrDefault();
            var querry2 = isCompt(id).FirstOrDefault();
            var querry3 = isResponsable(id).FirstOrDefault();
            var querry4 = isParticipant(id).FirstOrDefault();


            if (querry1 != null)
                return new CAdministrateur(q.nomPers, q.prenomPers, q.telephone, q.dateNaiss, q.email, q.specialisation, querry1.nomFest, querry1.dateFest);
            else if (querry2 != null)
                return new CComptable(q.nomPers, q.prenomPers, q.telephone, q.dateNaiss, q.email, q.specialisation, Convert.ToDouble(querry2.salaire), Convert.ToDouble(querry2.budgetDisp));
            else if (querry3 != null)
                return new CResponsable(q.nomPers, q.prenomPers, q.telephone, q.dateNaiss, q.email, q.specialisation, querry3.fonction, Convert.ToDouble(querry3.salaireResp));
            else if (querry4 != null)
                return new CParticipant(q.nomPers, q.prenomPers, q.telephone, q.dateNaiss, q.email, q.specialisation, Convert.ToDouble(querry4.salaire), querry4.heureTravail);
            else
                return new CPersonnel(q.nomPers, q.prenomPers, q.telephone, q.dateNaiss, q.email, q.specialisation);


        }

        public bool AjoutPersonnel(string nom, string prenom, DateTime dateNaiss,string  mail, string telephone, string specialisation, string pass)
        {
            if (VérificatioCompteExistant(mail).First().Column1 == 0)
            { 
                 AjouterPersonnel(nom, prenom, dateNaiss, mail, telephone, specialisation, pass);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}