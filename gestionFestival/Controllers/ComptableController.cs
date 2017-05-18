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
            CComptable comptable = new CComptable();
            ViewBag.budgetTotalDisponible= comptable.ConsultertotalDisponible();

            return View(festival);
        }

        // Gestion des recettes
        public ActionResult GestionRecette()
        {
            CComptable comptable = new CComptable();
            ViewBag.listeDesPostes = comptable.ConsulterListePoste();

            return View();
        }

        // Gestion des dépenses
        public ActionResult GestionDepense()
        {
            CComptable comptable = new CComptable();
            ViewBag.listeDesPostes = comptable.ConsulterListePoste();
            return View();
        }
        
        // Gestion des demandes
        public ActionResult GestionDemande()
        {
            listDemande listDemande = new listDemande();
            return View();
        }

        public ActionResult DemandeDeBudget(int idPers, double budget, int idDemande)
        {
            CComptable comptable = new CComptable();
            if(idDemande != 0)
            {
                comptable.AccepterDemandeBudget(idPers, budget, idDemande);
                ViewBag.message = "La demande a été acceptée";
            }
            else
            {
                comptable.AccepterDemandeBudget(idPers, budget, idDemande);
                ViewBag.message = "La demande a été refusée";
            }
            
            return View("GestionDemande");
        }
    }
}