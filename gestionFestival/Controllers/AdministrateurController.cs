using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestionFestival.ViewModel;
using gestionFestival.Models;

namespace gestionFestival.Controllers
{
    public class AdministrateurController : Controller
    {
        // GET: Administrateur
        public ActionResult Index()
        {
            CAdministrateur admin = new CAdministrateur();
            CFestival festival = new CFestival();
            listPoste listePoste = new listPoste();
            //CDepense depense = new CDepense();
            VM_Administrateur vm = new VM_Administrateur();
            vm.Nomfestival = festival.NomFestival;
            vm.DebutFestival = festival.DateDebutFestival;
            vm.FinFestival = festival.DateFinFestival;
            vm.ListePoste = listePoste.ListePoste;
            vm.BudgetTotal = festival.BudgetFestival;
            //vm.Depense = depense.Total;

            return View("Index",vm);
        }
    }
}