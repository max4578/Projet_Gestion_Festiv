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

        //Methode de suppresion de matériel
        public ActionResult SuppressionMateriel(int id)
        {
            CResponsable resp=(CResponsable)Session["user"];
            CMateriel mat = ((List<CMateriel>)Session["listMateriel"]).ElementAt(id);         
            resp.DemandeSuppressionMateriel(mat);
            ((List<CMateriel>)Session["listMateriel"]).RemoveAt(id); 
            return View("GestionMateriel");
        }

        
        //Méthode pour l' ajout du matériel
        public ActionResult AjouterMateriel(string nom, double prix, int qtt)
        {
            CResponsable resp = (CResponsable)Session["user"];
            CMateriel mat = new CMateriel(nom,prix,qtt);
            //Test si la demande peut être acceptée en fonction du budget
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

        //Renvoi au formulaire de modification
        public ActionResult ModifMaterialForm(int id)
        {
            List<CMateriel> list = (List<CMateriel>)Session["listMateriel"];
            CMateriel mat = list.ElementAt(id);
            ViewBag.index = id;

            return View("ModifMatForm",mat);
        }

        //Méthode qui modifiera le matériel
        public ActionResult ModifMat(string nom, double prix , int qtt,int index)
        {
            CResponsable resp = (CResponsable)Session["user"];
            List<CMateriel> list = (List<CMateriel>)Session["listMateriel"];
            CPoste poste = CalculBudgetPoste(); 
            CMateriel mat = list.ElementAt(index);
            //Test si la demande peut être acceptée en fonction du budget
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

        //Vue principale de la gestion des participant
        public ActionResult GestionParticipant()
        {
            if (!TestSession())
                return Redirect("../Login?error=Vous devez être connecté avant d acceder aux ressources");

            CResponsable resp = (CResponsable)Session["user"];
            CPoste post = (CPoste)Session["poste"];

            Session["listPersonnel"] = resp.ConsultListPersonnel();
            
            //Test, si la session de la liste est nulle , rappelle la méthode pour la consultation
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

        //Méthode de supression des participant
        public ActionResult SuppressionParticipant(int id)
        {
            CResponsable resp = (CResponsable)Session["user"];
            CParticipant part = ((List<CParticipant>)Session["listParticipant"]).ElementAt(id);
            resp.DemandeSuppressionParticipant(part);
            ((List<CParticipant>)Session["listParticipant"]).RemoveAt(id);
            return Redirect("../GestionParticipant");
        }

        //Méthode d' ajout des participants
        public ActionResult AjouterParticipant(double salaire, int heureTravail)
        {    
            int id =Convert.ToInt32(Request.Form["personnel"]);
            CResponsable resp = (CResponsable)Session["user"];
            CPersonnel persToAdd = ((List<CPersonnel>)Session["listPersonnel"]).ElementAt(id);
            CParticipant part = (CParticipant)persToAdd;
            part.Salaire = salaire;
            part.HeureTravail = heureTravail;
            //Test si le budget est suffisant
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

        //Renvoi au formulaire de modification
        public ActionResult ModifParticipantForm(int id)
        {
            List<CParticipant> list = (List<CParticipant>)Session["listParticipant"];
            CParticipant part = list.ElementAt(id);
            ViewBag.index = id;

            return View("ModifParticipantForm", part);
        }

        //Methode de modification du personnel
        public ActionResult ModifParticipant(double salaire, int heureTravail, int index)
        {
          
            List<CParticipant> list = (List<CParticipant>)Session["listParticipant"];
            CResponsable resp = (CResponsable)Session["user"];
            list.ElementAt(index).Salaire = salaire;
            list.ElementAt(index).HeureTravail = heureTravail;          
            CParticipant part = list.ElementAt(index);
            //Test si la modification ne dépasse pas le budget
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
        /*    Gestion Revenu    */
        /************************/

         //Vue principale de la gestio des revenus
        public ActionResult GestionRevenu()
        {
            if (!TestSession())
                return Redirect("../Login?error=Vous devez être connecté avant d acceder aux ressources");
            CResponsable resp = (CResponsable)Session["user"];
            CPoste post = (CPoste)Session["poste"];
            if (Session["listRevenu"] == null)
            { 
                Session["listRevenu"] = resp.ConsultListRevenu(post.Id);
                return View("GestionRevenu");
            }
            else
            {
                return View("GestionRevenu");
            }

        }

        //Méthode de suppression du revenu
        public ActionResult SuppressionRevenu(int id)
        {
            CResponsable resp = (CResponsable)Session["user"];
            CRevenu rev = ((List<CRevenu>)Session["listRevenu"]).ElementAt(id);
            resp.DemandeSuppressionRevenu(rev);
            ((List<CRevenu>)Session["listRevenu"]).RemoveAt(id);
            return View("GestionRevenu");
        }

        //Méthode d' ajout de revenu
        public ActionResult AjouterRevenu(string description, double montant)
        {
            CResponsable resp = (CResponsable)Session["user"];
            CRevenu rev = new CRevenu(description, montant);
            resp.DemandeAjoutRevenu(rev, ((CPoste)Session["poste"]).Id);
            Session["listRevenu"] = null;
            return Redirect("GestionRevenu");
        }

        //Renvoi au formulaire de modification
        public ActionResult ModifRevenuForm(int id)
        {
            List<CRevenu> list = (List<CRevenu>)Session["listRevenu"];
            CRevenu rev = list.ElementAt(id);
            ViewBag.index = id;

            return View("ModifRevenuForm", rev);
        }

        //Methode qui  modifie le revenu choisis
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

        //Retourne la vue de gestion de budget
        public ActionResult GestionBudget()
        {
            CResponsable resp = (CResponsable)Session["user"];
            CPoste poste = CalculBudgetPoste();
            List<CDemande> listDem= resp.ConsultListDemande();
            ViewBag.listDem = listDem;
            return View(poste);
        }

        //Retourne le formulaire de demande
        public ActionResult DemandeForm()
        {     
            return View("DemandeForm");
        }

        //Rajoute la demande
        public ActionResult AddDemande(string motif, double montant)
        {
            CDemande dem = new CDemande(montant, motif, DateTime.Now);
            CResponsable resp = (CResponsable)Session["user"];
            resp.DemandeAugmentBudget(dem);
            return Redirect("GestionBudget");
        }
    }
}