using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Context
{
    public class DocumentsContext : DbContext
    {
        IConfiguration configuration;
        private readonly string connectionString = string.Empty;
        public DocumentsContext(IConfiguration configuration)
            :base()
        {
            this.configuration = configuration;
            this.connectionString = this.configuration.GetValue<string>("db-connection-string");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.connectionString);
        }

        

        public DbSet<Document> Documents { get; set; }
    }
}
