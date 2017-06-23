using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wtime.ViewModels
{
    public class FasciaOrariaViewModel
    {
        public int IdProfiloOrario { get; set; }

        public string Codice { get; set; }

        // Blocco Orario N.1
        public int B1_Inizio_Ora { get; set; }
        public int B1_Inizio_Minuti { get; set; }
        public int B1_Fine_Ora { get; set; }
        public int B1_Fine_Minuti { get; set; }

        // Blocco Orario N.2
        public int B2_Inizio_Ora { get; set; }
        public int B2_Inizio_Minuti { get; set; }
        public int B2_Fine_Ora { get; set; }
        public int B2_Fine_Minuti { get; set; }

    }
}