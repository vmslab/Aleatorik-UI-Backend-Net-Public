﻿using SqlBatis.DataMapper.DependencyInjection;
using AleatorikUI.Services.DAO.mdm;
using AleatorikUI.Services.DAO.exp;
using AleatorikUI.Services.Configuration;
using AleatorikUI.Services.Authentication;
using AleatorikUI.Services.DAO.sam;
using AleatorikUI.Services.DAO.iod;
using Microsoft.OpenApi.Models;

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
        //services.AddSwaggerGen();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("api", new OpenApiInfo
            {
                Title = "Aleatorik UI Service Api",
                Description = "Aleatorik UI Api 문서",
                Contact = new OpenApiContact
                {
                    Name = "서버 정보",
                    Email = string.Empty,
                    Url = new Uri("http://localhost:5235")
                }
                
            });
            c.SwaggerDoc("admin", new OpenApiInfo
            {
                Title = "관리자 Title",
                Description = "관리자 DESC",
                Contact = new OpenApiContact
                {
                    Name = "서버 정보 - Server Gitlab",
                    Email = string.Empty,
                    Url = new Uri("http://000.000.000.000")
                }
            });
        });
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
        services.AddSingletonWithNamedMapper<IMdmFactoryMasterDao, MdmFactoryMasterDao>(sMode);                 // 공장운영정보 
        services.AddSingletonWithNamedMapper<IMdmCodeGroupMasterDao, MdmCodeGroupMasterDao>(sMode);             // 코드 그룹, 코드 관리
        services.AddSingletonWithNamedMapper<IMdmPropMasterDao, MdmPropMasterDao>(sMode);                       // 속성 관리
        /* -------------------------------------------------------------------------------------------- */
        services.AddSingletonWithNamedMapper<IMdmItemMasterDao, MdmItemMasterDao>(sMode);                       // 품목 정보
        services.AddSingletonWithNamedMapper<IMdmBufferMasterDao, MdmBufferMasterDao>(sMode);                   // 버퍼 정보
        services.AddSingletonWithNamedMapper<IMdmIsbMasterDao, MdmIsbMasterDao>(sMode);                         // ISB 정보
        services.AddSingletonWithNamedMapper<IMdmBomMasterDao, MdmBomMasterDao>(sMode);                         // BOM MASTER, DETAIL, DETAIL ALT, PROPERTY VALUE, BOM ROUTING, BOM ROUTING PROPERTY VALUE
        services.AddSingletonWithNamedMapper<IMdmRoutingMasterDao, MdmRoutingMasterDao>(sMode);                 // ROUTING MASTER, ROUTING OPERATION, ROUTING OPERATION PROPERTY VALUE 
        /* -------------------------------------------------------------------------------------------- */
        services.AddSingletonWithNamedMapper<IMdmWipDao, MdmWipDao>(sMode);                                     // 재공 정보
        /* -------------------------------------------------------------------------------------------- */
        services.AddSingletonWithNamedMapper<IMdmCustInfoDao, MdmCustInfoDao>(sMode);                           // 고객 정보
        services.AddSingletonWithNamedMapper<IMdmDemandDao, MdmDemandDao>(sMode);                               // DEMAND 정보
        /* -------------------------------------------------------------------------------------------- */
        services.AddSingletonWithNamedMapper<IMdmResGroupMasterDao, MdmResGroupMasterDao>(sMode);               // RESOURCE GROUP MASTER
        services.AddSingletonWithNamedMapper<IMdmResMasterDao, MdmResMasterDao>(sMode);                         // RESOURCE MASTER
        services.AddSingletonWithNamedMapper<IMdmOperResMasterDao, MdmOperResMasterDao>(sMode);                 // OPERATION RESOURCE, OPERATION RESOURCE PROPERTY VALUE
        services.AddSingletonWithNamedMapper<IMdmConstInfoDao, MdmConstInfoDao>(sMode);                         // CONSTRAINT INFO
        services.AddSingletonWithNamedMapper<IMdmPmPlanDao, MdmPmPlanDao>(sMode);                               // PM PLAN
        services.AddSingletonWithNamedMapper<IMdmSetupInfoDao, MdmSetupInfoDao>(sMode);                         // SETUP INFO
/* ---------------------------------------------------------------------------------------------
services.AddSingletonWithNamedMapper<IMdmCalendarDao,           MdmCalendarDao>();            // 캘린더마스터
services.AddSingletonWithNamedMapper<IMdmCalendarSub1Dao,       MdmCalendarSub1Dao>();       // 캘린더상세정보
services.AddSingletonWithNamedMapper<IMdmCalendarSub2Dao,       MdmCalendarSub2Dao>();       // 캘린더속성값 관리
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
        services.AddSingletonWithNamedMapper<ISamUserDao, SamUserDao>(sMode);
        services.AddSingletonWithNamedMapper<ISamGroupDao, SamGroupDao>(sMode);
        services.AddSingletonWithNamedMapper<ISamMenuDao, SamMenuDao>(sMode);
        services.AddSingletonWithNamedMapper<ISamMenuMapDao, SamMenuMapDao>(sMode);
        /**
         *        예제
         */
        services.AddSingletonWithNamedMapper<ITodoDao, TodoDao>(sMode) ;
        services.AddSingletonWithNamedMapper<IGanttDao, GanttDao>(sMode);
      
        // 접속 DB 선택
        services.AddSqlMapper("PRODT", options => Configuration.GetSection("DB-Aleatorik").Bind(options));
        services.AddSqlMapper("DEV",   options => Configuration.GetSection("DB-Dev").Bind(options));
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
            //app.UseSwaggerUI();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/api/swagger.json", "API Documents");
                c.SwaggerEndpoint("/swagger/admin/swagger.json", "Admin Documents");
            });
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
