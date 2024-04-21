
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using FluentAssertions;
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Text;

namespace ApplicationLayerTest;

public class HttpClientSetup
{
    public HttpClientSetup()
    {
       var appFactory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {


                    // Récupérer le DbContext
                    ServiceProvider sp = services.BuildServiceProvider();
                    IServiceScope scope = sp.CreateScope();
                    IServiceProvider scopedServices = scope.ServiceProvider;

                    HttpClientServiceStubsInjection.InjecterServicesStubs(services);

                });
            });

        TestClient = appFactory.CreateClient();
        TestClient.BaseAddress = new Uri("https://localhost:7209/api/");
    }

    public HttpClient TestClient { get; }

    public  HttpRequestMessage GetHttpRequestMessage(HttpMethod httpMethod, string requestUri, object objetAConvertir)
    {
        string jsonStream = Serialiser(objetAConvertir);
        var content = new StringContent(jsonStream, Encoding.UTF8, "application/json");
        return new HttpRequestMessage(httpMethod, requestUri) { Content = content };
    }
    public static string Serialiser<T>(T objet)
    {
        var settings = new Newtonsoft.Json.JsonSerializerSettings
        {
            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
        };

        return Newtonsoft.Json.JsonConvert.SerializeObject(objet, settings);
    }
}
