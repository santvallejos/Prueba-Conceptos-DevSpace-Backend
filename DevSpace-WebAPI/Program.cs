using DevSpace_DataAccessLayer.Models;
using DevSpace_DataAccessLayer.Repositories.Collection;
using DevSpace_DataAccessLayer.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<FolderServices>();
builder.Services.AddScoped<ResourceServices>();

//Configuracion de MongoDB
builder.Services.AddSingleton<IMongoClient>(new MongoClient("mongodb://localhost:27017/DevSpace"));
builder.Services.AddSingleton<IMongoDatabase>(sp => sp.GetService<IMongoClient>()!.GetDatabase("Unity"));

//Repositorios
builder.Services.AddScoped<IFolderCollection, FolderCollection>();
builder.Services.AddScoped<IResourceCollection, ResourceCollection>();

builder.Services.AddControllers();

//Configuration CORS
builder.Services.AddCors(options => {
    options.AddPolicy("AllowLocalhost4200", policy => {
        policy.WithOrigins("http://localhost:5173") 
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
    });
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

app.MapControllers();

app.Run();
