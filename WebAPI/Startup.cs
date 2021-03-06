using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Entity;
using Microsoft.AspNetCore.Identity;
using Entity.Models;
using WebAPI.Model.AuthOptions;
using WebAPI.Services;
using WebAPI.Services.Interfaces;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Entity.Repository;
using WebAPI.Middleware;
using Microsoft.Extensions.Logging;
using Entity.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using KeyVaultRead;
using Stripe;

namespace WebAPI
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
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(GetSecrets.ConnectionString), ServiceLifetime.Transient);
            
            // Repository
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IReport, ReportRepository>();
            services.AddScoped<IRepository<Payment>, SQLGenericRepository<Payment>>();
            services.AddScoped<IRepository<PaymentDetails>, SQLGenericRepository<PaymentDetails>>();
            services.AddScoped<IRepository<Entity.Models.Subscription>, SQLGenericRepository<Entity.Models.Subscription>>();

            // Services
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IPaymentService, PaymentService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddCors();

            //Identity 
            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 0;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-. ";
                options.User.RequireUniqueEmail = true;
            })
            .AddRoles<Role>()
            .AddRoleManager<RoleManager<Role>>()
            .AddEntityFrameworkStores<ApplicationContext>();

            // Auth
            var authOptionsConfiguration = Configuration.GetSection("Auth");
            services.Configure<AuthOptions>(authOptionsConfiguration);
            var authOptions = Configuration.GetSection("Auth").Get<AuthOptions>();

            services.ConfigureApplicationCookie(options =>
            {
                options.Events.OnRedirectToAccessDenied =
                    options.Events.OnRedirectToLogin = context =>
                    {
                        if (context.Request.Method != "GET")
                        {
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            return Task.FromResult<object>(null);
                        }
                        context.Response.Redirect(context.RedirectUri);
                        return Task.FromResult<object>(null);
                    };
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidIssuer = authOptions.Issuer,

                     ValidateAudience = true,
                     ValidAudience = authOptions.Audience,

                     ValidateLifetime = true,

                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = authOptions.GetSymmetricSecurityKey()
                 };
             });

            services.AddAuthorization();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            // @TODO refactor this with azure integration
            StripeConfiguration.ApiKey = GetSecrets.StripeSecretKey;

            System.Console.WriteLine(StripeConfiguration.ApiKey);

            loggerFactory.AddFile("Logs/App-{Date}.txt");

            if (env.IsDevelopment())
            {
                app.UseMiddleware<HandleExceptionMiddleware>();
                //@TO-DO uncomment this
            }
            else
            {
                app.UseDeveloperExceptionPage();  //@TO-DO uncomment this
            }

           // app.UseMiddleware<HandleExceptionMiddleware>(); // @TO-DO remove this, it's for testing only

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

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
}
