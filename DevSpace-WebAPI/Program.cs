using DevSpace_DataAccessLayer.Models.Folder;
using DevSpace_DataAccessLayer.Repositories.Collection.FolderCollection;
using DevSpace_DataAccessLayer.Repositories.Collection.ResourceCollection;
using DevSpace_DataAccessLayer.Repositories.Interfaces.IFolderCollection;
using DevSpace_DataAccessLayer.Repositories.Interfaces.IResourceCollection;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Configuracion de MongoDB
builder.Services.AddSingleton<IMongoClient>(new MongoClient("mongodb://localhost:27017/DevSpace"));
builder.Services.AddSingleton<IMongoDatabase>(sp => sp.GetService<IMongoClient>()!.GetDatabase("Unity"));

//Repositorios
builder.Services.AddScoped<IFolderCollection, FolderCollection>();
builder.Services.AddScoped<IResourceCollection, ResourceCollection>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
