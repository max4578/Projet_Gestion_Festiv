using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestionFestival.DAL;

namespace gestionFestival.Models
{
    public class listDemande
    {


        /*******************/
        /*    Attribut     */
        /*******************/
        private List<CDemande> listDem;
        private DataContextDataContext db = new DataContextDataContext();


        /*******************/
        /*   Propriétés    */
        /*******************/

        public List<CDemande> ListeDem
        {
            get { return listDem; }
            set { listDem = value; }
        }


        /*******************/
        /*  Constructeur   */
        /*******************/

        public listDemande()
        {
            listDem = new List<CDemande>();
        }

        public listDemande(int idResp)
        {
            listDem = new List<CDemande>();
            listDem = GetList(idResp);
        }

        /*******************/
        /*    Méthodes     */
        /*******************/

        public List<CDemande> GetList(int idResp)
        {
            foreach (var elem in db.GetAllDemandeResp(idResp))
            {
                listDem.Add(new CDemande((double)elem.montant,elem.motif,elem.dateDemande));
            }

            return listDem;
        }
    }
}