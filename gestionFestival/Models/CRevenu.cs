using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestionFestival.DAL;

namespace gestionFestival.Models
{
    public class CRevenu
    {

        /*******************/
        /*    Attribut     */
        /*******************/
        private int id;
        private string description;
        private double montant;
        private DataContextDataContext db = new DataContextDataContext();

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

        public CRevenu(int id,string desc, double montant)
        {
            this.id = id;
            this.description = desc;
            this.montant = montant;
        }

        public CRevenu(string desc, double montant)
        {
            this.description = desc;
            this.montant = montant;
        }

        /*******************/
        /*    Méthodes     */
        /*******************/

        public void AjouterRevenu(int idPers,int idPoste)
        {
            db.AjouterRevenu(description,(decimal)montant,idPers,idPoste);
        }

        public void ModifierRevenu()
        {
            db.UpdateRevenu(description,(decimal)montant,id);
        }

        public void SupprimerRevenu()
        {
            db.DeleteRevenu(id);
        }

    }
}