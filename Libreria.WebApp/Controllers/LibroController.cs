using Libreria.FrontBusiness;
using Libreria.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TransversalLibrary;

namespace Libreria.WebApp.Controllers
{
    /// <summary>
    /// Define el controlador del Libro
    /// </summary>
    public class LibroController : Controller
    {
        /// <summary>
        /// Define la lógica de los libros
        /// </summary>
        private readonly LibroFrontBusiness LibroFrontBusiness;

        /// <summary>
        /// Define la lógica de los géneros
        /// </summary>
        private readonly GeneroFrontBusiness GeneroFrontBusiness;

        /// <summary>
        /// Define la lógica de los autores
        /// </summary>
        private readonly AutorFrontBusiness AutorFrontBusiness;

        /// <summary>
        /// Inicializa las propiedades de esta clase
        /// </summary>
        public LibroController()
        {
            LibroFrontBusiness = new LibroFrontBusiness();
            GeneroFrontBusiness = new GeneroFrontBusiness();
            AutorFrontBusiness = new AutorFrontBusiness();
        }

        /// <summary>
        /// Obtiene los géneros
        /// </summary>
        private void GetGeneros()
        {
            Response<IEnumerable<GENERO>> response = GeneroFrontBusiness?.Consultar();
            IEnumerable<GENERO> ciudades = response?.Data;
            if (ciudades?.Any() == true)
            {
                IEnumerable<SelectListItem> selectListItems = ciudades.Select(x => new SelectListItem()
                {
                    Text = x?.NOMBRE,
                    Value = x?.ID
                });
                ViewBag.Generos = selectListItems;
            }
        }

        /// <summary>
        /// Obtiene los autores
        /// </summary>
        private void GetAutores()
        {
            Response<IEnumerable<AUTOR>> response = AutorFrontBusiness?.Consultar();
            IEnumerable<AUTOR> ciudades = response?.Data;
            if (ciudades?.Any() == true)
            {
                IEnumerable<SelectListItem> selectListItems = ciudades.Select(x => new SelectListItem()
                {
                    Text = x?.NOMBRECOMPLETO,
                    Value = x?.ID
                });
                ViewBag.Autores = selectListItems;
            }
        }

        // GET: LibroController
        public ActionResult Index(string valor = "")
        {
            Response<IEnumerable<LIBRO>> response = LibroFrontBusiness?.Consultar(valor);
            IEnumerable<LIBRO> Libros = response?.Data;
            return View(Libros);
        }

        // GET: LibroController/Details/5
        public ActionResult Details(string id)
        {
            Response<IEnumerable<LIBRO>> response = LibroFrontBusiness?.Consultar(id);
            LIBRO LibroModel = response?.Data?.FirstOrDefault();
            return View(LibroModel);
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            GetGeneros();
            GetAutores();
            return View();
        }

        // POST: LibroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LIBRO LibroModel)
        {
            Response<LIBRO> response = LibroFrontBusiness?.Insertar(LibroModel);
            TempData.Remove("Message");
            if (!string.IsNullOrWhiteSpace(response?.Data?.ID))
            {
                TempData.Add("Message", "Libro insertado exitosamente");
                return RedirectToAction(nameof(Index));
            }
            else
            {
                GetGeneros();
                GetAutores();
                TempData.Add("Message", "El Libro no pudo ser insertado");
                return View();
            }
        }

        // GET: LibroController/Edit/5
        public ActionResult Edit(string id)
        {
            GetGeneros();
            GetAutores();
            Response<IEnumerable<LIBRO>> response = LibroFrontBusiness?.Consultar(id);
            LIBRO LibroModel = response?.Data?.FirstOrDefault();
            return View(LibroModel);
        }

        // POST: LibroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LIBRO LibroModel)
        {
            Response<bool> response = LibroFrontBusiness?.Editar(LibroModel);
            TempData.Remove("Message");
            if (response?.Data == true)
            {
                TempData.Add("Message", "Libro editado exitosamente");
                return RedirectToAction(nameof(Index));
            }
            else
            {
                GetGeneros();
                GetAutores();
                TempData.Add("Message", "El Libro no pudo ser editado");
                return View();
            }
        }

        // GET: LibroController/Delete/5
        public ActionResult Delete(string id)
        {
            Response<IEnumerable<LIBRO>> response = LibroFrontBusiness?.Consultar(id);
            LIBRO LibroModel = response?.Data?.FirstOrDefault();
            return View(LibroModel);
        }

        // POST: LibroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(LIBRO LibroModel)
        {
            Response<bool> response = LibroFrontBusiness?.Eliminar(LibroModel);
            TempData.Remove("Message");
            if (response?.Data == true)
            {
                TempData.Add("Message", "Libro eliminado exitosamente");
                return RedirectToAction(nameof(Index));
            }
            else
            {
                Response<IEnumerable<LIBRO>> LibroResponse = LibroFrontBusiness?.Consultar(LibroModel?.ID);
                LibroModel = LibroResponse?.Data?.FirstOrDefault();
                TempData.Add("Message", "El Libro no pudo ser eliminado");
                return View(LibroModel);
            }
        }
    }
}
