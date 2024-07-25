using Dapper;
using DataAccess;
using Microsoft.Extensions.Configuration;
using Model.DiasDisponibles;
using Model.Empleados;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysVacacionesDAL.Interface;
using SysVacacionesMODEL;


namespace SysVacacionesDAL
{
    public class DisponiblesDA : IDisponiblesDA
    {
        private readonly ConnectionManager connectionManager;

        public DisponiblesDA(IConfiguration configuration)
        {
            connectionManager = new ConnectionManager(configuration);
        }

        public async Task<List<Disponibles>> listarDisponibles()
        {
            List<Disponibles> list = new List<Disponibles>();

            try
            {
                var connection = connectionManager.GetConnection();
                var result = await connection.QueryAsync<Disponibles>(
                    sql: "",
                    commandType: System.Data.CommandType.StoredProcedure
                    );

                if (result != null)
                {
                    list = result.ToList();
                }
            }
            catch (Exception)
            {
                throw; ;
            }

            return list;
        }


        public async Task<DisponiblesAgregar> InsertarDisponible(Disponibles disponibles)
        {
            DisponiblesAgregar respuesta = new DisponiblesAgregar();
            try
            {
                var connection = connectionManager.GetConnection();
                var parameters = new DynamicParameters();

                parameters.Add("@EmpleadoID", disponibles.empleadoId,System.Data.DbType.Int32);
                parameters.Add("@DiasDisponibles", disponibles.diasDisponibles,System.Data.DbType.Int32);

                var result = await connection.QueryAsync<DisponiblesAgregar>(
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

        public async Task<DisponiblesEditar> editarDisponible(Disponibles disponibles)
        {
            DisponiblesEditar respuesta = new DisponiblesEditar();
            try
            {
                var connection = connectionManager.GetConnection();
                var parameters = new DynamicParameters();

                parameters.Add("@ID", disponibles.disponiblesID,System.Data.DbType.Int32);
                parameters.Add("@EmpleadoID", disponibles.empleadoId, System.Data.DbType.Int32);
                parameters.Add("@DiasDisponibles", disponibles.diasDisponibles, System.Data.DbType.Int32);

                var result = await connection.QueryAsync<DisponiblesEditar>(
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

        public async Task<DisponibleDetalle> obtenerDisponible(Disponibles disponibles)
        {
            DisponibleDetalle respuesta = new DisponibleDetalle();
            try
            {
                var connection = connectionManager.GetConnection();
                var parameters = new DynamicParameters();

                parameters.Add("@ID", disponibles.disponiblesID, System.Data.DbType.Int32);
                parameters.Add("@EmpleadoID", disponibles.empleadoId, System.Data.DbType.Int32);
                parameters.Add("@DiasDisponibles", disponibles.diasDisponibles, System.Data.DbType.Int32);

                var result = await connection.QueryAsync<DisponibleDetalle>(
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
