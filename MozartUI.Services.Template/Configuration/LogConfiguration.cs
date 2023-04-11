using Serilog;

namespace MozartUI.Services.Template;

public static class LogConfiguration
{
	public static void SetupLog(this IServiceCollection services, ref IConfiguration configuration)
	{
		Log.Logger = new LoggerConfiguration()
			.ReadFrom.Configuration(configuration)
			.Enrich.WithClientIp()
			.Enrich.WithClientAgent()
			.CreateLogger();
		using var serviceProvider = services.BuildServiceProvider();
		serviceProvider.GetService<ILoggerFactory>().AddSerilog();
	}
}