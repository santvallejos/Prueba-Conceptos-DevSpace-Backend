using DevSpace_DataAccessLayer.Models.Resource;
using DevSpace_DataAccessLayer.Repositories.Interfaces.IResourceCollection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevSpace_WebAPI.Controllers.ResourceController
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

        public async Task<IActionResult> GetResources()
        {
            return Ok(await _resourceCollection.GetResources());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResourceById(string id)
        {
            return Ok(await _resourceCollection.GetResourceById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddResource([FromBody] Resource resource)
        {
            await _resourceCollection.AddResource(resource);
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
    }
}