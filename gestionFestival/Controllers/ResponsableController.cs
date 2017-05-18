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
        //Cette méthode calculera les dépenses et recettes du poste 
        public CPoste CalculBudgetPoste()
        {
            CPoste poste = new CPoste(((CResponsable)Session["user"]).Id);
            double totalDepense= poste.Depense.Total-poste.Recette.Total ;
            poste.BudgetActuel = poste.BudgetDepart - totalDepense;
            poste.ModifierBudget(poste.BudgetActuel);
            return poste;
        }

        //Testera si une session existe , si aucune session n est trouvée
        //Vous etes redirigé vers le login screen
        public bool TestSession()
        {
            if (Session["user"] == null)
                return false;
            else
                return true;
        }

        //Retourne vers l' index
        //Et met le poste dans la session
        public ActionResult Index()
        {
            if (!TestSession())
                return Redirect("Login?error=Vous devez être connecté avant d acceder aux ressources");
            
           CPoste poste = CalculBudgetPoste();
            Session["poste"] = poste;
           
            return View(poste);
        }

        
        /************************/
        /*  Gestion matériel    */
        /************************/

        //Page principale de la gestion de matériel
        public ActionResult GestionMateriel()
        {
            if (!TestSession())
                return Redirect("../Login?error=Vous devez être connecté avant d acceder aux ressources");

            CResponsable resp = (CResponsable)Session["user"];
            CPoste post = (CPoste)Session["poste"];   
            if (Session["listMateriel"]==null) {
                List<CMateriel> list = resp.ConsultListMateriel(post.Id);
                Session["listMateriel"] = list;
                return View("GestionMateriel");
            }
            else
            {
                return View("GestionMateriel");
            }

        }


        public ActionResult SuppressionMateriel(int id)
        {
            CResponsable resp=(CResponsable)Session["user"];
            CMateriel mat = ((List<CMateriel>)Session["listMateriel"]).ElementAt(id);         
            resp.DemandeSuppressionMateriel(mat);
            ((List<CMateriel>)Session["listMateriel"]).RemoveAt(id); 
            return View("GestionMateriel");
        }

        

        public ActionResult AjouterMateriel(string nom, double prix, int qtt)
        {
            CResponsable resp = (CResponsable)Session["user"];
            CMateriel mat = new CMateriel(nom,prix,qtt);
            if (resp.DemandeAjoutMateriel(mat, ((CPoste)Session["poste"]).Id))
            {
                Session["listMateriel"] = null;
                return Redirect("GestionMateriel");
            }
            else
            {
                
            return Redirect("GestionMateriel?error=Erreur: pas assez de fond");
            }
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
            CPoste poste = CalculBudgetPoste();
            
            
            CMateriel mat = list.ElementAt(index);
            if (resp.DemandeModificationMateriel(mat, nom, prix, qtt, poste.Id))
            {
                return Redirect("GestionMateriel");
            }
            else
            {
                Session["listMateriel"] = null;
                return Redirect("GestionMateriel?error=Erreur: pas assez de fond");
            }
        }




        /************************/
        /*  Gestion participant */
        /************************/
        public ActionResult GestionParticipant()
        {
            if (!TestSession())
                return Redirect("../Login?error=Vous devez être connecté avant d acceder aux ressources");

            CResponsable resp = (CResponsable)Session["user"];
            CPoste post = (CPoste)Session["poste"];

            Session["listPersonnel"] = resp.ConsultListPersonnel();
            
            //Rajouter exception ici
            if (Session["listParticipant"] == null)
            {           
                Session["listParticipant"] = resp.ConsultListParticipant(post.Id) ;  
                return View("GestionParticipant");
            }
            else
            {
                return View("GestionParticipant");

            }

        }

        public ActionResult SuppressionParticipant(int id)
        {
            CResponsable resp = (CResponsable)Session["user"];
            CParticipant part = ((List<CParticipant>)Session["listParticipant"]).ElementAt(id);
            resp.DemandeSuppressionParticipant(part);
            ((List<CParticipant>)Session["listParticipant"]).RemoveAt(id);
            return Redirect("../GestionParticipant");
        }


        public ActionResult AjouterParticipant(double salaire, int heureTravail)
        {    
            int id =Convert.ToInt32(Request.Form["personnel"]);
            CResponsable resp = (CResponsable)Session["user"];
            CPersonnel persToAdd = ((List<CPersonnel>)Session["listPersonnel"]).ElementAt(id);
            CParticipant part = (CParticipant)persToAdd;
            part.Salaire = salaire;
            part.HeureTravail = heureTravail;
           
            if (resp.DemandeAjoutParticipant(part, ((CPoste)Session["poste"]).Id))
            {
                Session["listParticipant"] = null;
                return Redirect("GestionParticipant");
            }
            else
            {

                return Redirect("GestionParticipant?error=Erreur: pas assez de fond");
            }

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
            CResponsable resp = (CResponsable)Session["user"];
            list.ElementAt(index).Salaire = salaire;
            list.ElementAt(index).HeureTravail = heureTravail;          
            CParticipant part = list.ElementAt(index);
            if (resp.DemandeModificationParticipant(part, salaire, heureTravail, ((CPoste)Session["poste"]).Id))
            {
                return Redirect("GestionParticipant");
            }
            else
            {
                Session["listParticipant"] = null;
                return Redirect("GestionParticipant?error=Erreur: pas assez de fond");
            }
        }



        /************************/
        /*  Gestion Revenu    */
        /************************/
        public ActionResult GestionRevenu()
        {
            if (!TestSession())
                return Redirect("../Login?error=Vous devez être connecté avant d acceder aux ressources");


            CResponsable resp = (CResponsable)Session["user"];
            CPoste post = (CPoste)Session["poste"];

            //Rajouter exception ici
            if (Session["listRevenu"] == null)
            {
                List<CRevenu> list = resp.ConsultListRevenu(post.Id);
                Session["listRevenu"] = list;
                return View("GestionRevenu");
            }
            else
            {
                return View("GestionRevenu");
            }

        }

        public ActionResult SuppressionRevenu(int id)
        {
            CResponsable resp = (CResponsable)Session["user"];
            CRevenu rev = ((List<CRevenu>)Session["listRevenu"]).ElementAt(id);
            resp.DemandeSuppressionRevenu(rev);
            ((List<CRevenu>)Session["listRevenu"]).RemoveAt(id);
            return View("GestionRevenu");
        }


        public ActionResult AjouterRevenu(string description, double montant)
        {
            CResponsable resp = (CResponsable)Session["user"];
            CRevenu rev = new CRevenu(description, montant);
            resp.DemandeAjoutRevenu(rev, ((CPoste)Session["poste"]).Id);
            Session["listRevenu"] = null;
            return Redirect("GestionRevenu");
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

            return Redirect("GestionRevenu");
        }


        /************************/
        /*  Gestion Budget      */
        /************************/

        public ActionResult GestionBudget()
        {
            CResponsable resp = (CResponsable)Session["user"];
            CPoste poste = CalculBudgetPoste();
            List<CDemande> listDem= resp.ConsultListDemande();
            ViewBag.listDem = listDem;
            return View(poste);
        }


        public ActionResult DemandeForm()
        {     
            return View("DemandeForm");
        }

        public ActionResult AddDemande(string motif, double montant)
        {
            CDemande dem = new CDemande(montant, motif, DateTime.Now);
            CResponsable resp = (CResponsable)Session["user"];
            resp.DemandeAugmentBudget(dem);
            return Redirect("GestionBudget");
        }
    }
}