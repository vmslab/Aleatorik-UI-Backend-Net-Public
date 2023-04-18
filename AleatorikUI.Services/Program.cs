using AleatorikUI.Services;

Host.CreateDefaultBuilder(args)
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

            SetupKestrel.Configure(webBuilder, configBuilder.Build());

        })
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseStartup<Startup>();
    })
    .Build()
    .Run();