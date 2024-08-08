using Dapper;
using DataAccess;
using Microsoft.Extensions.Configuration;
using Model.DiasDisponibles;
using Model.Puestos;
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
    public class PuestosDA : IPuestosDA
    {
        private readonly ConnectionManager connectionManager;

        public PuestosDA(IConfiguration configuration)
        {
            connectionManager = new ConnectionManager(configuration);
        }

        public async Task<List<Puestos>> listarPuesto()
        {
            List<Puestos> list = new List<Puestos>();

            try
            {
                var connection = connectionManager.GetConnection();
                var result = await connection.QueryAsync<Puestos>(
                    sql: "usp_ListarPuestos",
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


        public async Task<PuestosAgregar> insertarPuesto(Puestos puestos)
        {
            PuestosAgregar respuesta = new PuestosAgregar();
            try
            {
                var connection = connectionManager.GetConnection();
                var parameters = new DynamicParameters();

                parameters.Add("@EmpleadoID", puestos.ID, System.Data.DbType.Int32);

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

        public async Task<PuestosEditar> editarPuesto(Puestos puestos)
        {
            PuestosEditar respuesta = new PuestosEditar();
            try
            {
                var connection = connectionManager.GetConnection();
                var parameters = new DynamicParameters();

                parameters.Add("@ID", puestos.ID, System.Data.DbType.Int32);
                parameters.Add("@EmpleadoID", puestos.Nombre, System.Data.DbType.String);

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

        public async Task<PuestosDetalle> obtenerPuesto(Puestos puestos)
        {
            PuestosDetalle respuesta = new PuestosDetalle();
            try
            {
                var connection = connectionManager.GetConnection();
                var parameters = new DynamicParameters();

                parameters.Add("@ID", puestos.ID, System.Data.DbType.Int32);
                parameters.Add("@EmpleadoID", puestos.Nombre, System.Data.DbType.String);

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
    }
}
