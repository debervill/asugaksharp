using asugaksharp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using asugaksharp.Forms;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();

            services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=C:\\Users\\Danamir\\source\\repos\\debervill\\asugaksharp\\asugak.db"));

            services.AddTransient<MainWindowForm>();
            services.AddTransient<PersonForm>();



            var serviceProvider = services.BuildServiceProvider();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            Application.Run(serviceProvider.GetRequiredService<MainWindowForm>());



          
        }
    }
}