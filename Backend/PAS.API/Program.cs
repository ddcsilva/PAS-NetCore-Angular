using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using PAS.API.Models;
using PAS.API.Profiles;
using PAS.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors((options) => {
    options.AddPolicy("AngularApplication", (builder) => {
        builder.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .WithMethods("GET", "POST", "PUT", "DELETE")
            .WithExposedHeaders("*");
    });
});

builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddDbContext<Context>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IEstudanteRepository, EstudanteRepository>();
builder.Services.AddScoped<IImagemRepository, ImagemLocalStorageRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AngularApplication");

app.UseHttpsRedirection();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Resources")),
    RequestPath = new PathString("/Resources")
});

app.UseAuthorization();

app.MapControllers();

app.Run();
