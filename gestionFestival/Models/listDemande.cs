using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestionFestival.DAL;
using gestionFestival.ViewModel;

namespace gestionFestival.Models
{
    public class listDemande
    {


        /*******************/
        /*    Attribut     */
        /*******************/
        private List<CDemande> listDem;
        private DataContextDataContext db = new DataContextDataContext();


        /*******************/
        /*   Propriétés    */
        /*******************/

        public List<CDemande> ListeDem
        {
            get { return listDem; }
            set { listDem = value; }
        }


        /*******************/
        /*  Constructeur   */
        /*******************/

        public listDemande()
        {
            listDem = new List<CDemande>();
        }

        public listDemande(int idResp)
        {
            listDem = new List<CDemande>();
            listDem = GetList(idResp);
        }

        /*******************/
        /*    Méthodes     */
        /*******************/

        public List<CDemande> GetList(int idResp)
        {
            foreach (var elem in db.GetAllDemandeResp(idResp))
            {
                listDem.Add(new CDemande((double)elem.montant,elem.motif,elem.dateDemande));
            }

            return listDem;
        }

        public List<CDemande> GetList()
        {
            db = new DataContextDataContext();
            List<CDemande> listDemande = new List<CDemande>();
            var chargerListeDemande = db.GetAllDemande();
            foreach (var item in chargerListeDemande)
            {
                listDemande.Add(new CDemande((int)item.idDemande, (double)item.montant, item.motif, item.dateDemande,item.idPersonnel));
            }
            return listDemande;
        }
        public List<CPoste> GetListPosteAssigne()
        {
            db = new DataContextDataContext();
            List<CPoste> listPosteAssigne = new List<CPoste>();
            var chargerListePoste = db.AfficherPosteAssigne();
            foreach (var item in chargerListePoste)
            {
                CResponsable resp = new CResponsable(item.idPersonnel, item.nomPersonnel, item.prenomPersonnel, item.libelRole, (int)item.nbrHeure, (double)item.salaireHoraire);
                listPosteAssigne.Add(new CPoste((int)item.idPoste, item.nomPoste, (double)item.budgetDepart, (double)item.budgetActuel, item.description, resp));
            }
            return listPosteAssigne;
        }
    }
}