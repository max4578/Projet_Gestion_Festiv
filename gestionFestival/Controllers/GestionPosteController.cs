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
        public ActionResult Index(CPoste poste)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.listeDesPostes = Session["listePoste"];
                return View();
            }
            else
            {
                CPoste nouveauPoste = new CPoste(poste.NomPoste, poste.Description, 0);
                nouveauPoste.CreerPoste(poste.NomPoste, poste.Description);
                ViewBag.message = "Le poste " + poste.NomPoste + " a été ajouté";
                listPoste listePoste = new listPoste();
                Session["listePoste"] = listePoste.GetList();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Poste(int id)
        {
            List<CPoste> list = (List<CPoste>)Session["listePoste"];
            CPoste poste = list.ElementAt(id);
            ViewBag.index = id;
            return View("ModifierPoste",poste);
        }

        [HttpPost]
        public ActionResult ChangementPoste(CPoste poste, int index)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.index = index;
                return View("ModifierPoste");
            }
            else
            {
                CPoste nouveauPoste = ((List<CPoste>)Session["listePoste"]).ElementAt(index);
                nouveauPoste.ModifierInfoPoste(poste.NomPoste, poste.Description);
                ViewBag.listeDesPostes = Session["listePoste"];
                return RedirectToAction("Index"); ;
            }
        }
        public ActionResult SuppressionPoste(int id)
        {
            List<CPoste> list = (List<CPoste>)Session["listePoste"];
            CPoste poste = list.ElementAt(id);
            poste.SupprimerUnPoste();
            list.RemoveAt(id);
            ViewBag.listeDesPostes = list;
            ViewBag.message = "Le poste " + poste.NomPoste + " a été supprimé";
            return View("Index");
        }


    }
}