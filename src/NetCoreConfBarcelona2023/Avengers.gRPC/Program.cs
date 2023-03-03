using Avengers.API.Data;
using Avengers.API.Service;
using Avengers.gRPC.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddSingleton<IAvengerService, AvengerService>();
builder.Services.AddSingleton<AvengerDbContext>();
builder.Services
    .AddDbContextPool<AvengerDbContext>(o => o.UseInMemoryDatabase(Guid.NewGuid().ToString()));

var app = builder.Build();
app.MapGet("/", () => "Hello NetCoreConf Barcelona !!");
app.MapGrpcService<AvengerGrpcService>();

app.Run();