using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Test.Entities
{
    [BsonIgnoreExtraElements]
    public class MongoBaseEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}