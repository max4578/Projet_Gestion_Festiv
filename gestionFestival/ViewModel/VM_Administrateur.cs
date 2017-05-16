using System;
using System.Collections.Generic;
using gestionFestival.Models;
using System.Linq;
using System.Web;

namespace gestionFestival.ViewModel
{
    public class VM_Administrateur
    {
        public List<CPoste> ListePoste { get; set; }
        public DateTime DebutFestival { get; set; }
        public DateTime FinFestival { get; set; }
        public double BudgetTotal { get; set; }
        public double BudgetRestant { get; set; }
        public CDepense Depense { get; set; }
        public string Nomfestival { get; set; }
    }
}