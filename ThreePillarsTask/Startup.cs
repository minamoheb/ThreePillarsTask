using AutoMapper;
using Project.Core.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Project.Core.Data;
using Project.Services.Mapping;
using RepositoryLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Project.Services.ModalServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Project.Services.AuthenticationManagment;
using Project.Services.Handler;
using Project.Services.Helper.ErrorHandler;
using ThreePillarsTask.Middlewares;
using Microsoft.OpenApi.Models;
using RepositoryLayer.Repository;

namespace ThreePillarsTask
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region *****inject dbContext*****
            services.AddDbContext<SystemDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton);
            services.AddScoped<DbContext, SystemDBContext>();
            #endregion
            #region ***** inject identity *****
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);

            })
           .AddEntityFrameworkStores<SystemDBContext>()
           .AddDefaultTokenProviders();
            #endregion
            #region *****jwt Configuration*****
            var jwtSetting = new JwtSetting();
            Configuration.Bind(key: nameof(jwtSetting), jwtSetting);
            services.AddSingleton(jwtSetting);
            services.AddAuthentication(configureOptions: x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
              .AddJwtBearer(options =>
              {
                  options.SaveToken = true;
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      // temporary false untill finishing implementaton
                      ValidateIssuer = false,
                      ValidateAudience = false,
                      RequireExpirationTime = false,

                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,
                      ValidIssuer = jwtSetting.Issuer/*  Configuration["JwtSetting:Issuer"]*/,
                      ValidAudience = Configuration["JwtSetting:Issuer"],
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSetting:Secret"]))
                  };
              });
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                  .RequireAuthenticatedUser()
                  .Build();
            });
            services.Configure<DataProtectionTokenProviderOptions>(opt =>
             opt.TokenLifespan = TimeSpan.FromDays(7));
            #endregion
            //inject BL
            #region *****inject Services*****
            services.AddScoped<JobTittleCommand>();
            services.AddScoped<DepartmentCommand>();
            services.AddScoped<AddressBookCommand>();
            services.AddScoped<ILogErrorHandler, LogErrorHandler>();
            services.AddScoped<IAuthenticationServices, AuthenticationServices>();
            services.AddScoped<IUserManager, UserManager>();
            //services.AddScoped<UserManager>();
            #endregion
            #region *****Unit Of Work*****

            services.AddScoped<IUnitOfWork<SystemDBContext>, UnitOfWork<SystemDBContext>>();
            #endregion
            // Auto Mapper Configurations
            #region ***** Mapper *****
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            #endregion

            #region  *********** Sawager******
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Place Info Service API",
                    Version = "v2",
                    Description = "Sample service for Learner",
                });
            });

            #endregion
            services.AddCors();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
             .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());
            services.AddOptions();
            services.AddControllersWithViews();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.ConfigureCustomExceptionMiddleware();
            }
            else
            {
                app.ConfigureCustomExceptionMiddleware();
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseRouting();
            app.UseCors(builder => builder.WithOrigins("*")
                      .AllowAnyMethod()
                     .AllowAnyHeader()
         //.AllowCredentials());
         );
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseSpaStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v2/swagger.json", "PlaceInfo Services"));
        }
    }
}
