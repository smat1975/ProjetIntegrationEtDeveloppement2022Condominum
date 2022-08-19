using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
//using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using DAL.EFEntities;
using DAL.EFContext;
using CondominiumManagement;
using CondominiumManagement.Repositories.Interfaces;
using CondominiumManagement.Repositories;
using CondominiumManagement.Services;
using BackEndAPI.Handlers.ViewModels;

namespace BackEndAPI
{
    public class Startup
    {

        //private readonly string versionAPI = "V1 - 01/06/2022";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //Version prof 24/11
            //Rem: Préconfig pour installer OAuth sécu sur la partie API
            /*var domain = $"https://{Configuration["Auth0:Domain"]}/";
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = domain;
                options.Audience = Configuration["Auth0:Audience"];
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("read:messages", policy => policy.Requirements.Add(new HasScopeRequirement("read:messages", domain)));
            });

            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();*/
            //

            //CondominiumManagementContext
            services.AddMvc().AddFluentValidation();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDbContext<CondominiumMgtContext>(options =>
              options.UseSqlServer(
                  Configuration.GetConnectionString("DefaultConnection"),
                  //Modif pour CQRS et MediatR à supprimer
                  b => b.MigrationsAssembly(typeof(CondominiumMgtContext).Assembly.FullName)));

            /*Ancienne version avant le problème de reference loop
            services.AddControllers(opt =>
            {
                opt.ReturnHttpNotAcceptable = true;
            })
            .AddNewtonsoftJson();*/

            services.AddControllers(opt =>
            {
                opt.ReturnHttpNotAcceptable = true;
            })
            //.AddNewtonsoftJson(cfg => cfg.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize);
            .AddNewtonsoftJson(cfg => cfg.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<ICoproprietairesRepository, CoproprietairesRepository>();
            services.AddScoped<IMessagesRepository, MessagesRepository>();
            services.AddScoped<IAnnexesRepository, AnnexesRepository>();
            services.AddScoped<ICodesPcmnRepository, CodesPcmnRepository>();
            services.AddScoped<IComptesBqueRepository, ComptesBqueRepository>();
            services.AddScoped<ICoproprietesRepository, CoproprietesRepository>();
            services.AddScoped<IDecomptesRepository, DecomptesRepository>();
            services.AddScoped<IDestinationsRepository, DestinationsRepository>();
            services.AddScoped<IDocumentsFournisseursRepository, DocumentsFournisseursRepository>();
            services.AddScoped<IFournisseursRepository, FournisseursRepository>();
            services.AddScoped<IGroupementsRepository, GroupementsRepository>();
            services.AddScoped<IGroupesRepository, GroupesRepository>();
            services.AddScoped<ILignesDecomptesRepository, LignesDecomptesRepository>();
            services.AddScoped<ILignesDocumentsFournisseursRepository, LignesDocumentsFournisseursRepository>();
            services.AddScoped<ILocalisationsRepository, LocalisationsRepository>();
            services.AddScoped<ILotsRepository, LotsRepository>();
            services.AddScoped<IMatchingsPaiementsRepository, MatchingsPaiementsRepository>();
            services.AddScoped<IPaiementsRepository, PaiementsRepository>();
            services.AddScoped<IPeriodesRepository, PeriodesRepository>();
            services.AddScoped<IPhotosRepository, PhotosRepository>();
            services.AddScoped<IQuotitesRepository, QuotitesRepository>();
            services.AddScoped<IRaisonsClotureRepository, RaisonsClotureRepository>();
            services.AddScoped<ITypesLotRepository, TypesLotRepository>();
            services.AddScoped<ITypesTvaRepository, TypesTvaRepository>();

            services.AddScoped<IVuesHandlingRepository, VuesHandlingRepository>();

            services.AddTransient<IMailService, NullMailService>();

            //services.AddTransient<IValidator<Domain.Models.Entities.Message>, MessageValidator>();
            //A Vérifier Models.Entities ou Models tout court????!!!!

            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowOrigin",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });





            /*services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = versionAPI, Description = "API CondominiumManagement Appl" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Enable middleware to serve generated Swagger as a JSON endpoint.        
            //app.UseSwagger();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowOrigin");

            //Rem: Préconfig pour installer OAuth sécu sur la partie API
            app.UseAuthentication();
            app.UseAuthorization();

            /*app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });*/

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),        
            // specifying the Swagger JSON endpoint.        
            /*app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
                c.RoutePrefix = string.Empty;
            });*/

            //Version secu 2019
            //Ca peut servir pour l'authentification!
            //Configuration d'un cookie pour l'authentification
            /*app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationScheme = "MyCookie",
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                LoginPath = new PathString("/account/login")
            });*/
            //app.UseMvcWithDefaultRoute();
            


            //Commentaire :
            /*One important thing to be aware of is that all the middleware will have access to an instance of HttpContext. 
            It is through this instance that they can “send” messages to each other. For example, if a middleware at the end of the pipeline 
            changes HttpContext by doing something like HttpContext.Items["LoginProvider"] = "Google", all the middleware that precedes it 
            will be able to access that value.*/






        }
    }
}

