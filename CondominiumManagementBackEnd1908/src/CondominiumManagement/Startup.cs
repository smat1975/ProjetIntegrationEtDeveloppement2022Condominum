using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Validators;
//using Microsoft.OpenApi.Models;
//using Swashbuckle.AspNetCore.Swagger;
//using Swashbuckle.AspNetCore.SwaggerGen;
//using Swashbuckle.AspNetCore.Newtonsoft;
using Microsoft.Extensions.Http;
//using Polly.Extensions.Http;
//using Polly;
using System.Net.Http;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
/*using Microsoft.AspNetCore.Authentication.OpenIdConnect;*/
using Microsoft.AspNetCore.Http;
using CondominiumManagement.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using DAL.EFEntities;
using DAL.EFContext;
using Microsoft.AspNetCore.Mvc;

namespace CondominiumManagement
{
    public class Startup
    {
        //private readonly string versionAPI = "V1 - 01/06/2022";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.ConfigureSameSiteNoneCookies();

            // Add authentication services
            /*services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })*/
            /*.AddCookie()
            .AddOpenIdConnect("Auth0", options => {
                // Set the authority to your Auth0 domain
                options.Authority = $"https://{Configuration["Auth0:Domain"]}";

                // Configure the Auth0 Client ID and Client Secret
                options.ClientId = Configuration["Auth0:ClientId"];
                options.ClientSecret = Configuration["Auth0:ClientSecret"];

                // Set response type to code
                options.ResponseType = OpenIdConnectResponseType.Code;

                // Configure the scope
                options.Scope.Clear();
                options.Scope.Add("openid");

                // Set the callback path, so Auth0 will call back to http://localhost:3000/callback
                // Also ensure that you have added the URL as an Allowed Callback URL in your Auth0 dashboard
                options.CallbackPath = new PathString("/callback");

                // Configure the Claims Issuer to be Auth0
                options.ClaimsIssuer = "Auth0";

                // Saves tokens to the AuthenticationProperties
                options.SaveTokens = true;

                options.Events = new OpenIdConnectEvents
                {
                    // handle the logout redirection 
                    OnRedirectToIdentityProviderForSignOut = (context) =>
                    {
                        var logoutUri = $"https://{Configuration["Auth0:Domain"]}/v2/logout?client_id={Configuration["Auth0:ClientId"]}";

                        var postLogoutUri = context.Properties.RedirectUri;
                        if (!string.IsNullOrEmpty(postLogoutUri))
                        {
                            if (postLogoutUri.StartsWith("/"))
                            {
                                // transform to absolute
                                var request = context.Request;
                                postLogoutUri = request.Scheme + "://" + request.Host + request.PathBase + postLogoutUri;
                            }
                            logoutUri += $"&returnTo={ Uri.EscapeDataString(postLogoutUri)}";
                        }

                        context.Response.Redirect(logoutUri);
                        context.HandleResponse();

                        return Task.CompletedTask;
                    }
                };
            })*/;


            //services.AddMvc().AddFluentValidation();
            services.AddMvc().AddSessionStateTempDataProvider();

            services.AddSession();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<CondominiumMgtContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection"),
                   //Modif pour CQRS et MediatR
                   b => b.MigrationsAssembly(typeof(CondominiumMgtContext).Assembly.FullName)));

            services.AddControllers(opt =>
            {
                opt.ReturnHttpNotAcceptable = true;
            })
            //.AddNewtonsoftJson(cfg => cfg.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize);
            .AddNewtonsoftJson(cfg => cfg.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
            Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //A garder
            services.AddControllersWithViews();
            //services.AddRazorPages();
            //

            /*"CondominiumManagement"*/

            //services.AddHttpClient("WebSite");
            /*.SetHandlerLifetime(TimeSpan.FromMinutes(5))  //Set lifetime to five minutes
            .AddPolicyHandler(GetRetryPolicy());*/

            /*services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = versionAPI, Description = "API CondominiumManagement Appl" });

                /*var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });*/


            /*services.AddTransient<IValidator<Domain.Models.Entities.Message>, MessageValidator>();
            services.AddTransient<IValidator<Domain.Models.Entities.Utilisateur>, UtilisateurValidator>();
            services.AddTransient<IValidator<Domain.Models.Entities.Destination>, DestinationValidator>();
            services.AddTransient<IValidator<Domain.Models.Entities.Piece>, PieceValidator>();
            services.AddTransient<IValidator<Domain.Models.Entities.Annexe>, AnnexeValidator>();*/
            //services.AddTransient<IValidator<Message>, MessageValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseLogRequestMiddleware();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //!\\ A modifier !!//
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //Enable middleware to serve generated Swagger as a JSON endpoint.        
            //app.UseSwagger();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();

            app.UseCookiePolicy();
            app.UseCors();
            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();



            //Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),        
            // specifying the Swagger JSON endpoint.        
            /*app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
            });*/

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        /*private IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                // HttpRequestException, 5XX and 408  
                .HandleTransientHttpError()
                // 404  
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                // Retry two times after delay  
                .WaitAndRetryAsync(2, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
                ;
        }*/
    }

}

//-Version de base

