using System.ComponentModel;

namespace DevSpace_WebAPI.Infrastructure.Dto
{
    public class PostFolderDto
    {
        public string Name { get; set; }
        public string? ParentFolderID { get; set; }
    }
}