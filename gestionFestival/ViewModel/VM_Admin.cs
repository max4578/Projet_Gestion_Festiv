using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestionFestival.Models;

namespace gestionFestival.ViewModel
{
    public class VM_Admin
    {
        public string NomFestival { get; set; }
        public DateTime DebutFestival { get; set; }
        public DateTime FinFestival { get; set; }
        public double BudgetFestival { get; set; }
        public double BudgetFestivalDisponible { get; set; }

    }
}