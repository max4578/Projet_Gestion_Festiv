using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestionFestival.Models;

namespace gestionFestival.Controllers
{
    public class BudgetFestivalController : Controller
    {
        public ActionResult Index()
        {
            CFestival festival = new CFestival();
            festival.InfoFestival();
            return View(festival);
        }
        [HttpPost]
        public ActionResult EnvoyerBudget(string budget)
        {
            double montant;
            bool result = double.TryParse(budget, out montant);
            if (result && montant > 0)
            {
                ViewBag.message = "Budget confirmé";
                CAdministrateur admin = new CAdministrateur();
                admin.DefinirBudgetFestival(montant);
            }
            else
            {
                ViewBag.message = "Veuillez entrer une valeur correcte";
            }
            CFestival festival = new CFestival();
            festival.InfoFestival();
            return View("Index",festival);
        }
    }
}