using LocacaoVeiculos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace LocacaoVeiculos.Models
{
    public class Veiculo
    {

        public int VeiculoID { get; set; }


        public string Modelo { get; set; }

        public int MarcaID { get; set; }

        public virtual Marca _Marca { get; set; }

        public int CorID { get; set; }

        public virtual Cor _Cor { get; set; }

        public DateTime Ano { get; set; }

        public int CombustivelID { get; set; }

        public virtual Combustivel _Combustivel { get; set; }

        public int TipoID { get; set; }

        public virtual Tipo _Tipo { get; set; }

        public string Detalhes { get; set; }

        public string Versao { get; set; }

       
    }
}