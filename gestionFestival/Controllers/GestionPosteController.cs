using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestionFestival.Models;
using gestionFestival.ViewModel;

namespace gestionFestival.Controllers
{
    public class GestionPosteController : Controller
    {

        public CPoste CalculBudgetPoste()
        {
            CPoste poste = new CPoste(((CResponsable)Session["user"]).Id);
            poste.Depense.CalculerDepense();
            poste.Recette.CalculerRecette();
            double totalDepense = poste.Depense.Total - poste.Recette.Total;
            poste.BudgetActuel = poste.BudgetDepart - totalDepense;
            poste.ModifierBudget(poste.BudgetActuel);
            return poste;
        }

        public bool TestSession()
        {
            if (Session["user"] == null)
                return false;
            else
                return true;
        }
        
        // GET: GestionPoste
        public ActionResult Index()
        {
            listPoste listePosteAssigne = new listPoste();
            listPoste listePosteNonAssigne = new listPoste();
            CFestival festival = new CFestival();
            festival.InfoFestival();
            VM_Admin vm = new VM_Admin();
            vm.NomFestival = festival.NomFestival;
            vm.DebutFestival = festival.DateDebutFestival;
            vm.FinFestival = festival.DateFinFestival;
            vm.BudgetFestival = festival.BudgetFestival;
            ViewBag.listeDesPostes = listePosteAssigne.GetListPosteAssigne();
            ViewBag.listeDesPostesNonAssigne = listePosteNonAssigne.GetListPosteNonAssigne();
            return View(vm);
        }
        public ActionResult GestionPoste()
        {
            listPoste listePosteAssigne = new listPoste();
            listPoste listePosteNonAssigne = new listPoste();
            ViewBag.listeDesPostes = listePosteAssigne.GetListPosteAssigne();
            ViewBag.listeDesPostesNonAssigne = listePosteNonAssigne.GetListPosteNonAssigne();
            return View();
        }

        [HttpPost]
        public ActionResult GestionPoste(CPoste poste)
        {
            if (!ModelState.IsValid)
            {
                listPoste listePosteNonAssigne = new listPoste();
                listPoste listePosteAssigne = new listPoste();
                ViewBag.listeDesPostes = listePosteAssigne.GetListPosteAssigne();
                ViewBag.listeDesPostesNonAssigne = listePosteNonAssigne.GetListPosteNonAssigne();
                return View();
            }
            else
            {
                CPoste nouveauPoste = new CPoste(poste.NomPoste,poste.Description,0);
                nouveauPoste.CreerPoste(poste.NomPoste, poste.Description);
                listPoste listePosteAssigne = new listPoste();
                listPoste listePosteNonAssigne = new listPoste();
                ViewBag.listeDesPostes = listePosteAssigne.GetListPosteAssigne();
                ViewBag.listeDesPostesNonAssigne = listePosteNonAssigne.GetListPosteNonAssigne();
                return RedirectToAction("GestionPoste");
            }
        }

        public ActionResult Poste(int id)
        {
            CPoste poste = new CPoste();
            poste.GetPost(id);
            ViewBag.id = id;
            return View("ModifierPoste", poste);
        }
        public ActionResult PosteAssigne(int id)
        {
            listPoste listePosteAssigne = new listPoste();
            CPoste poste = new CPoste();
            poste.GetPostAndResponsable(id);
            ViewBag.index = id;
            return View("ModifierPoste", poste);
        }

        [HttpPost]
        public ActionResult ChangementPoste(CPoste poste, int id)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.id = id;
                return View("ModifierPoste");
            }
            else
            {
                CPoste nouveauPoste = new CPoste();
                nouveauPoste.ModifierInfoPoste(poste.Id,poste.NomPoste, poste.Description);
                listPoste listePosteNonAssigne = new listPoste();
                listPoste listePosteAssigne = new listPoste();
                ViewBag.listeDesPostes = listePosteAssigne.GetListPosteAssigne();
                ViewBag.listeDesPostesNonAssigne = listePosteNonAssigne.GetListPosteNonAssigne();
                return RedirectToAction("GestionPoste");
            }
        }
        
        public ActionResult SuppressionPoste(int id,string nom, int idPers)
        {
            CPoste poste = new CPoste();
            if(idPers == 0)
            {
                poste.SupprimerUnPoste(id);
            }
            else
            {
                poste.SupprimerUnPoste(id, idPers);
            }
            ViewBag.message = "Le poste " + nom + " a été supprimé";
            listPoste listePosteNonAssigne = new listPoste();
            listPoste listePosteAssigne = new listPoste();
            ViewBag.listeDesPostes = listePosteAssigne.GetListPosteAssigne();
            ViewBag.listeDesPostesNonAssigne = listePosteNonAssigne.GetListPosteNonAssigne();
            return View("GestionPoste");
        }

        public ActionResult Responsable(int id)
        {
            CPoste poste = new CPoste();
            poste.GetPost(id);
            listPersonnel listP = new listPersonnel();
            ViewBag.listePersonnel = new SelectList(listP.ListePersonnel, "Id", "Nom");
            ViewBag.idPoste = id;
            return View("AssignerPoste", poste);
        }
        [HttpPost]
        public ActionResult AssignerPoste(string selectResponsable, string description, string salaire, int id)
        {
            int key;
            bool result = int.TryParse(selectResponsable, out key);
            if (result)
            {
                double salaireResp;
                bool resulta = double.TryParse(salaire, out salaireResp);
                if (resulta)
                {
                    CPoste poste = new CPoste();
                    poste.AssignerUnPoste(key, id, salaireResp);
                }
                else
                {
                    ViewBag.message = "Entrez une valeur correcte pour le salaire";
                    return View(salaireResp);
                }

            }
            listPoste listePosteNonAssigne = new listPoste();
            listPoste listePosteAssigne = new listPoste();
            ViewBag.listeDesPostes = listePosteAssigne.GetListPosteAssigne();
            ViewBag.listeDesPostesNonAssigne = listePosteNonAssigne.GetListPosteNonAssigne();
            return View("GestionPoste");
        }


    }
}