using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocacaoVeiculos.Models
{
    public class Usuario
    {
        public int UsuarioID { get; set; }

        [Required, StringLength(30)]
        public string Nome { get; set; }

        public string Cpf { get; set; }

    }
}