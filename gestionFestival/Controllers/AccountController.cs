using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestionFestival.Models;

namespace gestionFestival.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            CPersonnel user=(CPersonnel)Session["user"];
            return View(user);
        }

        public ActionResult ModifCompteForm()
        { 

            CPersonnel user = (CPersonnel)Session["user"];
            return View("ModifCompteForm", user);
        }


        public ActionResult SupprimerCompte()
        {
            CPersonnel user = (CPersonnel)Session["user"];
            user.SupprimerPersonnel();
            return Redirect("../Login/Index");

        }

        
        public ActionResult ModifInfoCompte(string email , string telephone,DateTime dateNaiss,string spec)
        {
            ((CPersonnel)Session["user"]).Mail=email;
            ((CPersonnel)Session["user"]).Telephone=telephone;
            ((CPersonnel)Session["user"]).DateNaiss = dateNaiss;
            ((CPersonnel)Session["user"]).Specialisation = spec;
            ((CPersonnel)Session["user"]).ModifierPersonnel();

            return View("Index", ((CPersonnel)Session["user"]));
        }
    }
}