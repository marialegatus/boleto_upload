using System.Data;
using Npgsql;

namespace BoletoUpload.Infrastructure.Repository
{
    public class BaseRepository
    {
        private string ConnectionString { get; }
        public NpgsqlConnection Connection { get; }

        public BaseRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetSection("ConnectionStrings:DefaultConnection").Get<string>();
            Connection = new NpgsqlConnection(ConnectionString);
        }
    }
}
