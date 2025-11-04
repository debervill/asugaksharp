using asugaksharp.Forms;
using asugaksharp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace asugaksharp
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Построение конфигурации из appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Получаем строку подключения
            var connectionString = configuration.GetConnectionString("DefaultConnection");

           

            // Если путь относительный, делаем его абсолютным
            if (!Path.IsPathRooted(connectionString.Replace("Data Source=", "")))
            {
                var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "asugak.db");
                connectionString = $"Data Source={dbPath}";
            }

            // Настройка DI контейнера
            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(connectionString));


            ServiceProvider = services.BuildServiceProvider();

            // Убедимся, что БД существует
            using (var scope = ServiceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.EnsureCreated();
            }

            Application.Run(new MainWindowForm());
        }
    }
}