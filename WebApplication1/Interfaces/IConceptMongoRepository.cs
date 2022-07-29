using System;
using System.Collections.Generic;

namespace Test.Interfaces
{
    public interface IConceptMongoRepository
    {
        public void InsertMissingItems<T, K>(string collectionName, IEnumerable<T> items)
                where T : IMongoObject<K> where K : IEquatable<K>;
    }
}
