using System;
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

        }


        /*******************/
        /*    Méthodes     */
        /*******************/

        public void CalculTotal()
        {

        }
    }
}