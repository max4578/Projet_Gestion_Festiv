using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestionFestival.Models;
using gestionFestival.ViewModel;

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
            ViewBag.listeDemande=listDemande.GetList();
            return View();
        }
        public ActionResult DemandeDeBudget(int idDemande, double budget, int idPers)
        {
            CComptable comptable = new CComptable();
            if(idPers != 0)
            {
                comptable.AccepterDemandeBudget(idPers, budget, idDemande);
                ViewBag.message = "La demande a été acceptée";
            }
            else
            {
                comptable.RefuserDemandeBudget(idDemande);
                ViewBag.message = "La demande a été refusée";
            }
            listDemande listDemande = new listDemande();
            ViewBag.listeDemande = listDemande.GetList();
            return View("GestionDemande");
        }

        // Assignation des budget
        public ActionResult GestionBudget()
        {
            CComptable comptable = new CComptable();
            ViewBag.listeDesPostes = comptable.ConsulterListePoste();
            return View();
        }
        public ActionResult GestionCompte(int id, string nom, double budgetActuel, double budgetDepart, string description, CDepense dep, CRecette rec)
        {
            CPoste poste = new CPoste(id,nom,budgetActuel,budgetDepart,description,dep,rec);
            ViewBag.id = poste.Id;
            return View(poste);
        }
        [HttpPost]
        public ActionResult UpdateBudget(int id,string budget)
        {
            double montant;
            CComptable comptable = new CComptable();
            bool result = double.TryParse(budget, out montant);
            if (result && montant > 0)
            {
                ViewBag.message = "Budget confirmé";
                comptable.AllouerBudget(id, montant);
            }
            else
            {
                ViewBag.message = "Veuillez entrer une valeur correcte";
            }
            ViewBag.listeDesPostes = comptable.ConsulterListePoste();
            return View("GestionBudget");
        }
    }
}