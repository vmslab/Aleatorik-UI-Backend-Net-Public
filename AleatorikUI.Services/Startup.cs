using SqlBatis.DataMapper.DependencyInjection;
using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DAO.exp;
using AleatorikUI.Services.DAO.sys;
using AleatorikUI.Services.Configuration;
using AleatorikUI.Services.Authentication;

namespace AleatorikUI.Services;
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

        /**
         *        기준 정보 관리
         */
        services.AddSingleton<IMdmStageDao, MdmStageDao>();            // 스테이지
        services.AddSingleton<IMdmSiteDao, MdmSiteDao>();              // 사이트
        services.AddSingleton<IMdmAllocGroupDao,         MdmAllocGroupDao>();       // 할당그룹
        services.AddSingleton<IMdmFactoryOperDao,        MdmFactoryOperDao>();      // 공장운영정보 
        services.AddSingleton<IMdmCodeGroupDao,       MdmCodeGroupDao>();        // 코드 그룹
        /*
         services.AddSingleton<IMdmCodeGroupSub1Dao,      MdmCodeGroupSub1Dao>();    // 코드 관리
        services.AddSingleton<IMdmPropertyDao,           MdmPropertyDao>();         // 속성 관리
        /* -------------------------------------------------------------------------------------------- 
        services.AddSingleton<IMdmItemDao,               MdmItemDao>();                // 품목 정보
        services.AddSingleton<IMdmBufferDao,             MdmBufferDao>();              // 버퍼 정보
        services.AddSingleton<IMdmIsbDao,                MdmIsbDao>();                 // ISB 정보
        services.AddSingleton<IMdmBomDao,                MdmBomDao>();                 // BOM MASTER
        services.AddSingleton<IMdmBomSub1Dao,            MdmBomSub1Dao>();             // BOM DETAIL
        services.AddSingleton<IMdmBomSub2Dao,            MdmBomSub2Dao>();             // BOM DETAIL ALT
        services.AddSingleton<IMdmBomSub3Dao,            MdmBomSub3Dao>();             // BOM PROPERTY VALUE
        services.AddSingleton<IMdmRoutingDao,            MdmRoutingDao>();             // ROUTING MASTER
        services.AddSingleton<IMdmRoutingOperDao,        MdmRoutingOperDao>();         // ROUTING OPERATION
        services.AddSingleton<IMdmRoutingOperSub1Dao,    MdmRoutingOperSub1Dao>();    // ROUTING OPERATION PROPERTY VALUE
        services.AddSingleton<IMdmBomRoutingDao,         MdmBomRoutingDao>();          // BOM ROUTING
        services.AddSingleton<IMdmBomRoutingSub1Dao,     MdmBomRoutingSub1Dao>();     // BOM ROUTING PROPERTY VALUE
        /* -------------------------------------------------------------------------------------------- 
        services.AddSingleton<IMdmWipDao,                MdmWipDao>(); // 재공 정보
        /* --------------------------------------------------------------------------------------------
        services.AddSingleton<IMdmDemandDao,             MdmDemandDao>();              // DEMAND 정보
        services.AddSingleton<IMdmCustInfoDao,           MdmCustInfoDao>();            // 고객 정보
        /* --------------------------------------------------------------------------------------------- 
        services.AddSingleton<IMdmResourceDao,           MdmResourceDao>();            // RESOURCE MASTER
        services.AddSingleton<IMdmOperResourceDao,       MdmOperResourceDao>();        // OPERATION RESOURCE
        services.AddSingleton<IMdmOperResourceSub1Dao,   MdmOperResourceSub1>();   // OPERATION RESOURCE PROPERTY VALUE
        services.AddSingleton<IMdmConstInfoDao,          MdmConstInfoDao>();           // CONSTRAINT INFO
        services.AddSingleton<IMdmPmPlanDao,             MdmPmPlanDao>();              // PM PLAN
        services.AddSingleton<IMdmSetupInfoDao,          MdmSetupInfoDao>();           // SETUP INFO
        /* ---------------------------------------------------------------------------------------------
        services.AddSingleton<IMdmCalendarDao,           MdmCalendarDao>();            // 캘린더마스터
        services.AddSingleton<IMdmCalendarSub1Dao,       MdmCalendarSub1Dao>();       // 캘린더상세정보
        services.AddSingleton<IMdmCalendarSub2Dao,       MdmCalendarSub2Dao>();       // 캘린더속성값 관리
         */


        /**
         *        계획 관리
         */

        /**
         *        결과분석 및 리포트
         */

        /**
         *        입력/결과 데이터 조회
         */

        /**
         *        관리자 메뉴
         */
        services.AddSingleton<IUserDao, UserDao>();
        services.AddSingleton<IGroupDao, GroupDao>();
        services.AddSingleton<IMenuDao, MenuDao>();
        services.AddSingleton<IMenuMapDao, MenuMapDao>();
        /**
         *        예제
         */
        services.AddSingleton<ITodoDao, TodoDao>();
        services.AddSingleton<IGanttDao, GanttDao>();
      
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
