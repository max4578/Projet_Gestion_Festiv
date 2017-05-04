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
        

        public ActionResult Index()
        {
            return View();
        }

        // GET: Login
        [HttpPost]
        public string Connexion(string email,string pass)
        {

            CPersonnel p= new CPersonnel();
            object user = p.Connexion(email, pass);
            /*CComptable c =(CComptable)user;*/
            return user.GetType().ToString();
        }


        
        public ActionResult GetRegisterForm()
        {  
            return View("Register");
        }

        [HttpPost]
        public ActionResult Register(string nom, string prenom, string tel ,DateTime dateNaiss,string mail,string spec,string pass)
        {
            ViewBag.message="";
            CPersonnel p;
            if(nom == "" || prenom == "" || tel== ""  || mail=="" || spec == ""  || pass=="")
            {
                ViewBag.message = "Des champs sont vide";       
                return View("GetRegisterForm");
            }
            else
            {
                ViewBag.message = "Enregistrement effectué";
                p = new CPersonnel(nom, prenom, tel, dateNaiss, mail, spec);
                p.Inscription(pass);
                return View("Login");
                
            }
        }
    }
}