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

            //else if (type == "gestionFestival.Models.CComptable")
            //{
            //    // Layout = "~/Views/Shared/headerComptable.cshtml";Session["user"] = user;
            //}

            else
            if (p.Role == "Responsable")
            {
                CResponsable resp = (CResponsable)user;
                Session["user"] = resp;
                return Redirect("Responsable");
            }
            return Redirect("Responsable");

            //else if (type == "gestionFestival.Models.CParticipant")
            //{
            //    //Layout = "~/Views/Shared/headerParticipant.cshtml";
            //}

            //else if (type == "gestionFestival.Models.CPersonnel")
            //{
            //    //Layout = "~/Views/Shared/headerPersonnel.cshtml";
            //}
            //gestionFestival.Models.CComptable
            //Ce string pourra servir a determiner le header de la page dans un script java
        }
    }
}