using Libreria.FrontBusiness;
using Libreria.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TransversalLibrary;

namespace Libreria.WebApp.Controllers
{
    /// <summary>
    /// Define el controlador del autor
    /// </summary>
    public class AutorController : Controller
    {
        /// <summary>
        /// Define la lógica de los autores
        /// </summary>
        private readonly AutorFrontBusiness AutorFrontBusiness;

        /// <summary>
        /// Define la lógica de las ciudades
        /// </summary>
        private readonly CiudadFrontBusiness CiudadFrontBusiness;

        /// <summary>
        /// Inicializa las propiedades de esta clase
        /// </summary>
        public AutorController()
        {
            CiudadFrontBusiness = new CiudadFrontBusiness();
            AutorFrontBusiness = new AutorFrontBusiness();
        }

        /// <summary>
        /// Obtiene las ciudades
        /// </summary>
        private void GetCiudades()
        {
            Response<IEnumerable<CIUDAD>> response = CiudadFrontBusiness?.Consultar();
            IEnumerable<CIUDAD> ciudades = response?.Data;
            if (ciudades?.Any() == true)
            {
                IEnumerable<SelectListItem> selectListItems = ciudades.Select(x => new SelectListItem()
                {
                    Text = x?.NOMBRE,
                    Value = x?.ID
                });
                ViewBag.Ciudades = selectListItems;
            }
        }

        // GET: AutorController
        public ActionResult Index(string valor = "")
        {
            Response<IEnumerable<AUTOR>> response = AutorFrontBusiness?.Consultar(valor);
            IEnumerable<AUTOR> Autors = response?.Data;
            return View(Autors);
        }

        // GET: AutorController/Details/5
        public ActionResult Details(string id)
        {
            Response<IEnumerable<AUTOR>> response = AutorFrontBusiness?.Consultar(id);
            AUTOR AutorModel = response?.Data?.FirstOrDefault();
            return View(AutorModel);
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            GetCiudades();
            return View();
        }

        // POST: AutorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AUTOR AutorModel)
        {
            Response<AUTOR> response = AutorFrontBusiness?.Insertar(AutorModel);
            TempData.Remove("Message");
            if (!string.IsNullOrWhiteSpace(response?.Data?.ID))
            {
                TempData.Add("Message", "Autor insertado exitosamente");
                return RedirectToAction(nameof(Index));
            }
            else
            {
                GetCiudades();
                TempData.Add("Message", "El autor no pudo ser insertado");
                return View();
            }
        }

        // GET: AutorController/Edit/5
        public ActionResult Edit(string id)
        {
            GetCiudades();
            Response<IEnumerable<AUTOR>> response = AutorFrontBusiness?.Consultar(id);
            AUTOR AutorModel = response?.Data?.FirstOrDefault();
            return View(AutorModel);
        }

        // POST: AutorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AUTOR AutorModel)
        {
            Response<bool> response = AutorFrontBusiness?.Editar(AutorModel);
            TempData.Remove("Message");
            if (response?.Data == true)
            {
                TempData.Add("Message", "Autor editado exitosamente");
                return RedirectToAction(nameof(Index));
            }
            else
            {
                GetCiudades();
                TempData.Add("Message", "El autor no pudo ser editado");
                return View();
            }
        }

        // GET: AutorController/Delete/5
        public ActionResult Delete(string id)
        {
            Response<IEnumerable<AUTOR>> response = AutorFrontBusiness?.Consultar(id);
            AUTOR AutorModel = response?.Data?.FirstOrDefault();
            return View(AutorModel);
        }

        // POST: AutorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(AUTOR AutorModel)
        {
            Response<bool> response = AutorFrontBusiness?.Eliminar(AutorModel);
            TempData.Remove("Message");
            if (response?.Data == true)
            {
                TempData.Add("Message", "Autor eliminado exitosamente");
                return RedirectToAction(nameof(Index));
            }
            else
            {
                Response<IEnumerable<AUTOR>> AutorResponse = AutorFrontBusiness?.Consultar(AutorModel?.ID);
                AutorModel = AutorResponse?.Data?.FirstOrDefault();
                TempData.Add("Message", "El Autor no pudo ser eliminado");
                return View(AutorModel);
            }
        }
    }
}
