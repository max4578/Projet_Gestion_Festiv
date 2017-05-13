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

        public ActionResult Index()
        {

            CPoste poste = new CPoste(((CResponsable)Session["user"]).Id);
            Session["poste"] = poste;
            CResponsable resp = poste.Responsable;
            return View();
        }

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
            mat.SupprimerMateriel();
            return View("gestionMateriel");
        }


        public ActionResult AjouterMateriel(string nom, double prix, int qtt,int id)
        {
            CMateriel mat = new CMateriel(nom,prix,qtt);
            mat.CreerMateriel(((CResponsable)Session["user"]).Id, ((CPoste)Session["poste"]).Id);
            Session["listMateriel"] = null;
            return Redirect("gestionMateriel");
        }

        public ActionResult ModifMaterialForm(int id)
        {
            List<CMateriel> list = (List<CMateriel>)Session["listMateriel"];
            CMateriel mat = list.ElementAt(id);
            ViewBag.index = id;

            return View("ModifMatForm",mat);
        }

        public ActionResult ModifMat(string nom, double prix , int qtt,int index)
        {
            List<CMateriel> list = (List<CMateriel>)Session["listMateriel"];
            list.ElementAt(index).Nom = nom;
            list.ElementAt(index).Prix = prix;
            list.ElementAt(index).Quantité = qtt;
            list.ElementAt(index).ModifMateriel();
            return Redirect("gestionMateriel");
        }
    }
}