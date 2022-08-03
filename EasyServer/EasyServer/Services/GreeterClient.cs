namespace EasyServer.Services;

public class GreeterClient
{
    private readonly Greeter.GreeterClient _client;

    public GreeterClient(Greeter.GreeterClient client)
    {
        _client = client;
    }
    
    public async Task<string> SayHello(string name)
    {
        var result = await _client.SayHelloAsync(new HelloRequest { Name = name });
        return result.Message;
    }
}