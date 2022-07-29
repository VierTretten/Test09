using NLog;
using System;
using Test.Interfaces;

namespace Test.Services
{
    public class ConceptService : IConceptService
    {
        private readonly IUpdateService _updateService;
        private readonly IContentService _contentService;

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public ConceptService(IUpdateService updateService, IContentService contentService)
        {
            _updateService = updateService;
            _contentService = contentService;
        }

        public ResultStatus UpdateConceptsForAllMembers()
        {
            try
            {
                _logger.Info("Updating concepts");
                _updateService.UpdateCompanies();
                _updateService.UpdateIndustries();

                _contentService.UpdateContent();

                return ResultStatus.Success;
            }
            catch (Exception exception)
            {
                _logger.Error($"Cannot update concepts: {exception.Message}");
                return exception.ToErrorResult();
            }
        }
    }
}

