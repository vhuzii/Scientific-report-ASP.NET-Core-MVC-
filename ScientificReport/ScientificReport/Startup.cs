using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rotativa.AspNetCore;
using ScientificReport.Data.DataAccess;
using ScientificReportData;
using ScientificReportData.Interfaces;
using ScientificReportData.Models;
using ScientificReportData.Repositories;
using ScientificReportServices;
using ScientificReportServices.Interfaces;

namespace ScientificReport
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var connection = @"Server=(localdb)\mssqllocaldb;Database=ScientificReport;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<ReportContext>
	            (options => options.UseSqlServer(connection));

            services.AddScoped<IRepository<Conference, int>, Repository<Conference, int>>();
            services.AddScoped<IRepository<DepartmentWork, int>, Repository<DepartmentWork, int>>();
            services.AddScoped<IRepository<Author, int>, Repository<Author, int>>();
            services.AddScoped<IRepository<Report, int>, Repository<Report, int>>();
            services.AddScoped<IRepository<Grant, int>, Repository<Grant, int>>();
            services.AddScoped<IRepository<User, string>, Repository<User, string>>();
            services.AddScoped<IRepository<Publication, int>, Repository<Publication, int>>();
<<<<<<< HEAD
            services.AddScoped<IRepository<ReportItem, int>, Repository<ReportItem, int>>();
=======
            
>>>>>>> develop
            services.AddScoped<UnitOfWork>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IConferenceService, ConferenceService>();
            services.AddScoped<DbContext, ReportContext>();
            services.AddTransient<IReportItemsService, ReportItemsService>();


            services.AddIdentity<User, IdentityRole>(opt =>            
            {

                opt.Password.RequireDigit = true;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredUniqueChars = 0;
                opt.Password.RequiredLength = 6;
            })
	            .AddEntityFrameworkStores<ReportContext>()
		   		.AddDefaultUI()
	            .AddDefaultTokenProviders();

            var serv = services.BuildServiceProvider();
            //CreateUserRoles(serv).Wait();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Report/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseAuthentication();
		   	app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Report}/{action=Index}/{id?}");
            });
            RotativaConfiguration.Setup(env);
		}

        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            //var UserManager = serviceProvider.GetRequiredService<UserService>();

            IdentityResult roleResult;
            var roleCheck = await RoleManager.RoleExistsAsync("Admin");
            if (!roleCheck)
            {
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
            }
            //IdentityUser user = await UserManager.FindByEmailAsync("admin@gmail.com");     <= use this to add admin rights -бодьо
            //await UserManager.AddToRoleAsync(user, "Admin");
        }
    }
}
