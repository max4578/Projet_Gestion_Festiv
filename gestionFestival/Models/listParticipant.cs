using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestionFestival.DAL;

namespace gestionFestival.Models
{
    public class listParticipant:DataContextDataContext
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

        public listParticipant(int id)
        {
            listPart = new List<CParticipant>();
            listPart= GetList(id);
        }


        /*******************/
        /*    Méthodes     */
        /*******************/

        public List<CParticipant> GetList(int id)
        {
            foreach (var elem in GetAllParticipant(id))
            {
                listPart.Add(new CParticipant(elem.idPersonnel, elem.nomPersonnel, elem.prenomPersonnel, elem.telephone, elem.dateNaissance, elem.email, elem.specialisation,elem.libelRole,(double)elem.salaireHoraire,elem.nbrHeure));
            }

            return listPart;
        }

    }
}