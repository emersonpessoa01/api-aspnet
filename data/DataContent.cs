using api.models;
using Microsoft.EntityFrameworkCore;

namespace api.data
{
    public class DataContent : DbContext
    {
        public DataContent(DbContextOptions<DataContent> options) : base(options) { }

        public DbSet<Pessoa> Pessoa { get; set; }
    }
}