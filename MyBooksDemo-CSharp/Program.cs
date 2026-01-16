using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MyBooksDemo_CSharp;
using MyBooksDemo_CSharp.Data;
using MyBooksDemo_CSharp.Data.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
Startup startup = new(builder.Configuration);
string? ConnectionString = startup.ConnectionString;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//Configure DBContext with SQL
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(ConnectionString));

//Configure the services
builder.Services.AddTransient<BooksService>();
builder.Services.AddTransient<AuthorsService>();
builder.Services.AddTransient<PublishersService>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v2", new OpenApiInfo { Title = "MyBooksDemo-CSharp_Updated", Version = "v2" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        c => c.SwaggerEndpoint("/swagger/v2/swagger.json", "MyBooksDemo-CSharp_updates v2")
    );
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//AppDbInitializer.Seed(app);

app.Run();
