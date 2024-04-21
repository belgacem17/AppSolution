
using ApplicationLayerTest.Services;
using Business.IServices;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationLayerTest;

public static class HttpClientServiceStubsInjection
{
    public static void InjecterServicesStubs(IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
    }
}
