using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba3.BL
{
    public class Contexto: DbContext
    {
        public Contexto(): base(@"Data Source=(LocalDB)\MSSQLLocalDB;attachDBFilename=" + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\prueba3DB.mdf")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new DatosIniciales());
        }


        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }

    }
}
