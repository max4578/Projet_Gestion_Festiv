using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestionFestival.Models;

namespace gestionFestival.Controllers
{
    public class ResponsableController : Controller
    {
        
        // GET: Responsable
        public ActionResult gestionMateriel()
        {

            listMateriel listM = new listMateriel();
            //Rajouter exception ici
            if (Session["listMateriel"]==null) { 
                List<CMateriel> list = listM.GetList(((CResponsable)Session["user"]).Id);
                Session["listMateriel"] = list;
                ViewBag.list = list;
                return View("gestionMateriel");
            }
            else
            {

                ViewBag.list = (List<CMateriel>)Session["listMateriel"];
                return View("gestionMateriel");

            }

        }

        public ActionResult SuppressionMateriel(int id)
        {
            List<CMateriel> list= (List<CMateriel>)Session["listMateriel"];
            CMateriel mat = list.ElementAt(id);
            list.RemoveAt(id);
            ViewBag.list = list;
          //  mat.SupprimerMateriel();
            return View("gestionMateriel");
        }


        public ActionResult AjouterMateriel(string nom, double prix, int qtt)
        {
            CMateriel mat = new CMateriel(nom,prix,qtt);
            //mat.CreerMateriel(((CResponsable)Session["user"]).Id);
            Session["listMateriel"] = null;
            return Redirect("gestionMateriel");
        }
    }
}