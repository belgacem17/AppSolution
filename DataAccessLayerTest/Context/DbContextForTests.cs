using DomainLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;

namespace DataAccessLayerTest.Context
{
    public static class DbContextForTests
    {
        public static AppSolutionDBContext CreerContext()
        {
            string connectionString = GetConnectionStringDeTest();

            var optionsBuilder = new DbContextOptionsBuilder<AppSolutionDBContext>();
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.EnableDetailedErrors(true);
            optionsBuilder.LogTo(message => Debug.WriteLine(message));

            return new AppSolutionDBContext(optionsBuilder.Options);
        }

        public static string GetConnectionStringDeTest()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            return config["ConnectionStrings:appSolutionDBTest"];
        }
    }
}
