using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Test.Interfaces;

namespace Test.Entities
{
    [BsonIgnoreExtraElements]
    public class MongoCompany : MongoBaseEntity, IMongoObject<int>
    {
        [BsonElement("companyId")]
        public int CompanyId { get; set; }

        [BsonIgnore]
        public int MongoProperty
        {
            get { return CompanyId; }
            set { CompanyId = value; }
        }
    }
}
