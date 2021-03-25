using Microsoft.Extensions.DependencyInjection;
using Service.Products;
using Service.Users;
using Service.Auth;
using Service.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace Service
{
    public static class DIServiceConfigure
    {
        public static void Setup(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = Configuration["Jwt:Issuer"],
        ValidAudience = Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
    };
});
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IJwtManager, JwtManager>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
