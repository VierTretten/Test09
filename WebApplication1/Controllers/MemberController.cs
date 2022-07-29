using Microsoft.AspNetCore.Mvc;
using Test.Interfaces;

namespace Test.Controllers
{
    public class MemberController : ControllerBase
    {

        private readonly IConceptService _conceptService;

        public MemberController(IConceptService conceptService)
        {
            _conceptService = conceptService;
        }

        [HttpPost]
        public ActionResult UpdateMongoFromSql()
        {
            var result = _conceptService.UpdateConceptsForAllMembers();

            return Json(new { Success = !result.IsError });
        }
    }
}
