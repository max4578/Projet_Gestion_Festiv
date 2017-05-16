using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using gestionFestival.Models;
using gestionFestival.ViewModel;


namespace gestionFestival.Controllers
{
    public class ResponsableController : Controller
    {

        public ActionResult Index()
        {
            VM_Responsable VM_Resp = new VM_Responsable();
            VM_Resp.depense = new CDepense(((CResponsable)Session["user"]).Id);
            VM_Resp.poste = new CPoste(((CResponsable)Session["user"]).Id);
            VM_Resp.recette = new CRecette(((CResponsable)Session["user"]).Id);
            CPoste poste = new CPoste(((CResponsable)Session["user"]).Id);
            Session["poste"] = poste;
           
            return View(poste);
        }

        
        /************************/
        /*  Gestion matériel    */
        /************************/
        public ActionResult gestionMateriel()
        {
            CResponsable resp = (CResponsable)Session["user"];
            CPoste post = (CPoste)Session["poste"];
            listMateriel listM = post.Depense.ListMat;

            
            //Rajouter exception ici
            if (Session["listMateriel"]==null) {
                List<CMateriel> list = resp.ConsultListMateriel(post.Id);
                Session["listMateriel"] = list;
                return View("gestionMateriel");
            }
            else
            {
                return View("gestionMateriel");
            }

        }

        public ActionResult SuppressionMateriel(int id)
        {
            CResponsable resp=(CResponsable)Session["user"];
            CMateriel mat = ((List<CMateriel>)Session["listMateriel"]).ElementAt(id);         
            resp.DemandeSuppressionMateriel(mat);
            ((List<CMateriel>)Session["listMateriel"]).RemoveAt(id); 
            return View("gestionMateriel");
        }


        public ActionResult AjouterMateriel(string nom, double prix, int qtt)
        {
            CResponsable resp = (CResponsable)Session["user"];
            CMateriel mat = new CMateriel(nom,prix,qtt);        
            resp.DemandeAjoutMateriel(mat,((CPoste)Session["poste"]).Id);
            Session["listMateriel"] = null;
            return Redirect("gestionMateriel");
        }

        public ActionResult ModifMaterialForm(int id)
        {
            List<CMateriel> list = (List<CMateriel>)Session["listMateriel"];
            CMateriel mat = list.ElementAt(id);
            ViewBag.index = id;

            return View("ModifMatForm",mat);
        }

        public ActionResult ModifMat(string nom, double prix , int qtt,int index)
        {
            CResponsable resp = (CResponsable)Session["user"];
            List<CMateriel> list = (List<CMateriel>)Session["listMateriel"];

            list.ElementAt(index).Nom = nom;
            list.ElementAt(index).Prix = prix;
            list.ElementAt(index).Quantité = qtt;
            list.ElementAt(index).ModifMateriel();
            CMateriel mat = list.ElementAt(index);
            resp.DemandeModificationMateriel(mat,nom,prix,qtt);

            return Redirect("gestionMateriel");
        }




        /************************/
        /*  Gestion participant */
        /************************/
        public ActionResult gestionParticipant()
        {
            CResponsable resp = (CResponsable)Session["user"];
            CPoste post = (CPoste)Session["poste"];

            Session["listPersonnel"] = resp.ConsultListPersonnel();
            
            //Rajouter exception ici
            if (Session["listParticipant"] == null)
            {           
                Session["listParticipant"] = resp.ConsultListParticipant(post.Id) ;  
                return View("gestionParticipant");
            }
            else
            {
                return View("gestionParticipant");

            }

        }

        public ActionResult SuppressionParticipant(int id)
        {
            CResponsable resp = (CResponsable)Session["user"];
            CParticipant part = ((List<CParticipant>)Session["listParticipant"]).ElementAt(id);
            resp.DemandeSuppressionParticipant(part);
            ((List<CParticipant>)Session["listParticipant"]).RemoveAt(id);
            return Redirect("../gestionParticipant");
        }


