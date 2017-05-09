using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestionFestival.DAL;

namespace gestionFestival.Models
{
    public class listMateriel:DataContextDataContext
    {

        /*******************/
        /*    Attribut     */
        /*******************/
        private List<CMateriel> listMat;
        


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


        /*******************/
        /*    Méthodes     */
        /*******************/

        public List<CMateriel> GetList(int id)
        {
           /* foreach(var elem in GetAllMateriel(id))
            {
                    listMat.Add(new CMateriel(elem.idMateriel,elem.nom,Convert.ToDouble(elem.prix),elem.quantité));
            }*/

            return listMat;
        }
    }
}