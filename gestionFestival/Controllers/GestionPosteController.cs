using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestionFestival.Models;

namespace gestionFestival.Controllers
{
    public class GestionPosteController : Controller
    {
        // GET: GestionPoste
        public ActionResult Index()
        {
            listPoste listePoste = new listPoste();
            Session["listePoste"] = listePoste.GetList();
            ViewBag.listeDesPostes = Session["listePoste"];
            return View();
        }

        [HttpPost]
        public ActionResult CreerPoste(string poste, string description)
        {
            if (poste != "")
            {
                CPoste nouveauPoste = new CPoste(poste, description, 0);
                nouveauPoste.CreerPoste(poste, description);
                ViewBag.message = "Le poste " + poste + " a bien été ajouté";
            }
            else
            {
                ViewBag.message = "Veuillez entrer un nom pour le poste";
            }
            return Redirect("Index");
        }

        public ActionResult Poste(int id)
        {
            List<CPoste> list = (List<CPoste>)Session["listePoste"];
            CPoste poste = list.ElementAt(id);
            ViewBag.index = id;

            return View("ModifierPoste",poste);
        }

        [HttpPost]
        public ActionResult ChangementPoste(string nomPoste, string description, int index)
        {
            if (nomPoste != "")
            {
                CPoste nouveauPoste = ((List<CPoste>)Session["listePoste"]).ElementAt(index);
                nouveauPoste.ModifierInfoPoste(nomPoste, description);
                return Redirect("Index");
            }
            else
            {
                ViewBag.message = "Veuillez entrer un nom pour le poste";
                return View();
            }
        }

        public ActionResult SuppressionPoste(int id)
        {
            List<CPoste> list = (List<CPoste>)Session["listePoste"];
            CPoste poste = list.ElementAt(id);
            poste.SupprimerUnPoste();
            list.RemoveAt(id);
            ViewBag.listeDesPostes = list;
            return View("Index");
        }


    }
}