using System;
using gestionFestival.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            db = new DataContextDataContext();
            listP = new List<CPoste>();
            var chargerListePoste = db.AfficherPoste();
            foreach (var poste in chargerListePoste)
                listP.Add(new CPoste(poste.idPoste,poste.nomPoste, poste.description, 0));
        }


        /*******************/
        /*    Méthodes     */
        /*******************/

        public List<CPoste> GetList()
        {
            return listP;
        }
    }
}