using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using DevSpace_DataAccessLayer.Models;

namespace DevSpace_DataAccessLayer.Models
{
    public class Folder
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string ParentFolderID { get; set; }
        public List<Folder> SubFolder { get; set; } = new List<Folder>();
    }
}