using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.Empleados;
using Model.Puestos;
using SysVacacionesBL;
using SysVacacionesDAL.Interface;
using SysVacacionesMODEL.Empleados;

namespace SysVacaciones.Service.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly EmpleadosBL empleadosBL;
        private readonly PuestosBL puestosBL;

        public EmpleadosController(IEmpleadosDA empleadosDA, IPuestosDA puestosDA)
        {
            empleadosBL = new EmpleadosBL(empleadosDA);
            puestosBL = new PuestosBL(puestosDA);
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                var empleados = await empleadosBL.listarEmpleados();
                if (empleados != null)
                {
                    return View(empleados);
                }
                else
                {
                    return View(new List<Empleados>());
                }
            }
            catch (Exception ex)
            {
                return Json(new { mensaje = ex.Message });
            }
        }

        public async Task<ActionResult> Details()
        {
            return View();
        }

        public async Task<ActionResult> Create()
        {
            ViewBag.puestos = await obtenerPuesto();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(EmpleadosAgregar empleados)
        {
            try
            {
                ViewBag.puestos = await obtenerPuesto();
                if (!ModelState.IsValid)
                {
                    return View(empleados);
                }
                Empleados nuevoEmpleado = new Empleados()
                {
                    cedula = empleados.cedula,
                    primerNombre = empleados.primerNombre,
                    segundoNombre = empleados.segundoNombre,
                    primerApellido = empleados.primerApellido,
                    segundoApellido = empleados.segundoApellido,
                    fechaNacimiento = empleados.fechaNacimiento,
                    fechaIngreso = empleados.fechaIngreso,
                    telefono = empleados.telefono,
                    correoElectronico = empleados.correoElectronico,
                    direccion = empleados.direccion,
                    puesto = empleados.puesto,
                    salario = empleados.salario,
                    estado = empleados.estado
                };

                ViewBag.ValorMensaje = 0;
                ViewBag.MensajePorceso = "Se creo un nuevo empleado";

                return View(empleados);

            }
            catch (Exception ex)
            {
                ViewBag.ValorMensaje = 1;
                ViewBag.MensajePorceso = "No se pudo crear el nuevo empleado " + ex;
                return View(empleados);
            }
        }

        public async Task<List<SelectListItem>> obtenerPuesto()
        {
            List<Puestos> respuesta = await puestosBL.listarPuestos();

            if (respuesta != null)
            {
                List<SelectListItem> dropdown = respuesta.Select(x => new SelectListItem
                {
                    Text = x.nombrePuesto,
                    Value = x.puestoID.ToString(),
                }).ToList();

                return dropdown;
            }

            return new List<SelectListItem>();
        }

        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                ViewBag.Puestos = await obtenerPuesto();
                EmpleadosEditar empleados = new EmpleadosEditar();
                Empleados nuevoEmpleado = new Empleados()
                {
                    Id = id,
                };
                var respuesta = await empleadosBL.obtenerEmpleados(nuevoEmpleado);
                return View(empleados);
            }
            catch (Exception ex)
            {
                return Json(new { mensaje = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EmpleadosEditar empleados)
        {
            try
            {
                ViewBag.Puestos = await obtenerPuesto();
                if (!ModelState.IsValid)
                {
                    return View(empleados);
                }
                Empleados nuevoEmpleado = new Empleados()
                {
                    Id = empleados.Id,
                    cedula = empleados.cedula,
                    primerNombre = empleados.primerNombre,
                    segundoNombre = empleados.segundoNombre,
                    primerApellido = empleados.primerApellido,
                    segundoApellido = empleados.segundoApellido,
                    fechaNacimiento = empleados.fechaNacimiento,
                    fechaIngreso = empleados.fechaIngreso,
                    telefono = empleados.telefono,
                    correoElectronico = empleados.correoElectronico,
                    direccion = empleados.direccion,
                    puesto = empleados.puesto,
                    salario = empleados.salario,
                    estado = empleados.estado
                };
                var respuesta = await empleadosBL.editarEmpleado(nuevoEmpleado);

                ViewBag.ValorMensaje = 0;
                ViewBag.MensajeProceso = "Empleado acualizado satisfactoriamente";

                return View(empleados);
            }
            catch (Exception ex)
            {
                ViewBag.ValorMensaje = 1;
                ViewBag.MensajeProceso = "Error al editar la información del empleado" + ex.Message;
                return View(empleados);
            }
        }

        public async Task<ActionResult> Inactivar(int id)
        {
            try
            {
                EmpleadosInactivar empleados = new EmpleadosInactivar();
                Empleados nuevoEmpleado = new Empleados()
                {
                    Id = id,
                };
                var respuesta = await empleadosBL.obtenerEmpleados(nuevoEmpleado);
                return View(empleados);
            }
            catch (Exception ex)
            {
                return Json(new { mensaje = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Inactivar(EmpleadosInactivar empleados)
        {
            try
            {
                ViewBag.Puestos = await obtenerPuesto();
                if (!ModelState.IsValid)
                {
                    return View(empleados);
                }
                Empleados nuevoEmpleado = new Empleados()
                {
                    Id = empleados.Id
                };
                var respuesta = await empleadosBL.inactivarEmpleados(nuevoEmpleado);

                ViewBag.ValorMensaje = 0;
                ViewBag.MensajeProceso = "Empleado desactivado satisfactoriamente";

                return View(empleados);
            }
            catch (Exception ex)
            {
                ViewBag.ValorMensaje = 1;
                ViewBag.MensajeProceso = "Error al desactivar el empleado" + ex.Message;
                return View(empleados);
            }
        }
    }
}
