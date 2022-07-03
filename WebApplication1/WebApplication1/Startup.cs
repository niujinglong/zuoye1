using ClassLibraryEF;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RbacApplication;
using RbacApplication.Admin;
using RbacApplication.Role;
using RbacRepository;
using RbacRepository.Admin;
using RbacRepository.MenuRole;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1
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

            services.AddControllers();
            services.AddAutoMapper(Assembly.Load("RbacApplication"));
            //������
            services.AddDbContext<MyDbContext>(s => s.UseSqlServer(Configuration.GetConnectionString("sqlserver")));
            //ע��
            services.AddScoped<Irepository,Repository>();
            services.AddScoped<Iapplication, Application>();
            services.AddScoped<IRoleDto, RbacRepository.Role.RoleDto>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IAdminDto, RbacRepository.Admin.AdminDto>();
            services.AddScoped<IMenuRoleRepository, MenuRoleRepository>();

            services.AddCors(s => {
                s.AddPolicy("cors", a =>
                {
                    a.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                });
            });

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(
            option =>
            {
                //Token��֤����
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    //�Ƿ���֤������
                    ValidateIssuer = true,
                    ValidIssuer = Configuration["JwtConfig:Issuer"],//������

                    //�Ƿ���֤������
                    ValidateAudience = true,
                    ValidAudience = Configuration["JwtConfig:Audience"],//������

                    //�Ƿ���֤��Կ
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtConfig:key"])),

                    ValidateLifetime = true, //��֤��������

                    RequireExpirationTime = true, //����ʱ��

                    ClockSkew = TimeSpan.Zero   //ƽ������ƫ��ʱ��
                };
            }
);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication1", Version = "v1" });

                //����Ȩ��С��
                options.OperationFilter<AddResponseHeadersFilter>();
                options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                options.OperationFilter<SecurityRequirementsOperationFilter>();

                //��header�����token�����ݵ���̨
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT��Ȩ(���ݽ�������ͷ�н��д���)ֱ���������������Bearer {token}(ע������֮����һ���ո�) \"",
                    Name = "Authorization",//jwtĬ�ϵĲ�������
                    In = ParameterLocation.Header,//jwtĬ�ϴ��Authorization��Ϣ��λ��(����ͷ��)
                    Type = SecuritySchemeType.ApiKey
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication1 v1"));
            }
            app.UseCors("cors");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
