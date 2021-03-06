using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Dapper;
using Npgsql;

namespace monolith
{
    public class PostgresProvider
    {
        private string _connectionString { get; }

        public PostgresProvider(string connectionString) {
            this._connectionString = connectionString;
        }

        public PostgresProvider(string host, string username, string password, string database)
        {
            this._connectionString = $"Host={ host };Username={ username };Password={ password };Database={ database }";
        }

        public async Task<NpgsqlConnection> NewConnection() {
            var conn = new NpgsqlConnection(this._connectionString);
            await conn.OpenAsync();
            return conn;
        }
    }
}