using MozartUI.Services;

Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
    })
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.ConfigureAppConfiguration((hostingContext, configBuilder) =>
        {
            var env = hostingContext.HostingEnvironment;
            var os = Environment.OSVersion;
            configBuilder
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.{os.Platform}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
        })
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseStartup<Startup>();
    })
    .Build()
    .Run();