using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestionFestival.Models;

namespace gestionFestival.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpPost]
        public string Index(string email,string pass)
        {
            CPersonnel p = new CPersonnel();
            if(p.Connexion(email,pass))
                return "founded";
            else
                return "not founded";
        }
    }
}