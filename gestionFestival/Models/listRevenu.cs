using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestionFestival.Models
{
    public class listRevenu
    {

        /*******************/
        /*    Attribut     */
        /*******************/
        private List<CRevenu> listRev;


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

        }


        /*******************/
        /*    Méthodes     */
        /*******************/

    }
}