using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestionFestival.Models;

namespace gestionFestival.Controllers
{
    public class AccueilController : Controller
    {
        [HttpPost]
        public ActionResult Index(string email, string pass)
        {

            CPersonnel p = new CPersonnel();
            object user = p.Connexion(email, pass);
            ViewBag.type = user.GetType().ToString();
            return View();
            //gestionFestival.Models.CComptable
            //Ce string pourra servir a determiner le header de la page dans un script java
        }
    }
}