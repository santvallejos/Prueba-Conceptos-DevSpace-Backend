using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevSpace_DataAccessLayer.Models.Folder;
using DevSpace_DataAccessLayer.Repositories.Interfaces.IFolderCollection;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DevSpace_DataAccessLayer.Repositories.Collection.FolderCollection
{
    public class FolderCollection : IFolderCollection
    {
        internal MongoDBRepository _repository = new();
        private readonly IMongoCollection<Folder> Collection;

        public FolderCollection()
        {
            Collection = _repository.database.GetCollection<Folder>( "Folders" );
        }

        /* Implementar las funciones */
        public async Task AddFolder( Folder folder )
        {
            await Collection.InsertOneAsync( folder );
        }

        public async Task DeleteFolder( string id )
        {
            var filter = Builders<Folder>.Filter.Eq("_id", new ObjectId(id));
            await Collection.DeleteOneAsync( filter );
        }

        public async Task<List<Folder>> GetFolders()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Folder> GetFolderById( string id )
        {
            var filter = Builders<Folder>.Filter.Eq("_id", new ObjectId(id));
            return await Collection.FindAsync(filter).Result.FirstOrDefaultAsync();
        }

        public async Task UpdateFolder( Folder folder )
        {
            var filter = Builders<Folder>.Filter.Eq(s => s.Id, folder.Id);
            await Collection.ReplaceOneAsync(filter, folder);
        }
    }
}
