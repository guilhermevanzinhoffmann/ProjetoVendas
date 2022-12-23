using ControleVendas.DBManager;
using ControleVendas.Items;
using ControleVendas.Repositories.Sales.SaleDirectors;
using ControleVendas.Repositories.Sales.SaleManagers;
using ControleVendas.Repositories.Sales.SaleNationalDirector;
using ControleVendas.Repositories.Sales.SaleSellers;
using ControleVendas.Repositories.Sellers;
using ControleVendas.Repositories.Unities;
using ControleVendas.Repositories.Users;
using ControleVendas.Services.SaleDirectors;
using ControleVendas.Services.SaleManagers;
using ControleVendas.Services.SaleNationalDirectors;
using ControleVendas.Services.Sales;
using ControleVendas.Services.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace ControleVendas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            var connectionString = builder.Configuration.GetConnectionString("postgres");

            builder.Services.AddDbContext<SalesContext>(options =>
                options.UseNpgsql(connectionString)
            );

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ISaleSellerRepository, SaleSellerRepository>();
            builder.Services.AddScoped<ISaleSellerService, SaleSellerService>();
            builder.Services.AddScoped<ISaleManagerRepository, SaleManagerRepository>();
            builder.Services.AddScoped<ISaleManagerService, SaleManagerService>();
            builder.Services.AddScoped<ISaleDirectorRepository, SaleDirectorRepository>();
            builder.Services.AddScoped<ISaleDirectorService, SaleDirectorService>();
            builder.Services.AddScoped<ISaleNationalDirectorRepository, SaleNationalDirectorRepository>();
            builder.Services.AddScoped<ISaleNationalDirectorService, SaleNationalDirectorService>();
            builder.Services.AddScoped<IUnitRepository, UnitRepository>();
            builder.Services.AddScoped<ISellerRepository, SellerRepository>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var key = Encoding.ASCII.GetBytes(Settings.Secret);

            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata= false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            builder.Services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiVendas", Version = "v1" });

                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme." +
                    " \r\n\r\n Enter 'Bearer'[space] and then your token in the text input below." +
                    "\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });

                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            Array.Empty<string>()
                        }
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

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();

           
        }
    }
}