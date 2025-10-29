using asugaksharp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using asugaksharp.Forms;

namespace asugaksharp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();

            // Путь к БД
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "asugak.db");

            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite($"Data Source={dbPath}"));

            var serviceProvider = services.BuildServiceProvider();

            // Получаем DbContext БЕЗ using - он должен жить всё время работы приложения
            var dbContext = serviceProvider.GetRequiredService<AppDbContext>();

            // Создать БД если не существует
            dbContext.Database.EnsureCreated();

            // Запускаем главное окно
            Application.Run(new Form1(dbContext));

            // После закрытия приложения освобождаем ресурсы
            dbContext.Dispose();
            serviceProvider.Dispose();
        }
    }
}