        public ActionResult AjouterParticipant(double salaire, int heureTravail)
        {    
            int id =Convert.ToInt32(Request.Form["personnel"]);
            CResponsable resp = (CResponsable)Session["user"];
            CPersonnel persToAdd = ((List<CPersonnel>)Session["listPersonnel"]).ElementAt(id);
            CParticipant part = (CParticipant)persToAdd;
            part.Salaire = salaire;
            part.HeureTravail = heureTravail;
            resp.DemandeAjoutParticipant(part, ((CPoste)Session["poste"]).Id);
            Session["listParticipant"] = null;
            return Redirect("gestionParticipant");
  
        }

        public ActionResult ModifParticipantForm(int id)
        {
            List<CParticipant> list = (List<CParticipant>)Session["listParticipant"];
            CParticipant part = list.ElementAt(id);
            ViewBag.index = id;

            return View("ModifParticipantForm", part);
        }

        public ActionResult ModifParticipant(double salaire, int heureTravail, int index)
        {
          
            List<CParticipant> list = (List<CParticipant>)Session["listParticipant"];

            list.ElementAt(index).Salaire = salaire;
            list.ElementAt(index).HeureTravail = heureTravail;
            
            CParticipant part = list.ElementAt(index);
            ((CResponsable)Session["user"]).DemandeModificationParticipant(part, salaire,heureTravail);

            return Redirect("gestionParticipant");
        }



        /************************/
        /*  Gestion Revenu    */
        /************************/
        public ActionResult gestionRevenu()
        {
            CResponsable resp = (CResponsable)Session["user"];
            CPoste post = (CPoste)Session["poste"];

            //Rajouter exception ici
            if (Session["listRevenu"] == null)
            {
                List<CRevenu> list = resp.ConsultListRevenu(post.Id);
                Session["listRevenu"] = list;
                return View("gestionRevenu");
            }
            else
            {
                return View("gestionRevenu");
            }

        }

        public ActionResult SuppressionRevenu(int id)
        {
            CResponsable resp = (CResponsable)Session["user"];
            CRevenu rev = ((List<CRevenu>)Session["listRevenu"]).ElementAt(id);
            resp.DemandeSuppressionRevenu(rev);
            ((List<CRevenu>)Session["listRevenu"]).RemoveAt(id);
            return View("gestionRevenu");
        }


        public ActionResult AjouterRevenu(string description, double montant)
        {
            CResponsable resp = (CResponsable)Session["user"];
            CRevenu rev = new CRevenu(description, montant);
            resp.DemandeAjoutRevenu(rev, ((CPoste)Session["poste"]).Id);
            Session["listRevenu"] = null;
            return Redirect("gestionRevenu");
        }

        public ActionResult ModifRevenuForm(int id)
        {
            List<CRevenu> list = (List<CRevenu>)Session["listRevenu"];
            CRevenu rev = list.ElementAt(id);
            ViewBag.index = id;

            return View("ModifRevenuForm", rev);
        }

        public ActionResult ModifRevenu(string description,double montant, int index)
        {
            CResponsable resp = (CResponsable)Session["user"];
            List<CRevenu> list = (List<CRevenu>)Session["listRevenu"];
            list.ElementAt(index).Description=description;
            list.ElementAt(index).Montant = montant;
            CRevenu rev = list.ElementAt(index);
            resp.DemandeModificationRevenu(rev, description,montant);

            return Redirect("gestionRevenu");
        }


        /************************/
        /*  Gestion Budget      */
        /************************/

        public ActionResult gestionBudget()
        {
            CResponsable resp = (CResponsable)Session["user"];
            CDepense Dep = new CDepense(resp.Id);
            CRecette Rec = new CRecette(resp.Id);
            Dep.CalculerDepense();
            Rec.CalculerRecette();
            ViewBag.Dep = Dep;
            ViewBag.Rec = Rec;

           

            return View();
        }

    }
}