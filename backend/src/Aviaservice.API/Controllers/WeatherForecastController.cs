using Aviaservice.Domain.Modules;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;

namespace Aviaservice.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get(string title, string description)
        {
            Result<Module> moduleResult = Module.Create(title, description);

            if (moduleResult.IsFailure)
            {
                return BadRequest(moduleResult.Error);

            }
            var result = Save(moduleResult.Value);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            //сохранение в базу данных
            return Ok();

        }
        public Result Save(Module module)
        {
            if (true)
            {
                return Result.Success();
            }
            else return Result.Failure("Error");
        }
    }
}
