using asugaksharp.Infrastructure.Persistanse;
using asugaksharp.Presentation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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

            var host = CreateHostBuilder().Build();

            // Глобальный обработчик ошибок
            Application.ThreadException += (sender, args) =>
            {
                MessageBox.Show(
                    $"Ошибка:\n\n{args.Exception.Message}",
                    "Ошибка приложения",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            };

           

            var mainForm = host.Services.GetRequiredService<MainForm>();
            Application.Run(mainForm);
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

                    services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlite(connectionString));

                    //Регистрация форм
                    services.AddTransient<MainForm>();


                });
        }
    }
}