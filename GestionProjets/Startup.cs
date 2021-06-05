using GestionProjets.Data;
using GestionProjets.DBContext;
using GestionProjets.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionProjets
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
               .AddRoles<IdentityRole>()
               .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddDbContext<QalitasContext>(o => o.UseSqlServer(Configuration.GetConnectionString("QalitasDB")));
            services.AddTransient<IProjetRepository, ProjetRepository>();
            services.AddTransient<ITacheRepository, TacheRepository>();
            services.AddTransient<ITypeProjetRepository, TypeProjetRepository>();
            services.AddTransient<IActionRepository, ActionRepository>();
            services.AddTransient<IPhaseRepository, PhaseRepository>();
            services.AddTransient<IAutorisationRepository, AutorisationRepository>();
            services.AddTransient<IEvaluationRepository, EvaluationRepository>();
            services.AddTransient<IIndicateurRepository, IndicateurRepository>();
            services.AddTransient<IMesureRepository, MesureRepository>();
            services.AddTransient<IObjectifRepository, ObjectifRepository>();
            services.AddTransient<IOpportuniteRepository, OpportuniteRepository>();
            services.AddTransient<IParametreRepository, ParametreRepository>();
            services.AddTransient<IReunionRepository, ReunionRepository>();
            services.AddTransient<IRisqueRepository, RisqueRepository>();
            services.AddTransient<IDocumentRepository, DocumentRepository>();
            services.AddTransient<IUtilisateurRepository, UtilisateurRepository>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddAuthentication(Options =>
            {
                Options.DefaultAuthenticateScheme = "JwtBearer";
                Options.DefaultChallengeScheme = "JwtBearer";

            })
                .AddJwtBearer("JwtBearer", JwtBearerOptions =>
                {
                    JwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("Secrets:SecurityKey"))),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromMinutes(5)
                    };

                });
         
            services.AddSwaggerGen(setup =>
            {
                setup.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                setup.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "Qalitas API",
                        Version = "v1"
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(x => { x.SwaggerEndpoint("/swagger/v1/swagger.json", "Qalitas API v1"); });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
