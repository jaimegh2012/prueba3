using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba3.BL
{
    public class DatosIniciales: CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed(Contexto contexto)
        {
            var categoria1 = new Categoria();
            categoria1.Descripcion = "Camisetas";
            contexto.Categorias.Add(categoria1);
            base.Seed(contexto);

            var categoria2 = new Categoria();
            categoria2.Descripcion = "Pantalones";
            contexto.Categorias.Add(categoria2);
            base.Seed(contexto);
        }
    }
}
