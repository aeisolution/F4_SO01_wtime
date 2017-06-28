using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace wtime.Models
{
 

    public class Richiesta
    {
        [Key]
        public int IdRichiesta { get; set; }
        [Required]
        public int IdOperatore { get; set; }
        [ForeignKey("IdOperatore")]
        public virtual Operatore Operatore { get; set; }

        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }
        public bool Giornaliera { get; set; }

        public int? OraInizio { get; set; }
        public int? MinutiInizio { get; set; }
        public int? OraFine { get; set; }
        public int? MinutiFine { get; set; }

        public int IdTipoStatus { get; set; }
        public virtual TipoStatus Status { get; set; }
        public DateTime DataStatus { get; set; }

        public string Note { get; set; }
        public string UsernameValidatore { get; set; }

        public int IdTipoRichiesta { get; set; }
        public virtual TipoRichiesta TipoRichiesta { get; set; }
    }
}