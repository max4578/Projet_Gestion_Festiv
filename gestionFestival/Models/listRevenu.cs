using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestionFestival.DAL;

namespace gestionFestival.Models
{
    public class listRevenu
    {

        /*******************/
        /*    Attribut     */
        /*******************/
        private List<CRevenu> listRev;
        private DataContextDataContext db = new DataContextDataContext();

        /*******************/
        /*   Propriétés    */
        /*******************/

        public List<CRevenu> ListeRev
        {
            get { return listRev; }
            set { listRev = value; }
        }


        /*******************/
        /*  Constructeur   */
        /*******************/

        public listRevenu()
        {
            listRev = new List<CRevenu>();
        }


        /*******************/
        /*    Méthodes     */
        /*******************/

        public List<CRevenu> GetList(int id)
        {
            foreach (var elem in db.GetAllRevenu(id))
            {
                listRev.Add(new CRevenu(elem.idPersonnel,elem.description,(double)elem.montant));
            }

            return listRev;
        }

      
    }
}