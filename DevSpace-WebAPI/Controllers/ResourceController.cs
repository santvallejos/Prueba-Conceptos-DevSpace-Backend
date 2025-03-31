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
    public class ResourceController : ControllerBase
    {
        private readonly IResourceCollection _resourceCollection;

        public ResourceController(IResourceCollection resourceCollection)
        {
            _resourceCollection = resourceCollection;
        }

        [HttpGet]
        public async Task<IActionResult> GetResources()
        {
            return Ok(await _resourceCollection.GetResources());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResourceById(string id)
        {
            return Ok(await _resourceCollection.GetResourceById(id));
        }

        [HttpGet("folder/{folderId}")]
        public async Task<IActionResult> GetResourcesByFolderId(string folderId)
        {
            return Ok(await _resourceCollection.GetResourcesByFolderId(folderId));
        }
        
        [HttpPost]
        public async Task<IActionResult> AddResource([FromBody] PostResourceDto resourceDto)
        {
            Resource @resource = new Resource
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Name = resourceDto.Name,
                Description = resourceDto.Description,
                Url = resourceDto.Url,
                FolderId = resourceDto.FolderId
            };
            await _resourceCollection.AddResource(@resource);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateResource([FromBody] Resource resource)
        {
            await _resourceCollection.UpdateResource(resource);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResource(string id)
        {
            await _resourceCollection.DeleteResource(id);
            return Ok();
        }

        [HttpDelete("folder/{folderId}")]
        public async Task<IActionResult> DeleteResourcesByFolderId(string folderId)
        {
            await _resourceCollection.DeleteResourcesByFolderId(folderId);
            return Ok();
        }
    }
}