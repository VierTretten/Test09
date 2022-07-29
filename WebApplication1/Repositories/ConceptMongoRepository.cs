using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using Test.Interfaces;

namespace Test.Repositories
{
    public class ConceptMongoRepository : BaseRepository, IConceptMongoRepository
    {
        private readonly IMongoDatabase _mongoDatabase;

        public ConceptMongoRepository(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }

        public void InsertMissingItems<T, K>(string collectionName, IEnumerable<T> items)
                where T : IMongoObject<K> where K : IEquatable<K>
        {

            var collection = _mongoDatabase.GetCollection<T>(collectionName);

            var mongoItems = collection
                .Find(_ => true)
                .ToList();

            var missingMongoItems = items
                .Where(x => mongoItems
                    .All(y => !y.MongoProperty.Equals(x.MongoProperty)))
                .ToList();

            if (missingMongoItems.Count != 0)
            {
                collection.InsertMany(missingMongoItems);
            }
        }
    }
}
