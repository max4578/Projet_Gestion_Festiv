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
            // a changer var chargerListePoste = db.AfficherPosteNonAttribue();
            var chargerListePoste = db.AfficherPoste();
            foreach (var poste in chargerListePoste)
                listP.Add(new CPoste(poste.idPoste, poste.nomPoste, poste.description, 0));
            return listP;
        }

        //public List<VM_PosteAssigne> GetListPosteAssigne()
        //{
        //    //db = new DataContextDataContext();
        //    List<VM_PosteAssigne> listPosteAssigne = new List<VM_PosteAssigne>();
        //    //var chargerListePoste = db.AfficherPosteAssigne();
        //    var chargerListePoste = db.AfficherPoste();
        //    foreach (var poste in chargerListePoste)
        //        listPosteAssigne.Add(new VM_PosteAssigne {
        //            poste = new CPoste(poste.nomPoste,poste.description,0),
        //            responsable = new CResponsable(poste.idPers,poste.fonction,0)}
        //        );
        //    return listPosteAssigne;
        //}
    }
}