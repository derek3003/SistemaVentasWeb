using Microsoft.AspNetCore.Mvc;
using SistemaVentas.Models; // Asegúrate de usar el namespace correcto
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace SistemaVentas.Controllers
{
    public class LoginController : Controller
    {
        private readonly DbventasContext _context;

        public LoginController(DbventasContext context)
        {
            _context = context;
        }

        // GET: Login
        public IActionResult Index()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public IActionResult Index(string usuario, string clave)
        {
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(clave))
            {
                ViewBag.Error = "Ingrese todos los campos.";
                return View();
            }

            // Buscar el usuario en la base de datos por nombre de usuario y clave
            var empleado = _context.Empleados
                .FirstOrDefault(e => e.Usuario == usuario && e.Clave == clave);

            // Validar si el usuario existe y está activo
            if (empleado == null)
            {
                ViewBag.Error = "Usuario o contraseña incorrectos.";
                return View();
            }

            // Guardar información del empleado en la sesión
            HttpContext.Session.SetString("IdEmpleado", empleado.IdEmpleado.ToString());
            HttpContext.Session.SetString("NombreEmpleado", empleado.Nombre);

            // Redirigir al controlador Home o al menú principal
            return RedirectToAction("Index", "Home");
        }

        // GET: Logout
        public IActionResult Logout()
        {
            // Limpiar la sesión y redirigir al login
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
