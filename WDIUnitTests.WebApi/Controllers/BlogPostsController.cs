using Microsoft.AspNetCore.Mvc;
using WDIUnitTests.DatabaseLayer.Data;
using WDIUnitTests.Repository;

namespace WDIUnitTests.WebApi.Controllers
{
    [Route("posts")]
    public class BlogPostsController : Controller
    {
        private IDataRepository<BlogPost> _blogPostRepository;
        public BlogPostsController(IDataRepository<BlogPost> blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<BlogPost>> GetAll()
        {
            return await _blogPostRepository.GetAllAsync();
        }

        [HttpPost()]
        public async Task AddOrder([FromBody] BlogPost post)
        {
            await _blogPostRepository.AddAsync(post);
        }
    }
}
