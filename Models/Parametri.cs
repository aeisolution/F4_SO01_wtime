using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace wtime.Models
{
    // File Parametri.cs per tutte le strutture 
    // dati parametriche

    public class TipoRichiesta
    {
        [Key]
        public int IdTipoRichiesta { get; set; }
        [Required]
        public string Nome { get; set; }
        public bool Giornaliero { get; set; }
    }

    public class TipoStatus
    {
        [Key]
        public int IdTipoStatus { get; set; }
        [Required]
        public string Nome { get; set; }
    }
}