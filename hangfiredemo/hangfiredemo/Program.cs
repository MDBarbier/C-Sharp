using System;
using Hangfire;
using Hangfire.SqlServer;

namespace hangfiredemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hangfire demo application started....");

            GlobalConfiguration.Configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseColouredConsoleLogProvider()
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(@"Server =.\SQLEXPRESS; Database =Hangfire.Sample; Integrated Security=True;", new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    UsePageLocksOnDequeue = true,
                    DisableGlobalLocks = true
                });

            BackgroundJob.Enqueue(() => Console.WriteLine("Hello, world! Coming to you via a background thread"));

            Console.WriteLine("Main thread execution finished");

            using (var server = new BackgroundJobServer())
            {
                Console.ReadLine();
            }
        }
    }
}
