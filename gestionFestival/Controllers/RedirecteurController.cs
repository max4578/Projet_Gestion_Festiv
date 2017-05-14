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
            
            object user = p.Connexion(email, pass);
            string type = user.GetType().ToString();
            
            Session["user"] = user;
            if (type == "gestionFestival.Models.CAdministrateur")
            {
                return Redirect("GestionPoste");
            }

            //else if (type == "gestionFestival.Models.CComptable")
            //{
            //    // Layout = "~/Views/Shared/headerComptable.cshtml";
            //}

            else
            if (type == "gestionFestival.Models.CResponsable")
            {
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