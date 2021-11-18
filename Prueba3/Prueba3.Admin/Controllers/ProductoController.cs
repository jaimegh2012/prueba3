using Prueba3.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueba3.Admin.Controllers
{
    public class ProductoController : Controller
    {
        ProductoBL _productoBL;
        CategoriaBL _categoriaBL;
        List<Producto> listaProductos;

        public ProductoController()
        {
            _productoBL = new ProductoBL();
            _categoriaBL = new CategoriaBL();
            listaProductos = new List<Producto>();
        }

        // GET: Producto
        public ActionResult Index()
        {
            listaProductos = _productoBL.obtenerProductos();
            return View(listaProductos);
        }

        public ActionResult Crear()
        {
            var producto = new Producto();

            var categorias = _categoriaBL.obtenerCategorias();
            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion");

            return View(producto);
        }

        [HttpPost]
        public ActionResult Crear(Producto producto)
        {
            var categorias = _categoriaBL.obtenerCategorias();
            

            if (ModelState.IsValid)
            {
                _productoBL.guardarProducto(producto);
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion");
            return View(producto);
        }

        public ActionResult Editar(int id)
        {
            var producto = _productoBL.obtenerProducto(id);
            var categorias = _categoriaBL.obtenerCategorias();
            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion", producto.CategoriaId);

            return View(producto);
        }

        [HttpPost]
        public ActionResult Editar(Producto producto)
        {
            var categorias = _categoriaBL.obtenerCategorias();

            if (ModelState.IsValid)
            {
                _productoBL.guardarProducto(producto);
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion", producto.CategoriaId);
            return View(producto);
        }


        public ActionResult Detalle(int id)
        {
            var producto = _productoBL.obtenerProducto(id);
            return View(producto);
        }


        public ActionResult Eliminar(int id)
        {
            var producto = _productoBL.obtenerProducto(id);

            return View(producto);
        }

        [HttpPost]
        public ActionResult Eliminar(Producto producto)
        {
            _productoBL.eliminarProducto(producto.Id);

            return RedirectToAction("Index");
        }

    }
}