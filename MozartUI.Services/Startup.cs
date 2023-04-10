using MozartUI.Services.DAO;
using MozartUI.Services.Authentication;
using SqlBatis.DataMapper.DependencyInjection;
using MozartUI.Services.Configuration;

namespace MozartUI.Services;
public class Startup
{
    IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IConfiguration Configuration => _configuration;

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
        services.SetupLog(ref _configuration);
        services.AddJwtAuthentication(Configuration, true);

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddSingleton<ITodoDao, TodoDao>();
        services.AddSingleton<IUserDao, UserDao>();
        services.AddSingleton<IGroupDao, GroupDao>();
        services.AddSingleton<IGanttDao, GanttDao>();
        services.AddSingleton<IMenuDao, MenuDao>();
        services.AddSingleton<IMenuMapDao, MenuMapDao>();

        services.AddSqlMapper(options => Configuration.GetSection("DB").Bind(options));
        services.AddHttpContextAccessor();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app,
        IWebHostEnvironment env,
        IHostApplicationLifetime lifetime)
    {

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // Configure the HTTP request pipeline.
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
