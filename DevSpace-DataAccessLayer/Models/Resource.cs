using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DevSpace_DataAccessLayer.Models
{
    public class Resource
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string? FolderId { get; set;}
        public string? FolderName { get; set;}
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public bool Favorite { get; set; } = false;
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)] // Asegura que se almacene en UTC
        public DateTime CreatedOn { get; set; }
    }
}