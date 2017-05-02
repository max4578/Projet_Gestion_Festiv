using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestionFestival.Models
{
    public class CRevenu
    {

        /*******************/
        /*    Attribut     */
        /*******************/
        private string description;
        private double montant;

        /*******************/
        /*   Propriétés    */
        /*******************/

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public double Montant
        {
            get { return montant; }
            set { montant = value; }
        }


        /*******************/
        /*  Constructeur   */
        /*******************/

        public CRevenu()
        {

        }

        /*******************/
        /*    Méthodes     */
        /*******************/

        public void ModifierRevenu()
        {

        }

    }
}