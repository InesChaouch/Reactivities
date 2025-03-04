using application.Activities.Queries;
using application.Core;
using Microsoft.EntityFrameworkCore;
using persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(opt => {
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddMediatR(x => 
    x.RegisterServicesFromAssemblyContaining<GetActivityList.Handler>());
builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try {
    var context = services.GetRequiredService<AppDbContext>();
    await context.Database.MigrateAsync();
    await DbInitializer.SeedData(context);
}
catch (Exception ex) {
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred during migration");
}

app.Run();