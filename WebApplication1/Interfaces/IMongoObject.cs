
namespace Test.Interfaces
{
    public interface IMongoObject<T>
    {
        T MongoProperty { get; set; }
    }
}