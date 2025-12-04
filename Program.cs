using asugaksharp.ApplicationLayer;
using asugaksharp.Infrastructure.Persistanse;
using asugaksharp.Presentation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Windows.Forms;

namespace asugaksharp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            SQLitePCL.Batteries.Init();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);

            // ✅ Создаём и запускаем хост
            var host = CreateHostBuilder().Build();

            // Глобальный обработчик ошибок
            Application.ThreadException += (sender, args) =>
            {
                MessageBox.Show(
                    $"Ошибка:\n\n{args.Exception.Message}\n\nStackTrace:\n{args.Exception.StackTrace}",
                    "Ошибка приложения",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            };

            try
            {
                // ✅ ВАЖНО: Получаем MainForm через DI
                var mainForm = host.Services.GetRequiredService<MainForm>();
                Application.Run(mainForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Критическая ошибка при запуске:\n\n{ex.Message}\n\nStackTrace:\n{ex.StackTrace}",
                    "Критическая ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("appsettings.json", optional: false);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    var connectionString = hostContext.Configuration
                        .GetConnectionString("DefaultConnection")
                        ?? "Data Source=data/asugak.db";

                    // ✅ Регистрация DbContext
                    services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlite(connectionString));

                    // ✅ Регистрация Application Layer (сервисы)
                    services.AddApplication();

                    // ✅ Регистрация Presentation Layer (формы)
                    services.AddPresentation();
                });
        }
    }
}