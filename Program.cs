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

            // ���� � ��
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "asugak.db");

            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite($"Data Source={dbPath}"));

            var serviceProvider = services.BuildServiceProvider();

            // �������� DbContext ��� using - �� ������ ���� �� ����� ������ ����������
            var dbContext = serviceProvider.GetRequiredService<AppDbContext>();

            // ������� �� ���� �� ����������
            dbContext.Database.EnsureCreated();

            // ��������� ������� ����
            Application.Run(new Form1(dbContext));

            // ����� �������� ���������� ����������� �������
            dbContext.Dispose();
            serviceProvider.Dispose();
        }
    }
}