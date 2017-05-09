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
        DAL.DataContextDataContext db = new DAL.DataContextDataContext();
        public ActionResult Index()
        {
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
            if(poste != "")
            {
                CPoste nouveauPoste = new CPoste(poste, description, 0);
                // Ajouter le poste dans la db 
                db.AjouterPoste(poste, description);
                ViewBag.message = "Le poste " + poste + " a bien été ajouté";
                
            }
            else
            {
                ViewBag.message = "Veuillez entrer un nom pour le poste";
            }
            return View("Index");
        }
    }
}