using System;
using System.IO;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Extensions.Configuration;
using IContainer = System.ComponentModel.IContainer;

namespace Github.ProjectManager.Runner
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json", false);

            var configuration = builder.Build();

            var app = new Application.Application(configuration);
            await app.Start();
        }
    }
}