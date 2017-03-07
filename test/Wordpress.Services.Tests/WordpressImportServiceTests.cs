using System;
using System.Threading.Tasks;

using FluentAssertions;

using Moq;

using Newtonsoft.Json.Linq;

using Wordpress.EntityModels;
using Wordpress.Services.Tests.Fixtures;

using Xunit;

namespace Wordpress.Services.Tests
{
    /// <summary>
    /// This represents the test entity for the <see cref="WordpressImportService"/> class.
    /// </summary>
    public class WordpressImportServiceTests : IClassFixture<WordpressImportServiceFixture>
    {
        private readonly Mock<IBlogDbContext> _context;
        private readonly IWordpressImportService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="WordpressImportServiceTests"/> class.
        /// </summary>
        /// <param name="fixture"><see cref="WordpressImportServiceFixture"/> instance.</param>
        public WordpressImportServiceTests(WordpressImportServiceFixture fixture)
        {
            this._context = fixture.BlogDbContext;
            this._service = fixture.WordpressImportService;
        }

        /// <summary>
        /// Tests whether the constructor should throw an exception or not.
        /// </summary>
        [Fact]
        public void Given_NullParameter_Constructor_ShouldThrow_Exception()
        {
            Action action = () => { var instance = new WordpressImportService(null); };

            action.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Tests whether the method should throw an exception or not.
        /// </summary>
        [Fact]
        public void Given_NullParameter_GetPostsFromWordpressAsync_ShouldThrow_Exception()
        {
            Func<Task> func = async () => { var result = await this._service.GetPostsFromWordpressAsync(null).ConfigureAwait(false); };

            func.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Tests whether the method should return result or not.
        /// </summary>
        /// <param name="site">Site name.</param>
        /// <param name="number">Number of posts to return.</param>
        [Theory]
        [InlineData("en.blog.wordpress.com", 2)]
        public async void Given_SiteAndNumber_GetPostsFromWordpressAsync_ShouldReturn_Result(string site, int number)
        {
            dynamic result = await this._service.GetPostsFromWordpressAsync(site, number).ConfigureAwait(false);

            var found = (int)result.found;
            found.Should().BeGreaterThan(0);

            var posts = (JArray)result.posts;
            posts.Count.Should().Be(number);
        }
    }
}
