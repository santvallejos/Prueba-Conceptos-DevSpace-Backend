using DevSpace_DataAccessLayer.Models;
using DevSpace_DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DevSpace_WebAPI.Infrastructure.Dto;
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
            return Ok(await _folderCollection.GetFolders());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFolderById(string id)
        {
            return Ok(await _folderCollection.GetFolderById(id));
        }
        [HttpGet("SubFolders/{id}")]
        public async Task<IActionResult> GetSubFolders(string id)
        {
            return Ok(await _folderCollection.GetSubFolders(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddFolder([FromBody] PostFolderDto folderDto)
        {
            Folder @folder = new Folder
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Name = folderDto.Name,
                ParentFolderID = folderDto.ParentFolderID,
                SubFolders = new List<string>()
            };

            try
            {
                await _folderServices.AddFolderAsync(@folder);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFolder([FromBody] Folder folder)
        {
            await _folderCollection.UpdateFolder(folder);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFolder(string id)
        {
            try
            {
                await _folderServices.DeleteFolderAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
