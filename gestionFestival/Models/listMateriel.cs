using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestionFestival.Models
{
    public class listMateriel
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

        }


        /*******************/
        /*    Méthodes     */
        /*******************/


    }
}