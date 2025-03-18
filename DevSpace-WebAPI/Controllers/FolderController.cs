using DevSpace_DataAccessLayer.Models;
using DevSpace_DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevSpace_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderController : ControllerBase
    {
        private readonly IFolderCollection _folderCollection;

        public FolderController(IFolderCollection folderCollection)
        {
            _folderCollection = folderCollection;
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

        [HttpPost]
        public async Task<IActionResult> AddFolder([FromBody] Folder folder)
        {
            await _folderCollection.AddFolder(folder);
            return Ok();
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
            await _folderCollection.DeleteFolder(id);
            return Ok();
        }
    }
}
