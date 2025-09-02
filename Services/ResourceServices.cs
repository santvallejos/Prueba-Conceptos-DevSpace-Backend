﻿using System;
using System.Linq;
using System.Collections.Generic;
using api.Data.Models;
using api.Data.Repositories.Collection;
using api.Data.Repositories.Interfaces;
using api.Infrastructure.Dto;
using MongoDB.Bson;

namespace api.Services
{
    public class ResourceServices
    {
        private readonly IResourceCollection _resourceCollection;
        private readonly IFolderCollection _folderCollection;

        public ResourceServices(IResourceCollection resourceCollection, IFolderCollection folderCollection)
        {
            _resourceCollection = resourceCollection;
            _folderCollection = folderCollection;
        }

        public async Task<List<Resource>> GetResourcesRecentsAsync()
        {
            //Obtengo todos los recursos
            var resources = await _resourceCollection.GetResources();
            //Ordeno por fecha de creacion
            resources = resources.OrderByDescending(x => x.CreatedOn).ToList();
            //Obtengo los 12 ultimos recursos
            resources = resources.Take(12).ToList();
            return resources;
        }

        public async Task<Resource> AddResourceAsync(PostResourceDto resourceDto)
        {
            Resource @resource;
            
            if (resourceDto.FolderId != null)
            {
                var folder = await _folderCollection.GetFolderById(resourceDto.FolderId);
                
                if (folder != null)
                {
                    @resource = new Resource()
                    {
                        Id = ObjectId.GenerateNewId().ToString(),
                        FolderId = resourceDto.FolderId,
                        Name = resourceDto.Name,
                        Description = resourceDto.Description,
                        Type = resourceDto.Type,
                        CodeType = resourceDto.CodeType,
                        Value = resourceDto.Value,
                        Favorite = false,
                        CreatedOn = DateTime.UtcNow
                    };
                    await _resourceCollection.AddResource(@resource);
                }
                else
                {
                    throw new Exception("No existe una carpeta con ese Id");
                }
            }
            else
            {
                @resource = new Resource()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    FolderId = null,
                    Name = resourceDto.Name,
                    Description = resourceDto.Description,
                    Type = resourceDto.Type,
                    CodeType = resourceDto.CodeType,
                    Value = resourceDto.Value,
                    Favorite = false,
                    CreatedOn = DateTime.UtcNow
                };
                await _resourceCollection.AddResource(@resource);
            }
            return @resource;
        }

        public async Task UpdateResourceAsync(string Id, UpdateResourceDto resourceDto)
        {
            var resource = await _resourceCollection.GetResourceById(Id);
            //Verificamos que exista el recurso
            if (resource != null)
            {
                resource.Name = resourceDto.Name;
                resource.Description = resourceDto.Description;
                resource.Value = resourceDto.Value;
                await _resourceCollection.UpdateResource(resource);
            }
            else
            {
                throw new Exception("No se encontro el recurso");
            }
        }

        public async Task UpdateResourcePartialAsync(string id, UpdateResourceDto resourceDto)
        {
            var resource = await _resourceCollection.GetResourceById(id);
            // Verificamos que existe el recurso
            if (resource != null)
            {
                if (resourceDto.Name != null)
                {
                    resource.Name = resourceDto.Name;
                }
                if (resourceDto.Description != null)
                {
                    resource.Description = resourceDto.Description;
                }
                if (resourceDto.Value != null)
                {
                    resource.Value = resourceDto.Value;
                }
                await _resourceCollection.UpdateResource(resource);
            }
            else
            {
                throw new Exception("No se encontro el recurso");
            }
        }

        public async Task UpdateResourceFolderIdAsync(string Id, UpdateFolderId resourceDto)
        {
            var resource = await _resourceCollection.GetResourceById(Id);
            // Verificamos que exista el recurso
            if (resource != null)
            {
                //Si se quiere pasar a la raiz de la carpeta
                if (resourceDto.FolderId == null)
                {
                    resource.FolderId = null;
                    await _resourceCollection.UpdateResource(resource);
                }
                else // Si se quiere pasar a otra carpeta
                {
                    var folder = await _folderCollection.GetFolderById(resourceDto.FolderId);
                    //Si la carpeta existe
                    if (folder != null)
                    {
                        resource.FolderId = resourceDto.FolderId;
                        await _resourceCollection.UpdateResource(resource);
                    }
                    else
                    {
                        throw new Exception("No existe una carpeta con ese Id");
                    }
                }
            }
            else
            {
                throw new Exception("No se encontro el recurso");
            }
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
}
