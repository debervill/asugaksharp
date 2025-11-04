using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace asugaksharp.Model
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // Построение конфигурации
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Получаем строку подключения
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine(connectionString);

            // Если путь относительный, делаем его абсолютным
            var dbFileName = connectionString.Replace("Data Source=", "").Trim();
            if (!Path.IsPathRooted(dbFileName))
            {
                var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dbFileName);
                connectionString = $"Data Source={dbPath}";
            }

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlite(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}