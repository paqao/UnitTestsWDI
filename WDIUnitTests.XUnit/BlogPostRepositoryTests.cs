using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDIUnitTests.DatabaseLayer.Data;
using WDIUnitTests.Repository;
using WDIUnitTests.XUnit.Fixtures;
using Xunit;

namespace WDIUnitTests.XUnit
{
    public class BlogPostRepositoryTests : IClassFixture<BlogPostRepositoryFixture>
    {
        private readonly BlogPostRepositoryFixture _fixture;
        private readonly MemoryDataRepository<BlogPost> _repository;

        public BlogPostRepositoryTests(BlogPostRepositoryFixture blogPostRepositoryFixture)
        {
            _fixture = blogPostRepositoryFixture;
            _repository = _fixture.Db;
        }

        [Fact]
        public async Task RepositoryContainsInitialy3Objects()
        {
            // Arrange

            // Act
            var result = await _repository.GetAllAsync();

            // Assert
            Assert.Equal(3, result.Count());
        }
    }
}
