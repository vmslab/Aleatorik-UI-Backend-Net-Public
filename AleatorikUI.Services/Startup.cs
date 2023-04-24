using AleatorikUI.Services.Authentication;
using AleatorikUI.Services.Configuration;
using AleatorikUI.Services.DAO.exp;
using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DAO.rar;
using AleatorikUI.Services.DAO.plm;
using AleatorikUI.Services.DAO.sam;
using AleatorikUI.Services.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using SqlBatis.DataMapper.DependencyInjection;
using tusdotnet;

namespace AleatorikUI.Services;

/// <summary>
///  슬러쉬(/) 를 3번 입력하면 자동으로 주석 폼이 생성 됩니다.
///  주석 입력을 생활화 합시다.
/// </summary>
public class Startup
{
    IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IConfiguration Configuration => _configuration;

    /// <summary>
    /// This method gets called by the runtime. Use this method to add services to the container.
    /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    /// </summary>
    /// <param name="services"></param>
    public void ConfigureServices(IServiceCollection services)
    {
        services.SetupLog(ref _configuration);
        services.AddJwtAuthentication(Configuration, true);

        services.AddServerStateSocketService(Configuration);

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddApiVersioning(c => 
        {
            c.DefaultApiVersion = new ApiVersion(1, 0);
            c.AssumeDefaultVersionWhenUnspecified = true;
            c.ReportApiVersions = true;

            c.ApiVersionReader = new HeaderApiVersionReader("X-version");
        });

        services.AddSwaggerDocumentation();
    
        string sMode = "PRODT";

#if DEBUG
        sMode = "DEV";
#endif

        /**
         *        기준 정보 관리
         */
        services.AddSingletonWithNamedMapper<IMdmStageMasterDao, MdmStageMasterDao>(sMode);                     // 스테이지
        services.AddSingletonWithNamedMapper<IMdmSiteMasterDao, MdmSiteMasterDao>(sMode);                       // 사이트
        services.AddSingletonWithNamedMapper<IMdmAllocGroupMasterDao, MdmAllocGroupMasterDao>(sMode);           // 할당그룹
        services.AddSingletonWithNamedMapper<IMdmFactoryConfigDao, MdmFactoryConfigDao>(sMode);                 // 공장운영정보 
        services.AddSingletonWithNamedMapper<IMdmCodeCategoryMasterDao, MdmCodeCategoryMasterDao>(sMode);       // 코드 그룹, 코드 관리
        services.AddSingletonWithNamedMapper<IMdmPropMasterDao, MdmPropMasterDao>(sMode);                       // 속성 관리
        /* -------------------------------------------------------------------------------------------- */
        services.AddSingletonWithNamedMapper<IMdmItemMasterDao, MdmItemMasterDao>(sMode);                       // 품목 정보
        services.AddSingletonWithNamedMapper<IMdmBufferMasterDao, MdmBufferMasterDao>(sMode);                   // 버퍼 정보
        services.AddSingletonWithNamedMapper<IMdmItemSiteBufferMasterDao, MdmItemSiteBufferMasterDao>(sMode);   // ISB 정보
        services.AddSingletonWithNamedMapper<IMdmBomMasterDao, MdmBomMasterDao>(sMode);                         // BOM MASTER, DETAIL, DETAIL ALT, PROPERTY VALUE, BOM ROUTING, BOM ROUTING PROPERTY VALUE
        services.AddSingletonWithNamedMapper<IMdmRoutingMasterDao, MdmRoutingMasterDao>(sMode);                 // ROUTING MASTER, ROUTING OPERATION, ROUTING OPERATION PROPERTY VALUE 
        /* -------------------------------------------------------------------------------------------- */
        services.AddSingletonWithNamedMapper<IMdmWipDao, MdmWipDao>(sMode);                                     // 재공 정보
        /* -------------------------------------------------------------------------------------------- */
        services.AddSingletonWithNamedMapper<IMdmCustMasterDao, MdmCustMasterDao>(sMode);                       // 고객 정보
        services.AddSingletonWithNamedMapper<IMdmDemandDao, MdmDemandDao>(sMode);                               // DEMAND 정보
        /* -------------------------------------------------------------------------------------------- */
        services.AddSingletonWithNamedMapper<IMdmResGroupMasterDao, MdmResGroupMasterDao>(sMode);               // RESOURCE GROUP MASTER
        services.AddSingletonWithNamedMapper<IMdmResMasterDao, MdmResMasterDao>(sMode);                         // RESOURCE MASTER
        services.AddSingletonWithNamedMapper<IMdmOperResMasterDao, MdmOperResMasterDao>(sMode);                 // OPERATION RESOURCE, OPERATION RESOURCE PROPERTY VALUE
        services.AddSingletonWithNamedMapper<IMdmConstraintDao, MdmConstraintDao>(sMode);                       // CONSTRAINT INFO
        services.AddSingletonWithNamedMapper<IMdmPmPlanDao, MdmPmPlanDao>(sMode);                               // PM PLAN
        services.AddSingletonWithNamedMapper<IMdmSetupInfoDao, MdmSetupInfoDao>(sMode);                         // SETUP INFO
        /* --------------------------------------------------------------------------------------------- */
        services.AddSingletonWithNamedMapper<IMdmCalendarMasterDao, MdmCalendarMasterDao>(sMode);               // 캘린더마스터, 캘린더상세정보, 캘린더속성값 관리
        /* --------------------------------------------------------------------------------------------- */
        /**
         *        계획 관리
         */
        services.AddSingletonWithNamedMapper<IPlmFactorMasterDao, PlmFactorMasterDao>(sMode);                   // Factor 관리
        services.AddSingletonWithNamedMapper<IPlmPlanExecuteDao, PlmPlanExecuteDao>(sMode);

        /**
         *        결과분석 및 리포트
         */
        services.AddSingletonWithNamedMapper<IAorBomMapDao, AorBomMapDao>(sMode);                               // BOM Map View

        /**
         *        입력/결과 데이터 조회
         */

        /**
         *        관리자 메뉴
         */
        services.AddSingletonWithNamedMapper<ISamUserDao, SamUserDao>(sMode);
        services.AddSingletonWithNamedMapper<ISamGroupDao, SamGroupDao>(sMode);
        services.AddSingletonWithNamedMapper<ISamMenuDao, SamMenuDao>(sMode);
        services.AddSingletonWithNamedMapper<ISamMenuMapDao, SamMenuMapDao>(sMode);
        /* --------------------------------------------------------------------------------------------- */
        /**
         *        예제
         */
        services.AddSingletonWithNamedMapper<ITodoDao, TodoDao>(sMode);
        services.AddSingletonWithNamedMapper<IGanttDao, GanttDao>(sMode);
        services.AddSingletonWithNamedMapper<ITrEmployeeDao, TrEmployeeDao>(sMode);
        /* --------------------------------------------------------------------------------------------- */

        // 접속 DB 선택
        services.AddSqlMapper("PRODT", options => Configuration.GetSection("DB-Aleatorik").Bind(options));
        services.AddSqlMapper("DEV",   options => Configuration.GetSection("DB-Dev").Bind(options));
        services.AddHttpContextAccessor();
    }

    /// <summary>
    /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline. 
    /// </summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    /// <param name="lifetime"></param>
    /// <param name="provider"></param>
    public void Configure(IApplicationBuilder app,
        IWebHostEnvironment env,
        IHostApplicationLifetime lifetime,
        IApiVersionDescriptionProvider provider)
    {   
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwaggerDocumentation(provider);
        }

        // Configure the HTTP request pipeline.
        app.UseHttpsRedirection();

        app.UseWebSockets(new WebSocketOptions
        {
            KeepAliveInterval = TimeSpan.FromSeconds(120),
        });
        app.UseMiddleware<Middleware.ServerStateSocket.ServerStateSocketManager>();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseTus(TusHelper.CreateTusConfiguration);


        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
