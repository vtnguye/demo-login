using Microsoft.Extensions.DependencyInjection;
using Service.Products;
using Service.Users;
using Service.Auth;
using Service.Repository;

namespace Service
{
    public static class DIServiceConfigure
    {
        public static void Setup(IServiceCollection services)
        {
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IJwtManager, JwtManager>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
