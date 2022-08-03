namespace EasyServer.Services;

public static class GrpcComponentExtensions
{
    public static void AddGrpcComponent(this IServiceCollection services)
    {
        services.AddGrpc();
        services.AddGrpcReflection();
        services.AddGrpcClient<Greeter.GreeterClient>(o => o.Address = new Uri("http://localhost:5136"));
        services.AddSingleton<GreeterClient>();
    }

    public static void MapGrpcServices(this WebApplication app)
    {
        app.MapGrpcService<GreeterService>();

        if (app.Environment.IsDevelopment())
        {
            app.MapGrpcReflectionService();
        }
    }
}

public class GrpcComponent
{
     
}