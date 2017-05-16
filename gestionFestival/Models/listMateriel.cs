using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestionFestival.DAL;

namespace gestionFestival.Models
{
    public class listMateriel
    {

        /*******************/
        /*    Attribut     */
        /*******************/
        private List<CMateriel> listMat;
        private DataContextDataContext db = new DataContextDataContext();


        /*******************/
        /*   Propriétés    */
        /*******************/

        public List<CMateriel> ListeMat
        {
            get { return listMat; }
            set { listMat = value; }
        }


        /*******************/
        /*  Constructeur   */
        /*******************/

        public listMateriel()
        {
            listMat = new List<CMateriel>();
        }

        public listMateriel(int idPoste)
        {
            listMat = new List<CMateriel>();
            listMat = GetList(idPoste);
        }

        /*******************/
        /*    Méthodes     */
        /*******************/

        public List<CMateriel> GetList(int idPoste)
        {
            foreach (var elem in db.GetAllMateriel(idPoste))
            {
                listMat.Add(new CMateriel(elem.idMateriel, elem.nom, Convert.ToDouble(elem.prix), elem.quantité));
            }

            return listMat;
        }
    }
}