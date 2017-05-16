using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestionFestival.Models
{
    public class CRecette
    {


        /*******************/
        /*    Attribut     */
        /*******************/

        private double totalRecette;
        private listRevenu listRev;
        


        /*******************/
        /*   Propriétés    */
        /*******************/

        public double Total
        {
            get { return totalRecette; }
            set { totalRecette = value; }
        }

        public listRevenu ListRev
        {
            get { return listRev; }
            set { listRev = value; }
        }


        /*******************/
        /*  Constructeur   */
        /*******************/

        public CRecette(int idPoste)
        {
            listRev = new listRevenu(idPoste);
            
            
        }

        /*******************/
        /*    Méthodes     */
        /*******************/

        public void CalculerRecette()
        {
            foreach (CRevenu rev in listRev.ListeRev)
            {
                totalRecette += rev.Montant;
            }

          
        }
    }
}