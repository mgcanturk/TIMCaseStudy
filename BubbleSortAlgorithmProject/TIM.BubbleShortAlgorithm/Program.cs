using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TIM.BubbleShortAlgorithm.Abstract;
using TIM.BubbleShortAlgorithm.Concrete;

using IHost host = Host.CreateDefaultBuilder(args)
.ConfigureServices((_, services) =>
services.AddScoped<IBubbleSort, BubbleSort>())
.Build();

Test(host.Services);
await host.RunAsync();

static void Test(IServiceProvider services)
{
    using IServiceScope serviceScope = services.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;
    IBubbleSort service = provider.GetService<IBubbleSort>();

    int[] array = { 11, 93, 45, 98, 13, 55 };

    service.BubbleSortWithoutAnyOptimization(array);
    service.BubbleSortWithOptimization_V1(array);
    service.BubbleSortWithOptimization_V2(array);

    Console.ReadKey();
}
