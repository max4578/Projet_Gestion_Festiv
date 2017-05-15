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
            Session["poste"] = VM_Resp.poste;
           
            return View(VM_Resp);
        }

        
        /************************/
        /*  Gestion matériel    */
        /************************/
        public ActionResult gestionMateriel()
        {
          
            listMateriel listM = new listMateriel(((CResponsable)Session["user"]).Id);

            
            //Rajouter exception ici
            if (Session["listMateriel"]==null) { 
                List<CMateriel> list =listM.ListeMat;
                Session["listMateriel"] = list;
                ViewBag.list = list;
                return View("gestionMateriel");
            }
            else
            {

                ViewBag.list = (List<CMateriel>)Session["listMateriel"];
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
        /*  Gestion participant    */
        /************************/
        public ActionResult gestionParticipant()
        {

            ListBox lbPers = new ListBox();
            listPersonnel lp = new listPersonnel();
            
            Session["listPersonnel"] = lp.ListePersonnel;
            listParticipant listP= new listParticipant(((CResponsable)Session["user"]).Id);
            //Rajouter exception ici
            if (Session["listParticipant"] == null)
            {
                List<CParticipant> list = listP.ListePart;
                Session["listParticipant"] = list;
                ViewBag.list = list;
                return View("gestionParticipant");
            }
            else
            {

                ViewBag.list = (List<CParticipant>)Session["listParticipant"];
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
            CResponsable resp = (CResponsable)Session["user"];
            List<CParticipant> list = (List<CParticipant>)Session["listParticipant"];

            list.ElementAt(index).Salaire = salaire;
            list.ElementAt(index).HeureTravail = heureTravail;
            
            CParticipant part = list.ElementAt(index);
            resp.DemandeModificationParticipant(part, salaire,heureTravail);

            return Redirect("gestionParticipant");
        }
    }
}