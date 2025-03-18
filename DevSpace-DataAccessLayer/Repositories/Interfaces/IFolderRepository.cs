using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevSpace_DataAccessLayer.Models;

namespace DevSpace_DataAccessLayer.Repositories.Interfaces
{
    public interface IFolderCollection
    {
        Task AddFolder( Folder folder );
        Task UpdateFolder( Folder folder );
        Task DeleteFolder( string id );
        Task<List<Folder>> GetFolders();
        Task<Folder> GetFolderById( string id );
    }
}