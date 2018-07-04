using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LocacaoVeiculos.Models.DAL
{
    public class MeuContexto : DbContext
    {
        public MeuContexto() : base("strConn")
        {
            //DropCreateDatabaseAlways 

            //DropCreateDatabaseIfModelChanges

            //Migrations (pra produção)


            Database.SetInitializer<MeuContexto>(new DropCreateDatabaseIfModelChanges<MeuContexto>());
        }

   //     public virtual DbSet<Event> Events { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Cor> Cores { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Combustivel> Combustiveis { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }
        public DbSet<Tipo> Tipos { get; set; }

    }
} 