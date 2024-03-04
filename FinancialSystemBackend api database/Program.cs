using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace FinancialSystemBackend_api_database
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;// Setter standardkulturen til invariant kultur
            var builder = WebApplication.CreateBuilder(args); // Oppretter en WebApplication-builder



            // Henter tilkoblingsstrengen fra konfigurasjonen
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


            // Legger til DbContext i tjenestene med SQL Server som databaseprovider, konfigurert med tilkoblingsstrengen
            builder.Services.AddDbContext<DbConnection>(options=> options.UseSqlServer(connectionString, options => options.UseRelationalNulls().EnableRetryOnFailure().CommandTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds)));


            // Legger til autorisasjonstjenester
            builder.Services.AddAuthorization();

            // Legger til kontrollere for MVC-arkitektur
            builder.Services.AddControllers();
            // Bygger WebApplication
            var app = builder.Build();

            // Setter opp viderekobling til HTTPS
            app.UseHttpsRedirection();


            // Aktiverer autorisasjon
            app.UseAuthorization();

            // Konfigurerer Cross-Origin Resource Sharing (CORS) for å tillate alle opprinnelser, metoder og overskrifter
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


            // Mapper kontrollerne
            app.MapControllers();

            // Starter programmet
            app.Run();
        }
    }
}
