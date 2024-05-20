using Serilog.Events;
using Serilog;

namespace AdaTech.Api.Configuration
{
    public static class LoggingConfiguration
    {
        public static void UseCustomLogs(this IApplicationBuilder app, ILoggerFactory loggerFactory, IConfiguration configuration)
        {
            var newRelicSection = configuration.GetSection("NewRelic");
            var licenceKey = newRelicSection["LicenseKey"];

            var loggerConfiguration = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
                .WriteTo.Console();
                //.WriteTo.NewRelicLogs(
                //    applicationName: "ada-tech",
                //    licenseKey: licenceKey
                //);

            Log.Logger = loggerConfiguration.CreateLogger();

            loggerFactory.AddSerilog(Log.Logger);
        }
    }
}
