using CRUD.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Operation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly ISettingsRepository _settingsRepository;

        public SettingsController(ISettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }

        [HttpGet]
        public Task<IEnumerable<string>> GetOpportunityType()
        {
            var result = _settingsRepository.GetAllOppTypes();
            return result;
        }

    }
}
