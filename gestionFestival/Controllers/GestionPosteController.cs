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
        // GET: GestionPoste
        public ActionResult Index()
        {
            listPoste listePoste = new listPoste();
            Session["listePosteNonAssigne"] = listePoste.GetListPosteNonAssigne();
            Session["listePoste"] = listePoste.GetListPosteAssigne();
            ViewBag.listeDesPostes = Session["listePoste"];
            ViewBag.listeDesPostesNonAssigne = Session["listePosteNonAssigne"];
            return View();
        }

        [HttpPost]
        public ActionResult Index(CPoste poste)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.listeDesPostes = Session["listePoste"];
                return View();
            }
            else
            {
                CPoste nouveauPoste = new CPoste(poste.NomPoste, poste.Description, 0);
                nouveauPoste.CreerPoste(poste.NomPoste, poste.Description);
                listPoste listePoste = new listPoste();
                Session["listePoste"] = listePoste.GetListPosteNonAssigne();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Poste(int id)
        {
            List<CPoste> list = (List<CPoste>)Session["listePoste"];
            CPoste poste = list.ElementAt(id);
            ViewBag.index = id;
            return View("ModifierPoste",poste);
        }

        [HttpPost]
        public ActionResult ChangementPoste(CPoste poste, int index)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.index = index;
                return View("ModifierPoste");
            }
            else
            {
                CPoste nouveauPoste = ((List<CPoste>)Session["listePoste"]).ElementAt(index);
                nouveauPoste.ModifierInfoPoste(poste.NomPoste, poste.Description);
                ViewBag.listeDesPostes = Session["listePoste"];
                return RedirectToAction("Index");
            }
        }
        public ActionResult SuppressionPoste(int id)
        {
            List<CPoste> list = (List<CPoste>)Session["listePoste"];
            CPoste poste = list.ElementAt(id);
            poste.SupprimerUnPoste();
            list.RemoveAt(id);
            ViewBag.listeDesPostes = list;
            ViewBag.message = "Le poste " + poste.NomPoste + " a été supprimé";
            return View("Index");
        }

        public ActionResult SuppressionPosteAssigne(int id)
        {
            List<VM_PosteAssigne> list = (List<VM_PosteAssigne>)Session["listePoste"];
            CPoste poste = list.ElementAt(id).poste;
            poste.SupprimerUnPoste();
            list.RemoveAt(id);
            ViewBag.listeDesPostes = list;
            ViewBag.message = "Le poste " + poste.NomPoste + " a été supprimé";
            return View("Index");
        }
        public ActionResult Responsable(int id)
        {
            List<CPoste> list = (List<CPoste>)Session["listePoste"];
            CPoste poste = list.ElementAt(id);
            listPersonnel listP = new listPersonnel();
            ViewBag.listePersonnel = new SelectList(listP.GetListPersonnel(), "Id", "Nom","Prenom");
            ViewBag.index = id;
            return View("AssignerPoste", poste);
        }
        [HttpPost]
        public ActionResult AssignerPoste(string selectResponsable,string fonction,int salaire, int index)
        {
            int key;
            List<CPoste> list = (List<CPoste>)Session["listePoste"];
            CPoste poste = list.ElementAt(index);
            bool result = int.TryParse(selectResponsable, out key);
            if (result)
            {
                CResponsable responsable = new CResponsable(key, fonction, salaire);
                responsable.CreerResponsable(poste.Id);
            }
            ViewBag.listeDesPostes = list;
            return View("Index");
        }

    }
}