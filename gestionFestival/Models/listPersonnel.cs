using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestionFestival.DAL;

namespace gestionFestival.Models
{
    public class listPersonnel:DataContextDataContext
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
            listPerso = new List<CPersonnel>();
            //listPerso = GetList();
        }


        /*******************/
        /*    Méthodes     */
        /*******************/

        public List<CPersonnel> GetList()
        {
            foreach (var elem in GetPersonnelOnly())
            {
                listPerso.Add(new CParticipant(elem.idPers,elem.nomPers,elem.prenomPers,elem.telephone,elem.dateNaiss,elem.email,elem.specialisation));
            }
            return listPerso;
        }

        public List<CPersonnel> GetListPersonnel()
        {
            foreach (var elem in GetPersonnelOnly())
            {
                listPerso.Add(new CPersonnel(elem.idPers, elem.nomPers, elem.prenomPers, elem.telephone, elem.dateNaiss, elem.email, elem.specialisation));
            }
            return listPerso;
        }

    }
}