using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocacaoVeiculos.Models
{
    public class Locacao
    {

        public int LocacaoId { get; set; }

        public DateTime DtRetirada { get; set; }

        public DateTime DtDevolucao { get; set; }

        public int VeiculoID { get; set; }

        public virtual Veiculo _Veiculo { get; set; }

        public int ClienteID { get; set;  }

        public virtual Cliente _Cliente { get; set; }

        public int UsuarioID { get; set; }

        public virtual Usuario _Usuario { get; set; }

        public string Observacoes { get; set; }

        public string Opcionais { get; set; }

    }
}