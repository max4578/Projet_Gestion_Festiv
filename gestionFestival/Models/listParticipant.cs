using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestionFestival.Models
{
    public class listParticipant
    {

        /*******************/
        /*    Attribut     */
        /*******************/
        private List<CParticipant> listPart;


        /*******************/
        /*   Propriétés    */
        /*******************/

        public List<CParticipant> ListePart
        {
            get { return listPart; }
            set { listPart = value; }
        }


        /*******************/
        /*  Constructeur   */
        /*******************/

        public listParticipant()
        {

        }


        /*******************/
        /*    Méthodes     */
        /*******************/


    }
}