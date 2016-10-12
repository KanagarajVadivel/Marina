using DatabaseSchemaReader;
using DatabaseSchemaReader.Compare;
using DbUp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Marina.DbUp
{
    class Program
    {
        static int Main(string[] args)
        {
            var connectionString = args.FirstOrDefault() ?? "Server=(local)\\SqlExpress; Database=Marina; Trusted_connection=true";

            if (ConfigurationManager.AppSettings["GenerateMigrationScript"] == "1")
            {
                var testConnectionString = "Server=(local)\\SqlExpress; Database=MarinaTest; Trusted_connection=true";
                EnsureDatabase.For.SqlDatabase(connectionString);

                var testUpgrader = DeployChanges.To
                  .SqlDatabase(testConnectionString)
                  .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                  .LogToConsole()
                  .Build();

                var testResult = testUpgrader.PerformUpgrade();

                if (!testResult.Successful)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error in creating test database");
                    Console.WriteLine(testResult.Error);
                    Console.ResetColor();
#if DEBUG
                    Console.ReadLine();
#endif
                    return -1;
                }

                var baseReader = new DatabaseReader(testConnectionString, "System.Data.SqlClient");
                var baseSchema = baseReader.ReadAll();
                //get the comparison schema
                var devReader = new DatabaseReader(connectionString, "System.Data.SqlClient");
                var devSchema = devReader.ReadAll();
                //compare
                var comparison = new CompareSchemas(baseSchema, devSchema);
                var script = comparison.Execute();

                var scriptDir = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName, "Scripts", DateTime.Now.ToString("dd-MM-yyyy-hh-mm") + ".sql");
                File.WriteAllText(scriptDir, script);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Migration File Successfully created. File saved under {0}. Please add to the solution and change to embedded source", scriptDir);
                Console.ResetColor();
                Console.ReadLine();
                return 0;
            }

            EnsureDatabase.For.SqlDatabase(connectionString);

            var upgrader = DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;
        }
    }
}
