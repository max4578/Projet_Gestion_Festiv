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
            int i= 0;
            List<CPoste> listePoste = new List<CPoste>();
            listePoste.Add(new CPoste("Nourriture", "vendre de la bouffe", 5000.25));
            listePoste.Add(new CPoste("Boisson", "vendre des boissons", 1000));
            listePoste.Add(new CPoste("Pyrotechnique", "Faire péter des pétard", 10000));
            ViewBag.listeDesPostes = listePoste;
            return View();
        }

        [HttpPost]
        public ActionResult CreerPoste(string poste)
        {
            if(poste != "")
            {
                CPoste nouveauPoste = new CPoste(poste, "", 0);
                ViewBag.message = "Le poste "+ poste +" a bien été ajouté";
                // Ajouter le poste dans la db    
            }
            else
            {
                ViewBag.message = "Veuillez entrer un nom pour le poste";
            }
            return View("Index");
        }
    }
}