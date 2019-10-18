using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using MsCompany.Core;

namespace MsCompany
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseUrls("http://*:5110")
                .UseStartup<Startup>();

    }
}
