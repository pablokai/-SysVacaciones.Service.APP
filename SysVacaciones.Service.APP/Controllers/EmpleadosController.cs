using Microsoft.AspNetCore.Mvc;
using Model.Empleados;
using SysVacacionesBL;
using SysVacacionesDAL.Interface;
using SysVacacionesMODEL.Empleados;

namespace SysVacaciones.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly EmpleadosBL empleadosBL;
        private readonly PuestosBL puestosBL;

        public EmpleadosController(IEmpleadosDA empleadosDA, IPuestosDA puestosDA)
        {
            empleadosBL = new EmpleadosBL(empleadosDA);
            puestosBL = new PuestosBL(puestosDA);
        }

        [HttpGet]
        [Route("ListarEmpleados")]
        public async Task<ActionResult> ListarEmpleados()
        {
            try
            {
                var empleados = await empleadosBL.listarEmpleados();

                return StatusCode(200, empleados);

            }
            catch (Exception ex)
            {
                throw ;
            }
        }


        [HttpPost]
        [Route("InsertarEmpleado")]
        public async Task<ActionResult> InsertarEmpleado(EmpleadosAgregar empleados)
        {
            try
            {
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

                var respuesta = await empleadosBL.insertarEmpleado(nuevoEmpleado);

                return StatusCode(200, respuesta);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //public async Task<List<SelectListItem>> obtenerPuesto()
        //{
        //    List<Puestos> respuesta = await puestosBL.listarPuestos();

        //    if (respuesta != null)
        //    {
        //        List<SelectListItem> dropdown = respuesta.Select(x => new SelectListItem
        //        {
        //            Text = x.nombrePuesto,
        //            Value = x.puestoID.ToString(),
        //        }).ToList();

        //        return dropdown;
        //    }

        //    return new List<SelectListItem>();
        //}

        //public async Task<ActionResult> ModificarEmpleado(int id)
        //{
        //    try
        //    {
        //        ViewBag.Puestos = await obtenerPuesto();
        //        EmpleadosEditar empleados = new EmpleadosEditar();
        //        Empleados nuevoEmpleado = new Empleados()
        //        {
        //            Id = id,
        //        };
        //        var respuesta = await empleadosBL.obtenerEmpleados(nuevoEmpleado);
        //        return View(empleados);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { mensaje = ex.Message });
        //    }
        //}

        [HttpPost]
        [Route("ModificarEmpleado")]
        public async Task<ActionResult> ModificarEmpleado(EmpleadosEditar empleados)
        {
            try
            {
               
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



                return StatusCode(200, respuesta);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //public async Task<ActionResult> Inactivar(int id)
        //{
        //    try
        //    {
        //        EmpleadosInactivar empleados = new EmpleadosInactivar();
        //        Empleados nuevoEmpleado = new Empleados()
        //        {
        //            Id = id,
        //        };
        //        var respuesta = await empleadosBL.obtenerEmpleados(nuevoEmpleado);
        //        return View(empleados);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { mensaje = ex.Message });
        //    }
        //}

        [HttpPost]
        [Route("InactivarEmpleado")]
        public async Task<ActionResult> InactivarEmpleado(EmpleadosInactivar empleados)
        {
            try
            {
           
                Empleados nuevoEmpleado = new Empleados()
                {
                    Id = empleados.Id
                };
                var respuesta = await empleadosBL.inactivarEmpleados(nuevoEmpleado);

                return StatusCode(200, respuesta);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("BuscarEmpleado")]
        public async Task<ActionResult> BuscarEmpleado([FromQuery] string cedula)
        {
            try
            {

                Empleados nuevoEmpleado = new Empleados()
                {
                    cedula = cedula
                };
                var respuesta = await empleadosBL.buscarEmpleado(nuevoEmpleado);

                return StatusCode(200, respuesta);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
