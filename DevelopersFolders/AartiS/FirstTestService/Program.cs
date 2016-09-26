using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace FirstTestService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*var config = new ConfigurationBuilder()
                //.AddCommandLine(args)
                .AddEnvironmentVariables(prefix: "ASPNETCORE_")
                .AddJsonFile("hosting.json", optional: true)
                .Build();
            
            var host = new WebHostBuilder()
                .UseConfiguration(config)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();*/

            /*
            The above code use three bindings: "http://*:1000", "https://*:1234", "http://0.0.0.0:5000" 
            by default instead of usage the default port 5000 by default 
            (to be exact the usage of http://localhost:5000). 
            The call of .UseConfiguration(config) are made after .UseUrls. 
            Thus the configuration loaded from hosting.json or the command line 
            overwrite the default options. 
            If one remove .SetBasePath(Directory.GetCurrentDirectory()) 
            line then the hosting.json will be loaded from the same directory 
            where the application dll will be compiled (for example bin\Debug\netcoreapp1.0).
            */

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                //.AddJsonFile("hosting.json", optional: true)
                .AddEnvironmentVariables(prefix: "ASPNETCORE_")
                .AddCommandLine(args)
                .Build(); 

            var host = new WebHostBuilder()
                //.UseUrls("http://*:1000", "https://*:1234") 
                .UseEnvironment("Development")
                .UseConfiguration(config)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

                host.Run();
        }
    }
}
