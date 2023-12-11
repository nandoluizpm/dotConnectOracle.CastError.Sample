using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DotConnectOracle.CastError.Sample.Contexts;
using DotConnectOracle.CastError.Sample.Entities;

var services = new ServiceCollection();
services.AddDbContext<ApplicationContext>();
var serviceProvider = services.BuildServiceProvider();

using var scope = serviceProvider.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

var municipio = await DoesntWorkInVersion10_2_0_7();

async Task<Entity> WorksInVersion10_2_0_7()
{
    var value = Unused.No;
    return await dbContext.Set<Entity>().FirstOrDefaultAsync(x => Equals(x.Unused, value));
}

// But works in version 10.0.0
async Task<Entity> DoesntWorkInVersion10_2_0_7()
    => await dbContext.Set<Entity>().FirstOrDefaultAsync(x => Equals(x.Unused, Unused.No));

Console.WriteLine($"ID: {municipio?.Id}");