using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace DemoArchitecture.Entity.Entities
{
    public class Email : BaseEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string EmailId { get; set; }
        public string EmailSenderName { get; set; }
        public string EmailSenderAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public Dictionary<string, string>? CustomArgs { get; set; }
        public string? Recipients { get; set; }
    }
}
