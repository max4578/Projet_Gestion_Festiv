using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestionFestival.Models;

namespace gestionFestival.Controllers
{
    public class ComptableController : Controller
    {
        // GET: Comptable
        public ActionResult Index()
        {
            CFestival festival = new CFestival();
            festival.InfoFestival();
            return View(festival);
        }

        // Gestion des recettes
        public ActionResult GestionRecette()
        {
            listPoste listePosteAssigne = new listPoste();
            listePosteAssigne.GetListPosteAssigne();
            ViewBag.listeDesPostes = listePosteAssigne;
            return View();
        }

        // Gestion des dépenses
        public ActionResult GestionDepense()
        {

            return View();
        }
        
        // Gestion des demandes
        public ActionResult GestionDemande()
        {

            return View();
        }
    }
}