using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocacaoVeiculos.Models
{
    public class Tipo
    {
        public int TipoID { get; set; }

        [Required, StringLength(30)]
        public string tipo { get; set; }

    }
}