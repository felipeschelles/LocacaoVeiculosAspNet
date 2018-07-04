using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocacaoVeiculos.Models
{
    public class Marca
    {

        public int MarcaID { get; set; }

        [Required, StringLength(30)]
        public string marca { get; set; }
    }
}