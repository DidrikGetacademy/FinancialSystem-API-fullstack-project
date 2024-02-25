using Microsoft.EntityFrameworkCore;

namespace FinancialSystemBackend_api_database
{
    public class DbConnection : DbContext // Definerer en klasse kalt DbConnection som arver fra DbContext-klassen i Entity Framework Core
    {
        public DbSet<User> Users { get; set; }// Egenskap som representerer en samling av brukere i databasen
        public DbSet<Savings> Savings {get; set; }  // Egenskap som representerer en samling av besparelser (savings) i databasen


        // Konstruktør som tar imot DbContextOptions<DbConnection> for konfigurasjon av tilkoblingen til databasen
        public DbConnection(DbContextOptions<DbConnection> options): base(options)
        {
            // Tom konstruktør som ikke utfører noen spesifikke operasjoner ved opprettelse av en ny DbConnection-instans
        }
    }
}
