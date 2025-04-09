using System.ComponentModel;
using DevSpace_DataAccessLayer.Models;

namespace DevSpace_BusinessLayer.Infrastructure.Dto
{
    public class PostResourceDto
    {
        public string? FolderId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ResourceType Type { get; set; }
        public string? Url { get; set; }
        public string? Code { get; set; }
        public string? Text { get; set; }
    }
}