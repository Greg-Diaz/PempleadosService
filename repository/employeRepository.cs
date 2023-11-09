using Dapper;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using PempleadosService.data;
using PempleadosService.models;

namespace PempleadosService.repository
{
    public class employeRepository : iemployeRepository
    {
        private readonly mySqlConfiguration _connectionString;
        public employeRepository(mySqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConectionString);
        }


        public async Task<bool> CreateEmploye(employe employe)
        {
            var db = dbConnection();
            var sql = @" INSERT INTO employe (documento, nombre, apellido, telefono, email, direccion, genero)
                                VALUES (@Documento, @Nombre, @Apellido, @Telefono, @Email, @Direccion, @Genero)";
            var result = await db.ExecuteAsync(sql, new
            { employe.documento, employe.nombre, employe.apellido, employe.telefono, employe.email, employe.direccion, employe.genero });
            return result > 0;
        }

        public async Task<bool> DeleteEmploye(int id)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM employe WHERE id = @Id";
            var result = await db.ExecuteAsync(sql, new { Id = id });
            return result > 0;
        }




        public async Task<bool> UpdateEmploye(employe employe)
        {
            var db = dbConnection();
            var sql = @" UPDATE employe SET documento = @Documento, 
                                            nombre = @Nombre, 
                                            apellido = @Apellido, 
                                            telefono = @Telefono,
                                            email = @Email, 
                                            direccion = @Direccion, 
                                            genero = @Genero
                                    WHERE id = @Id";
            var result = await db.ExecuteAsync(sql, new
            { employe.documento, employe.nombre, employe.apellido, employe.telefono, employe.email, employe.direccion, employe.genero, employe.id });
            return result > 0;
        }

        public async Task<IEnumerable<employe>> GetEmployesDetails(string nombre)
        {
            var db = dbConnection();
            var sql = @" SELECT documento, nombre, apellido, telefono, email, direccion, genero
                            FROM employe 
                                WHERE nombre LIKE @Nombre or apellido LIKE @Nombre";
            return await db.QueryAsync<employe>(sql, new { Nombre = "%"+nombre+"%" });
        }

        public async Task<IEnumerable<employe>> GetEmployes()
        {
            var db = dbConnection();
            var sql = @" SELECT documento, nombre, apellido, telefono, email, direccion, genero
                            FROM employe";
            return await db.QueryAsync<employe>(sql, new { });
        }
    }
}
