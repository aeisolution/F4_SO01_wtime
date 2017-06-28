using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace wtime.Models
{
    public class ProfiloOrario
    {
        [Key]
        public int IdProfiloOrario { get; set; }
        public string Nome { get; set; }
        public int NumeroOre { get; set; }

        public virtual ICollection<FasciaOraria> FasceOrarie { get; set; }
    }

    public class FasciaOraria
    {
        [Key]
        public string Codice { get; set; }

        public int IdProfiloOrario { get; set; }
        public virtual ProfiloOrario ProfiloOrario { get; set; }

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