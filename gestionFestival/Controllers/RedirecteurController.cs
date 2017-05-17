using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestionFestival.Models;

namespace gestionFestival.Controllers
{
    public class RedirecteurController : Controller
    {
        [HttpPost]
        public ActionResult Index(string email, string pass)
        {

            CPersonnel p = new CPersonnel();
            
            object user=p.Connexion(email, pass);
            
            
            
            if (p.Role== "Admin")
            {
                CAdministrateur admin = (CAdministrateur)user;
                Session["user"] = admin;
                return Redirect("GestionPoste");
            }

            else if (p.Role == "Comptable")
            {

                CComptable comp = (CComptable)user;
                Session["user"] = comp;
                return Redirect("");
            }

            else
            if (p.Role == "Responsable")
            {
                CResponsable resp = (CResponsable)user;
                Session["user"] = resp;
                return Redirect("Responsable");
            }
            

            else if (p.Role == "Participant")
            {
                CParticipant part = (CParticipant)user;
                Session["user"] = part;
                return Redirect("Participant");
            }

            else if (p.Role == "Personnel")
            {
                Session["user"] = p;
                return Redirect("Personnel");
            }

            return Redirect("Login?error=Login ou mot de passe incorrect");

        }
    }
}