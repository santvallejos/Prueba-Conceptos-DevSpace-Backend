using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevSpace_DataAccessLayer.Models;
using DevSpace_DataAccessLayer.Repositories.Interfaces;
using MongoDB.Driver;

namespace DevSpace_DataAccessLayer.Repositories.Collection
{
    public class ResourceCollection : IResourceCollection
    {
        internal MongoDBRepository _repository = new();
        private readonly IMongoCollection<Resource> Collection;

        public ResourceCollection()
        {
            Collection = _repository.database.GetCollection<Resource>( "Resources" );
        }

        //[Get]
        public Task<List<Resource>> GetResources()
        {
            throw new NotImplementedException();
        }
        //[Get]
        public Task<Resource> GetResourceById( string id )
        {
            throw new NotImplementedException();
        }
        //[Post]
        public Task AddResource( Resource folder )
        {
            throw new NotImplementedException();
        }
        //[Put]
        public Task UpdateResource( Resource folder )
        {
            throw new NotImplementedException();
        }
        //[Delete]
        public Task DeleteResource( string id )
        {
            throw new NotImplementedException();
        }
    } 
}