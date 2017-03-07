using System;
using System.Threading.Tasks;

namespace Wordpress.Services
{
    /// <summary>
    /// This provides interfaces to the <see cref="WordpressImportService"/> class.
    /// </summary>
    public interface IWordpressImportService : IDisposable
    {
        /// <summary>
        /// Gets the list of posts from wordpress.com.
        /// </summary>
        /// <param name="site">Site name.</param>
        /// <param name="number">Number of posts to fetch.</param>
        /// <param name="after">Date, in yyyy-MM-dd format, when those posts were published after.</param>
        /// <returns>Returns the post object.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="site"/> is <see langword="null"/></exception>
        Task<object> GetPostsFromWordpressAsync(string site, int? number = 20, string after = null);
    }
}