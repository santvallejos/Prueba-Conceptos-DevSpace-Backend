using System;
using System.Linq;
using System.Collections.Generic;
using DevSpace_DataAccessLayer.Models;
using DevSpace_DataAccessLayer.Repositories.Collection;
using DevSpace_DataAccessLayer.Repositories.Interfaces;

    public class FolderServices
    {
        private readonly IFolderCollection _folderCollection;

        public FolderServices(IFolderCollection folderCollection)
        {
            _folderCollection = folderCollection;
        }

        public async Task AddFolderAsync(Folder folder)
        {
            //Obtenemos el id del padre
            var parentFolderID = folder.ParentFolderID;
            //Si el padre no es nulo, agregamos la referencia al padre
            if(parentFolderID != null)
            {
                //Obtenemos el padre
                var parentFolder = await _folderCollection.GetFolderById(parentFolderID);
                if(parentFolder != null)
                {
                    //Agregamos la carpeta indepedientemente
                    _folderCollection.AddFolder(folder);
                    //Agreamos la referencia del Id de la carpeta hija al padre
                    parentFolder.SubFolders.Add(folder.Id);
                    await _folderCollection.UpdateFolder(parentFolder);
                }
                else
                {
                    throw new Exception("El padre no existe");
                }
            }
            else
            {
                _folderCollection.AddFolder(folder);
            }
        }

        public async Task DeleteFolderAsync(string folderId)
        {
            var folder = await _folderCollection.GetFolderById(folderId);
            if (folder != null)
            {
                var longSubFolders = folder.SubFolders.Count;
                if (longSubFolders > 0)
                {
                    //Necesito eliminar las carpetas hijas
                    foreach (var subFolderId in folder.SubFolders)
                    {
                        await DeleteFolderAsync(subFolderId);
                    }
                    
                }
                //Elimino la carpeta padre
                await _folderCollection.DeleteFolder(folderId);
            }
            else
            {
                throw new Exception("La carpeta no existe");
            }
        }
    }