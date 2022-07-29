using MongoDB.Bson;
using MongoDB.Driver;
using NLog;
using System.Linq;
using System.Configuration;
using Test.Entities;
using Test.Interfaces;

namespace Test.Services
{
    public class UpdateService : IUpdateService
    {
        private string CollectionNameForIndustries = ConfigurationManager.AppSettings["CollectionNameForIndustries"];
        private string CollectionNameForCompanies = ConfigurationManager.AppSettings["CollectionNameForCompanies"];

        private readonly IConceptMongoRepository _conceptMongoRepository;
        private readonly IConceptSqlRepository _conceptSqlRepository;

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public UpdateService(IConceptMongoRepository conceptMongoRepository, IConceptSqlRepository conceptSqlRepository)
        {
            _conceptSqlRepository = conceptSqlRepository;
            _conceptMongoRepository = conceptMongoRepository;
        }

        public void UpdateIndustries()
        {
            var industriesNames = _conceptSqlRepository.GetAllIndustriesNamesFromSql();

            var industries = industriesNames
                .Select(iName => new MongoIndustry()
                {
                    Id = ObjectId.GenerateNewId(),
                    Name = iName
                })
                .ToList();

            _logger.Info("Inserting missing items to Mongo");
            _conceptMongoRepository.InsertMissingItems<MongoIndustry, string>(CollectionNameForIndustries, industries);
        }

        public void UpdateCompanies()
        {
            var companiesIds = _conceptSqlRepository.GetAllCompaniesIdsFromSql();

            var companies = companiesIds
                .Select(cId => new MongoCompany()
                {
                    Id = ObjectId.GenerateNewId(),
                    CompanyId = cId
                })
                .ToList();

            _logger.Info("Inserting missing items to Mongo");
            _conceptMongoRepository.InsertMissingItems<MongoCompany, int>(CollectionNameForCompanies, companies);
        }
    }
}

