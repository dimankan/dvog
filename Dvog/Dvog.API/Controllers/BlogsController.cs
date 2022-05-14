namespace Dvog.API.Controllers
{
    public class BlogsController
    {
        private readonly ILogger<BlogsController> _logger;

        public BlogsController(ILogger<BlogsController> logger)
        {
            _logger = logger;
        }
    }
}
