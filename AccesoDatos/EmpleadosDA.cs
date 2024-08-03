using Dapper;
using DataAccess;
using Microsoft.Extensions.Configuration;
using Model.DiasDisponibles;
using Model.Empleados;
using Model.Puestos;
using Model.Vacaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysVacacionesDAL.Interface;
using SysVacacionesMODEL;
using SysVacacionesMODEL.Empleados;

namespace SysVacacionesDAL
{
    public class EmpleadosDA : IEmpleadosDA
    {
        private readonly ConnectionManager connectionManager;

        public EmpleadosDA(IConfiguration configuration)
        {
            connectionManager = new ConnectionManager(configuration);
        }

        public async Task<List<Empleados>> listarEmpleados()
        {
            List<Empleados> list = new List<Empleados>();

            try
            {
                using var connection = connectionManager.GetConnection();
                var result = await connection.QueryAsync<Empleados>(
                    sql: "sp_ListarEmpleadosActivos",
                    commandType: System.Data.CommandType.StoredProcedure
                    );

                if (result != null)
                {
                    list = result.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return list;
        }


        public async Task<EmpleadosAgregar> insertarEmpleado(Empleados empleados)
        {
            EmpleadosAgregar respuesta = new EmpleadosAgregar();
            try
            {
                var connection = connectionManager.GetConnection();
                var parameters = new DynamicParameters();

                parameters.Add("@Cedula", empleados.cedula, System.Data.DbType.String);
                parameters.Add("@PrimerNombre", empleados.primerNombre, System.Data.DbType.Int32);
                parameters.Add("@SegundoNombre", empleados.segundoNombre, System.Data.DbType.String);
                parameters.Add("@PrimerApellido", empleados.primerApellido, System.Data.DbType.String);
                parameters.Add("@SegundoApellido", empleados.segundoApellido, System.Data.DbType.String);
                parameters.Add("@FechaNacimiento", empleados.fechaNacimiento, System.Data.DbType.Date);
                parameters.Add("@FechaIngreo", empleados.fechaIngreso, System.Data.DbType.Date);
                parameters.Add("@Telefono", empleados.telefono, System.Data.DbType.String);
                parameters.Add("@CorreoElectronico", empleados.correoElectronico, System.Data.DbType.String);
                parameters.Add("@Direccion", empleados.direccion, System.Data.DbType.String);
                parameters.Add("@Puesto", empleados.puesto, System.Data.DbType.String);
                parameters.Add("@Salario", empleados.salario, System.Data.DbType.Decimal);
                parameters.Add("@Estado", empleados.estado, System.Data.DbType.String);

                var result = await connection.QueryAsync<DisponiblesAgregar>(
                    sql: "sp_InsertarEmpleado",
                    param: parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
            catch (Exception)
            {
                throw;
            }

            return respuesta;

        }

        public async Task<EmpleadosEditar> editarEmpleado(Empleados empleados)
        {
            EmpleadosEditar respuesta = new EmpleadosEditar();
            try
            {
                var connection = connectionManager.GetConnection();
                var parameters = new DynamicParameters();

                parameters.Add("@ID", empleados.Id, System.Data.DbType.Int32);
                parameters.Add("@Cedula", empleados.cedula, System.Data.DbType.String);
                parameters.Add("@PrimerNombre", empleados.primerNombre, System.Data.DbType.Int32);
                parameters.Add("@SegundoNombre", empleados.segundoNombre, System.Data.DbType.String);
                parameters.Add("@PrimerApellido", empleados.primerApellido, System.Data.DbType.String);
                parameters.Add("@SegundoApellido", empleados.segundoApellido, System.Data.DbType.String);
                parameters.Add("@FechaNacimiento", empleados.fechaNacimiento, System.Data.DbType.Date);
                parameters.Add("@FechaIngreo", empleados.fechaIngreso, System.Data.DbType.Date);
                parameters.Add("@Telefono", empleados.telefono, System.Data.DbType.String);
                parameters.Add("@CorreoElectronico", empleados.correoElectronico, System.Data.DbType.String);
                parameters.Add("@Direccion", empleados.direccion, System.Data.DbType.String);
                parameters.Add("@Puesto", empleados.puesto, System.Data.DbType.String);
                parameters.Add("@Salario", empleados.salario, System.Data.DbType.Decimal);
                parameters.Add("@Estado", empleados.estado, System.Data.DbType.String);

                var result = await connection.QueryAsync<DisponiblesAgregar>(
                    sql: "sp_ActualizarEmpleado",
                    param: parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
            catch (Exception)
            {
                throw;
            }

            return respuesta;
        }

        public async Task<EmpleadosDetalles> obtenerEmpleado(Empleados empleados)
        {
            EmpleadosDetalles respuesta = new EmpleadosDetalles();
            try
            {
                var connection = connectionManager.GetConnection();
                var parameters = new DynamicParameters();

                parameters.Add("@ID", empleados.Id, System.Data.DbType.Int32);
                parameters.Add("@Cedula", empleados.cedula, System.Data.DbType.String);
                parameters.Add("@PrimerNombre", empleados.primerNombre, System.Data.DbType.Int32);
                parameters.Add("@SegundoNombre", empleados.segundoNombre, System.Data.DbType.String);
                parameters.Add("@PrimerApellido", empleados.primerApellido, System.Data.DbType.String);
                parameters.Add("@SegundoApellido", empleados.segundoApellido, System.Data.DbType.String);
                parameters.Add("@FechaNacimiento", empleados.fechaNacimiento, System.Data.DbType.Date);
                parameters.Add("@FechaIngreo", empleados.fechaIngreso, System.Data.DbType.Date);
                parameters.Add("@Telefono", empleados.telefono, System.Data.DbType.String);
                parameters.Add("@CorreoElectronico", empleados.correoElectronico, System.Data.DbType.String);
                parameters.Add("@Direccion", empleados.direccion, System.Data.DbType.String);
                parameters.Add("@Puesto", empleados.puesto, System.Data.DbType.String);
                parameters.Add("@Salario", empleados.salario, System.Data.DbType.Decimal);
                parameters.Add("@Estado", empleados.estado, System.Data.DbType.String);

                var result = await connection.QueryAsync<DisponiblesAgregar>(
                    sql: "sp_ObtenerEmpleado",
                    param: parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
            catch (Exception)
            {
                throw;
            }

            return respuesta;
        }

        public async Task<EmpleadosInactivar> inactivarEmpleados(Empleados empleados)
        {
            EmpleadosInactivar respuesta = new EmpleadosInactivar();
            try
            {
                var connection = connectionManager.GetConnection();
                var parameters = new DynamicParameters();

                parameters.Add("@ID", empleados.Id, System.Data.DbType.Int32);

                var result = await connection.QueryAsync<EmpleadosInactivar>(
                    sql: "sp_InactivarEmpleado",
                    param: parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
            catch (Exception)
            {
                throw;
            }

            return respuesta;
        }
    }
}

