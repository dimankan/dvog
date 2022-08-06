using Microsoft.AspNetCore.Mvc;

namespace Dvog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModelController : ControllerBase
    {
        private readonly ILogger<ModelController> _logger;

        public ModelController(ILogger<ModelController> logger, ModelServiceA serviceA, ModelServiceB serviceB)
        {
            logger.LogInformation(Guid.NewGuid().ToString());
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Action()
        {
            _logger.LogInformation(Guid.NewGuid().ToString());
            return Ok();
        }
    }

    public class ModelServiceA
    {
        public ModelServiceA(ILogger<ModelServiceA> logger, ModelRepositoryA repositoryA, ModelRepositoryB repositoryB)
        {
            logger.LogInformation(Guid.NewGuid().ToString());

        }
    }

    public class ModelServiceB
    {
        public ModelServiceB(ILogger<ModelServiceB> logger, ModelRepositoryA repositoryA, ModelRepositoryB repositoryB)
        {
            logger.LogInformation(Guid.NewGuid().ToString());

        }
    }

    public class ModelRepositoryA
    {
        public ModelRepositoryA(ILogger<ModelRepositoryA> logger)
        {
            logger.LogInformation(Guid.NewGuid().ToString());

        }
    }

    public class ModelRepositoryB
    {
        public ModelRepositoryB(ILogger<ModelRepositoryB> logger)
        {
            logger.LogInformation(Guid.NewGuid().ToString());

        }
    }
}
