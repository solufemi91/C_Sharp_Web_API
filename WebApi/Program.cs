using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WebApi.Models;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {

            CreateWebHostBuilder(args).Build().Run();

            var container = new WindsorContainer();

            // Register the CompositionRoot type with the container
            container.Register(Component.For<IDataProvider>().ImplementedBy<IDataProvider>());

            // Resolve an object of type ICompositionRoot (ask the container for an instance)
            // This is analagous to calling new() in a non-IoC application.
            var root = container.Resolve<IDataProvider>();


            // Wait for user input so they can check the program's output.
            //Console.ReadLine();

            
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
