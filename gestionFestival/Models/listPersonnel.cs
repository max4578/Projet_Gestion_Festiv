using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestionFestival.Models
{
    public class listPersonnel
    {

        /*******************/
        /*    Attribut     */
        /*******************/
        private List<CPersonnel> listPerso;


        /*******************/
        /*   Propriétés    */
        /*******************/

        public List<CPersonnel> ListePersonnel
        {
            get { return listPerso; }
            set { listPerso = value; }
        }


        /*******************/
        /*  Constructeur   */
        /*******************/

        public listPersonnel()
        {

        }


        /*******************/
        /*    Méthodes     */
        /*******************/

      
    }
}