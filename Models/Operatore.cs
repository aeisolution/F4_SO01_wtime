using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace wtime.Models
{
    public class Operatore
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }

        public DateTime DataNascita { get; set; }

        public int IdProfiloOrario { get; set; }
        public virtual ProfiloOrario ProfiloOrario { get; set; }

    }
}