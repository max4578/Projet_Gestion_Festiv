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
            // A modifier pour faire le tout en appelant une méthode de la classe
            DAL.DataContextDataContext db = new DAL.DataContextDataContext();
            List<CPoste> listePoste = new List<CPoste>();
            var chargerListePoste = db.AfficherPoste();
            foreach (var poste in chargerListePoste)
                listePoste.Add(new CPoste(poste.nomPoste, poste.description, 0));
            ViewBag.listeDesPostes = listePoste;
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
        //    CPoste mat = list.ElementAt(id);
        //    list.RemoveAt(id);
        //    ViewBag.list = list;
        //    return View("Index");
        //}


    }
}