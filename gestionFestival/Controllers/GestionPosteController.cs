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
            Session["listePoste"] = listePoste.AfficherListe();
            ViewBag.listeDesPostes = listePoste.AfficherListe();
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

        //public ActionResult SuppressionPoste(int id)
        //{
        //    List<CPoste> list = (List<CPoste>)Session["Poste"];
        //    CPoste poste = list.ElementAt(id);
        //    list.RemoveAt(id);
        //    ViewBag.list = list;
        //    return View("Index");
        //}


    }
}