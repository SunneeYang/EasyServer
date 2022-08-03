using EasyServer;
using EasyServer.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpcComponent();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcServices();
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
app.Map("/test", async () =>
{
    var client = app.Services.GetRequiredService<GreeterClient>();
    var reply = await client.SayHello("World");
    return $"Greeting: {reply}";
});

app.Run();