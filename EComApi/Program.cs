using EComApi.Database;
using EComApi.Mappings;
using EComApi.Services.AttributeManager;
using EComApi.Services.ProductManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AttributeProfile));
builder.Services.AddDbContext<ApplicationContext>(options => options.
       UseNpgsql(builder.Configuration.GetConnectionString("PgConnection")));

builder.Services.AddScoped<IAttributeManagerService, AttributeManagerService>();
builder.Services.AddScoped<IProductManagerService, ProductManagerService>();
builder.Services.AddCors();

var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseCors(builder => builder.WithOrigins("http://localhost:3000")
.AllowAnyHeader()
.AllowAnyMethod()
.AllowAnyOrigin());
CreateDbIfNotExists(app);

// Configure the HTTP request pipeline.
if (true)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void CreateDbIfNotExists(IHost host)
{
    using (var scope = host.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<ApplicationContext>();
            //context.Database.EnsureDeleted();
            var exist = context.Database.EnsureCreated();
            context.Database.Migrate();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred creating the DB.");
        }
    }
}