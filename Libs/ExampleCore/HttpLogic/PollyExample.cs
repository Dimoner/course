using Microsoft.IdentityModel.Logging;
using Polly;

namespace ExampleCore.HttpLogic;

public class PollyExample
{
    public static async Task<string> ActionAsync()
    {
        var res = await Policy
            .Handle<Exception>()
            .WaitAndRetryForeverAsync(
                i => TimeSpan.FromSeconds(5 + i), (result, retryCount, _) =>
            {
                Console.WriteLine($"Начало {retryCount} Попытки повтора");
                return Task.CompletedTask;
            })
            .ExecuteAsync<string>(async () =>
            {
                return "hello world";
            });

        return res;
    }
}