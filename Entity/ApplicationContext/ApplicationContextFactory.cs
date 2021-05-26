using KeyVaultRead;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Entity
{
    class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public static ApplicationContext CreateApplicationContext(string connectionType)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");

            var config = builder.Build();
            string connectionString = config.GetConnectionString(connectionType);
            string connectionString2 = GetSecrets.ConnectionString;

            System.Console.WriteLine(connectionString);

            System.Console.WriteLine(connectionString2);



            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder.UseSqlServer(connectionString).Options;

            return new ApplicationContext(options);
        }
        public  ApplicationContext CreateDbContext(string[] args)
        {
            return CreateApplicationContext("DefaultConnection");
        }
    }
}
