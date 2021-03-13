using System;
using System.IO;
using System.Net;
using System.Reflection;
using BuyService.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Debugging;
using Serilog.Formatting.Elasticsearch;
using Serilog.Sinks.Elasticsearch;

namespace BuyService
{
    public class Program
    {
        [Obsolete]
        public static void Main(string[] args)
        {
            ConfigureLogging();

            CreateHostBuilder(args).Build().Run();
        }

        [Obsolete]
        private static void ConfigureLogging()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile(
                    $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
                    optional: true)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Elasticsearch(ConfigureElasticSink(configuration, environment))
                .Enrich.CustomerLogEnricher()
                .Enrich.WithProperty("Environment", environment)
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            var file = File.CreateText("myFilePath");
            var writer = TextWriter.Synchronized(file);
            SelfLog.Enable(msg =>
            {
                writer.WriteLine(msg);
                writer.Flush();
            });
        }

        [Obsolete]
        private static ElasticsearchSinkOptions ConfigureElasticSink(IConfigurationRoot configuration, string environment)
        {
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST  
            // Get the IP  
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            string mainUri = myIP + ":" + configuration["ElasticConfiguration: Port"] + @"\";
            return new ElasticsearchSinkOptions(new Uri(mainUri))
            {
                AutoRegisterTemplate = true,
                //optional-Authorize Elastic Account
                //ModifyConnectionSettings = x => x.BasicAuthentication("elastic", "elastic"),
                IndexFormat = $"mytestindex",
                CustomFormatter = new ElasticsearchJsonFormatter(inlineFields: true),
                BufferBaseFilename = "./logs/buffer"
            };
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureAppConfiguration(configuration =>
                {
                    configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    configuration.AddJsonFile(
                        $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
                        optional: true);
                })
                .UseSerilog();

    }
}
