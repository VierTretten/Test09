using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Test.Interfaces;

namespace Test.Entities
{
    public class MongoIndustry : MongoBaseEntity, IMongoObject<string>
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonIgnore]
        public string MongoProperty
        {
            get { return Name; }
            set { Name = value; }
        }
    }
}