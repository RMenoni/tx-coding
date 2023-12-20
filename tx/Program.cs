using tx.Interactors;
using tx.Repository;
using tx.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddTransient<IEntityRepository, EntityRepository>();
builder.Services.AddTransient<GetCabinetsInteractor, GetCabinetsInteractor>();
builder.Services.AddTransient<GetRowInteractor, GetRowInteractor>();
builder.Services.AddTransient<GetLaneInteractor, GetLaneInteractor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<ShelfService>();
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();