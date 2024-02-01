using DAL.Context.DesarrolloContext;
using System.Reflection;
using env;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("PublicMethod", builder =>
    {
        builder.WithOrigins("*")
            .AllowAnyHeader()
            .WithMethods("GET", "POST", "PUT", "DELETE")
            .SetIsOriginAllowedToAllowWildcardSubdomains();

    });
});



var oConfiguration = new ConfigurationBuilder()
.AddJsonFile("appsettings.json", optional: false)
.Build();
IConfigurationService.SetConfig(oConfiguration);


builder.Services.AddDbContext<DesarrolloContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString(string.Format("CHAD_{0}", oConfiguration["Ambiente"])));
});

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("en-us"); // o cualquier otra cultura que desees
});

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DesarrolloContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.WriteIndented = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
