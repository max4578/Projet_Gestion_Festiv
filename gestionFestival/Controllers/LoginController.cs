﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestionFestival.Models;
using gestionFestival.DAL;
using System.Data.SqlClient;

namespace gestionFestival.Controllers
{
    public class LoginController : Controller
    { 

        public ActionResult Index()
        {
            try
            {
                DataContextDataContext db = new DataContextDataContext();
                db.GetPersonnelOnly();
            }
            catch (SqlException e)
            {
                return View("ErrorDB");
            }
            Session["user"] = null;
            Session["poste"] = null;


            return View();
        }

        public ActionResult RegisterForm()
        {
            ViewBag.Message = "";
            return View("Register");
        }


        [HttpPost]
        public ActionResult Register(string nom, string prenom, string tel ,DateTime dateNaiss,string mail,string spec,string pass)
        {
            CPersonnel p;
            p = new CPersonnel(0,nom, prenom, tel, dateNaiss, mail, spec,"");
            if (p.AjoutPersonnel(pass))
            {
                return View("Index");
            }
            else
            {
                ViewBag.Message = "Erreur: émail déja existant";
                return View("Register");
            }
        }
    }
}