<<<<<<< HEAD
global using System.Windows.Forms;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.EntityFrameworkCore;
global using asugaksharp.Forms;
global using asugaksharp.Model;
=======
using asugaksharp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using asugaksharp.Forms;
>>>>>>> 83269766ffcc4605752b2bcc29b8478ea34000e0

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
<<<<<<< HEAD
=======
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
>>>>>>> 83269766ffcc4605752b2bcc29b8478ea34000e0
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();

<<<<<<< HEAD
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
=======
            services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=C:\\Users\\Danamir\\source\\repos\\debervill\\asugaksharp\\asugak.db"));

            services.AddTransient<MainWindowForm>();
            services.AddTransient<PersonForm>();



            var serviceProvider = services.BuildServiceProvider();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            Application.Run(serviceProvider.GetRequiredService<MainWindowForm>());



          
>>>>>>> 83269766ffcc4605752b2bcc29b8478ea34000e0
        }
    }
}