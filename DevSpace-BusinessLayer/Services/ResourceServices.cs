using System;
using System.Linq;
using System.Collections.Generic;
using DevSpace_DataAccessLayer.Models;
using DevSpace_DataAccessLayer.Repositories.Collection;
using DevSpace_DataAccessLayer.Repositories.Interfaces;
using DevSpace_BusinessLayer.Infrastructure.Dto;
using MongoDB.Bson;

public class ResourceServices
{
    private readonly IResourceCollection _resourceCollection;

    public ResourceServices(IResourceCollection resourceCollection)
    {
        _resourceCollection = resourceCollection;
    }

    public async Task UpdateResourceFavoriteAsync(string Id)
    {
        //Obtenemos el recuro
        var resource = await _resourceCollection.GetResourceById(Id);
        if (resource != null)
        {
            //Actualizo el Favorite
            resource.Favorite = !resource.Favorite;
            //Actualizo la carpeta
            await _resourceCollection.UpdateResource(resource);
        }
        else
        {
            throw new Exception("No se encontro el recurso");
        }
    } 
}
