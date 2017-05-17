using System;
using gestionFestival.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestionFestival.DAL;

namespace gestionFestival.ViewModel
{
    public class VM_PosteAssigne
    {
        DataContextDataContext db;
        public CPoste Poste { get; set; }
        public CResponsable Responsable { get; set; }

   

    }
}