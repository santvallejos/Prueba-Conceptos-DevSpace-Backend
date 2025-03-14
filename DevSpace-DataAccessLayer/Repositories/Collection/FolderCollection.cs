using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevSpace_DataAccessLayer.Models.Folder;
using DevSpace_DataAccessLayer.Repositories.Interfaces.IFolderCollection;
using MongoDB.Driver;

namespace DevSpace_DataAccessLayer.Repositories.Collection.FolderCollection
{
    public class FolderCollection : IFolderCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Folder> Collection;

        public FolderCollection()
        {
            Collection = _repository.database.GetCollection<Folder>( "Folders" );
        }

        /* Implementar las funciones */
        public Task AddFolder( Folder folder )
        {
            throw new NotImplementedException();
        }

        public Task DeleteFolder( string id )
        {
            throw new NotImplementedException();
        }

        public Task<List<Folder>> GetFolders()
        {
            throw new NotImplementedException();
        }

        public Task<Folder> GetFolderById( string id )
        {
            throw new NotImplementedException();
        }

        public Task UpdateFolder( Folder folder )
        {
            throw new NotImplementedException();
        }
    }
}
