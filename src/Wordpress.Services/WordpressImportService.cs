using System;
using System.Net.Http;
using System.Threading.Tasks;

using Wordpress.EntityModels;

namespace Wordpress.Services
{
    /// <summary>
    /// This represents the service entity for Wordpress blog post import.
    /// </summary>
    public class WordpressImportService : IWordpressImportService
    {
        private const string WordpressRestApiUri = "https://public-api.wordpress.com/rest";
        private const string WordpressRestApiVersion = "v1.1";
        private const string WordpressRestApiEndPointForGetPosts = "sites/{0}/posts/";

        private readonly IBlogDbContext _context;

        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="WordpressImportService"/> class.
        /// </summary>
        /// <param name="context"><see cref="IBlogDbContext"/> instance.</param>
        /// <exception cref="ArgumentNullException"><paramref name="context"/> is <see langword="null"/></exception>
        public WordpressImportService(IBlogDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            this._context = context;
        }

        /// <summary>
        /// Gets the list of posts from wordpress.com.
        /// </summary>
        /// <param name="site">Site name.</param>
        /// <param name="number">Number of posts to fetch.</param>
        /// <param name="after">Date, in yyyy-MM-dd format, when those posts were published after.</param>
        /// <returns>Returns the post object.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="site"/> is <see langword="null"/></exception>
        public async Task<object> GetPostsFromWordpressAsync(string site, int? number = 20, string after = null)
        {
            if (string.IsNullOrWhiteSpace(site))
            {
                throw new ArgumentNullException(nameof(site));
            }

            // TODO: This is not unit-testable. Refactoring required.
            using (var client = new HttpClient() { BaseAddress = new Uri($"{WordpressRestApiUri}/{WordpressRestApiVersion}/") })
            {
                var ep = string.Format(WordpressRestApiEndPointForGetPosts, site);
                var qs = $"pretty=true&number={number}";
                if (!string.IsNullOrWhiteSpace(after))
                {
                    qs += $"&after={after}";
                }

                var message = await client.GetAsync($"{ep}?{qs}").ConfigureAwait(false);
                dynamic response = await message.Content.ReadAsAsync<object>().ConfigureAwait(false);

                return response;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this._disposed)
            {
                return;
            }

            this._disposed = true;
        }
    }
}
