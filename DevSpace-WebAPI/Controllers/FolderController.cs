using DevSpace_DataAccessLayer.Models;
using DevSpace_DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DevSpace_BusinessLayer.Infrastructure.Dto;
using MongoDB.Bson;

namespace DevSpace_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderController : ControllerBase
    {
        private readonly IFolderCollection _folderCollection;
        private readonly FolderServices _folderServices;

        public FolderController(IFolderCollection folderCollection, FolderServices folderServices)
        {
            _folderCollection = folderCollection;
            _folderServices = folderServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetFolders()
        {
            //Obtenemos todas las carpetas
            return Ok(await _folderCollection.GetFolders());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFolderById(string id)
        {
            //Obtenemos la carpeta por id
            return Ok(await _folderCollection.GetFolderById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddFolder([FromBody] PostFolderDto folderDto)
        {
            try
            {   
                //Agregamos la carpeta indepedientemente y si tiene padre, agregamos la referencia al padre s
                await _folderServices.AddFolderAsync(folderDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFolder(string id,[FromBody] PutFolderDto folderDto)
        {
            //validamos que el id no sea nulo
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                //Actualizamos el name de la carpeta
                await _folderServices.UpdateFolderAsync(id, folderDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFolder(string id)
        {
            try
            {
                //Eliminamos la carpeta y si tiene subcarpetas las elimina tambien
                await _folderServices.DeleteFolderAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("subfolders/{id}")]
        public async Task<IActionResult> GetSubFolders(string id)
        {
            //Obtenemos las subcarpetas de la carpeta padre
            return Ok(await _folderCollection.GetSubFolders(id));
        }

        [HttpGet("folders/{name}")]
        public async Task<IActionResult> GetFoldersByName (string name)
        {
            return Ok(await _folderCollection.GetFoldersByName(name));
        }
    }
}
