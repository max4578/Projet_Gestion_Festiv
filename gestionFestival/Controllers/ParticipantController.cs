using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestionFestival.Models;

namespace gestionFestival.Controllers
{
    public class ParticipantController : Controller
    {
        // GET: Participant
        public ActionResult Index()
        {
            CPoste poste = new CPoste(((CParticipant)Session["user"]).Id);
            return View(poste);
        }
    }
}