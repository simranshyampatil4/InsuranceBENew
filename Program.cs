using InsuranceApp.Data;
using InsuranceApp.Middleware;
using InsuranceApp.Repository;
using InsuranceApp.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

namespace InsuranceApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
            builder.Services.AddTransient(typeof(IEntityRepository<>), typeof(EntityRepository<>));
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IRoleService, RoleService>();

            builder.Services.AddTransient<IInsurancePlanService, InsurancePlanService>();
            builder.Services.AddTransient<IInsuranceSchemeService, InsuranceSchemeService>();
            builder.Services.AddTransient<ISchemeDetailsService, SchemeDetailsService>();
            builder.Services.AddTransient<IInsurancePolicyService, InsurancePolicyService>();

            builder.Services.AddTransient<IAdminService, AdminService>();

            builder.Services.AddTransient<IEmployeeService, EmployeeService>();
            builder.Services.AddTransient<IAgentService, AgentService>();
            builder.Services.AddTransient<ICustomerService, CustomerService>();
            builder.Services.AddTransient<IDocumentService, DocumentService>();
            builder.Services.AddTransient<IPaymentService, PaymentService>();
            builder.Services.AddTransient<IClaimService, ClaimService>();


            builder.Services.AddDbContext<MyContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("connString"));
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    builder.Configuration.GetSection("AppSettings:Token").Value!)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost4200",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader().AllowAnyMethod().WithExposedHeaders("*");
                    });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowLocalhost4200");
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.MapControllers();

            app.Run();
        }
    }
}