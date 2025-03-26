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
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}