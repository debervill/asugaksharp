global using System.Windows.Forms;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.EntityFrameworkCore;
global using asugaksharp.Forms;
global using asugaksharp.Model;

namespace asugaksharp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();

            // Регистрация DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite("Data Source=asugak.db"));

            // Регистрация форм
            services.AddTransient<Form1>();
            services.AddTransient<AddPersonForm>();
            services.AddTransient<AddPeriodZasedaniaForm>();
            services.AddTransient<GakForm>();
            services.AddTransient<GenPdfForm>();
            services.AddTransient<NapravleniaPogotovkiForm>();
            services.AddTransient<OplataMainForm>();
            services.AddTransient<ProfiliPodgootovkiForm>();
            services.AddTransient<StudentsForm>();
            services.AddTransient<ZasedanieForm>();

            var serviceProvider = services.BuildServiceProvider();

            // Создание главной формы через DI
            var mainForm = serviceProvider.GetRequiredService<Form1>();
            Application.Run(mainForm);
        }
    }
}