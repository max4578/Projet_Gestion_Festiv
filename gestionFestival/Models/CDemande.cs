using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestionFestival.DAL;


namespace gestionFestival.Models
{
    public class CDemande
    {
        /*******************/
        /*    Attribut     */
        /*******************/
        private double montant;
        private string motif;
        private DateTime dateDem;
        private DataContextDataContext db = new DataContextDataContext();



        /*******************/
        /*   Proprietes    */
        /*******************/

        public double Montant
        {
            get { return montant; }
            set { montant = value; }
        }

        public string Motif
        {
            get { return motif; }
            set { motif = value; }
        }

        public DateTime Date
        {
            get { return dateDem; }
            set { dateDem = value; }
        }

        /*******************/
        /*  Constructeur   */
        /*******************/
        public CDemande(){ }

        public CDemande(double montant , string motif, DateTime date)
        {
            this.montant = montant;
            this.motif = motif;
            this.dateDem = date;

        }

        /*******************/
        /*    Methodes     */
        /*******************/

        public void CreerDemande(int idPers)
        {
            db.AjouterDemande(motif,(decimal)montant,idPers,dateDem);
        }
        
    }
}