using System;
using gestionFestival.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestionFestival.ViewModel
{
    public class VM_PosteAssigne
    {
        public CPoste poste { get; set; }
        public CResponsable responsable { get; set; }

    }
}