using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestionFestival.Models
{
    public class CDepense
    {

        /*******************/
        /*    Attribut     */
        /*******************/

        private double totalDepense;
        private listMateriel listMat;
        private listParticipant listPart;


        /*******************/
        /*   Propriétés    */
        /*******************/

        public double Total
        {
            get { return totalDepense; }
            set { totalDepense = value; }
        }

        public listMateriel ListMat
        {
            get { return listMat; }
            set { listMat = value; }
        }

        public listParticipant ListPart
        {
            get { return listPart; }
            set { listPart = value; }
        }


        /*******************/
        /*  Constructeur   */
        /*******************/

        public CDepense(int id)
        {
            listMat = new listMateriel(id);
            listPart = new listParticipant(id);
        }

        /*******************/
        /*    Méthodes     */
        /*******************/

        public void CalculerDepense()
        {

        }
    }
}