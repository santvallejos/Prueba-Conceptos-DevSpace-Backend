using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevSpace_DataAccessLayer.Models.Resource;
using DevSpace_DataAccessLayer.Repositories.Interfaces.IResourceCollection;
using MongoDB.Driver;

namespace DevSpace_DataAccessLayer.Repositories.Collection.ResourceCollection
{
    public class ResourceCollection : IResourceCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Resource> Collection;

        public ResourceCollection()
        {
            Collection = _repository.database.GetCollection<Resource>( "Resources" );
        }

        /* Implementar las funciones */
        public Task AddResource( Resource folder )
        {
            throw new NotImplementedException();
        }

        public Task DeleteResource( string id )
        {
            throw new NotImplementedException();
        }

        public Task<List<Resource>> GetResources()
        {
            throw new NotImplementedException();
        }

        public Task<Resource> GetResourceById( string id )
        {
            throw new NotImplementedException();
        }

        public Task UpdateResource( Resource folder )
        {
            throw new NotImplementedException();
        }
    } 
}