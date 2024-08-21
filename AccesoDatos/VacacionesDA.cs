
using Dapper;
using DataAccess;
using Microsoft.Extensions.Configuration;
using Model.DiasDisponibles;
using Model.Empleados;
using Model.Vacaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysVacacionesDAL.Interface;
using SysVacacionesMODEL;

namespace SysVacacionesDAL
{
    public class VacacionesDA : IVacacionesDA
    {
        private readonly ConnectionManager connectionManager;

        public VacacionesDA(IConfiguration configuration)
        {
            connectionManager = new ConnectionManager(configuration);
        }

        public async Task<List<Vacaciones>> listarVacaciones()
        {
            List<Vacaciones> list = new List<Vacaciones>();

            try
            {
                var connection = connectionManager.GetConnection();
                var result = await connection.QueryAsync<Vacaciones>(
                    sql: "usp_ListarVacaciones",
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


        public async Task<Respuesta> insertarVacaciones(VacacionesAgregar vacaciones)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                var connection = connectionManager.GetConnection();
                var parameters = new DynamicParameters();

                parameters.Add("@EmpleadoID", vacaciones.empleadoID, System.Data.DbType.Int32);
                parameters.Add("@FechaSolicitud", vacaciones.fechaSolicitud, System.Data.DbType.Date);
                parameters.Add("@DiasSolicitados", vacaciones.diasSolicitados, System.Data.DbType.Int32);
                parameters.Add("@FechaSalida", vacaciones.fechaSalida, System.Data.DbType.Date);
                parameters.Add("@FechaEntrada", vacaciones.fechaEntrada, System.Data.DbType.Date);

                var result = await connection.QueryAsync<Respuesta>(
                    sql: "sp_SolicitarVacaciones",
                    param: parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                    );
                if( result != null )
                {
                    respuesta = result.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return respuesta;

        }

        public async Task<VacacionesEditar> editarVacaciones(Vacaciones vacaciones)
        {
            VacacionesEditar respuesta = new VacacionesEditar();
            try
            {
                var connection = connectionManager.GetConnection();
                var parameters = new DynamicParameters();

                parameters.Add("@ID", vacaciones.ID, System.Data.DbType.Int32);
                parameters.Add("@EmpleadoID", vacaciones.empleadoID, System.Data.DbType.Int32);
                parameters.Add("@FechaSolicitud", vacaciones.fechaSolicitud, System.Data.DbType.Date);
                parameters.Add("@DiasSolicitados", vacaciones.diasSolicitados, System.Data.DbType.Int32);
                parameters.Add("@FechaSalida", vacaciones.fechaSalida, System.Data.DbType.Date);
                parameters.Add("@FechaEntrada", vacaciones.fechaEntrada, System.Data.DbType.Date);

                var result = await connection.QueryAsync<VacacionesEditar>(
                    sql: "",
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

        public async Task<VacacionesDetalle> obtenerVacaciones(Vacaciones vacaciones)
        {
            VacacionesDetalle respuesta = new VacacionesDetalle();
            try
            {
                var connection = connectionManager.GetConnection();
                var parameters = new DynamicParameters();

                parameters.Add("@ID", vacaciones.ID, System.Data.DbType.Int32);
                parameters.Add("@EmpleadoID", vacaciones.empleadoID, System.Data.DbType.Int32);
                parameters.Add("@FechaSolicitud", vacaciones.fechaSolicitud, System.Data.DbType.Date);
                parameters.Add("@DiasSolicitados", vacaciones.diasSolicitados, System.Data.DbType.Int32);
                parameters.Add("@FechaSalida", vacaciones.fechaSalida, System.Data.DbType.Date);
                parameters.Add("@FechaEntrada", vacaciones.fechaEntrada, System.Data.DbType.Date);

                var result = await connection.QueryAsync<VacacionesDetalle>(
                    sql: "",
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
