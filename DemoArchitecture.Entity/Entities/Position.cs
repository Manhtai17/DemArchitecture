using MongoDB.Bson.Serialization.Attributes;

namespace DemoArchitecture.Entity.Entities
{
	public partial class Position
	{
		[BsonId]
		[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
		public string PositionId { get; set; }
		public string PositionName { get; set; }
	}
}
