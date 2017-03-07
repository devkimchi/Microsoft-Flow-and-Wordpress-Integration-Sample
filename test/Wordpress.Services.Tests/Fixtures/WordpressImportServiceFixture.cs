using System;

using Moq;

using Wordpress.EntityModels;

namespace Wordpress.Services.Tests.Fixtures
{
    /// <summary>
    /// This represents the fixture entity for the <see cref="WordpressImportServiceTests"/> class.
    /// </summary>
    public class WordpressImportServiceFixture : IDisposable
    {
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="WordpressImportServiceFixture"/> class.
        /// </summary>
        public WordpressImportServiceFixture()
        {
            this.BlogDbContext = new Mock<IBlogDbContext>();

            this.WordpressImportService = new WordpressImportService(this.BlogDbContext.Object);
        }

        /// <summary>
        /// Gets the <see cref="Mock{IBlogDbContext}"/> instance.
        /// </summary>
        public Mock<IBlogDbContext> BlogDbContext { get; }

        /// <summary>
        /// Gets the <see cref="IWordpressImportService"/> instance.
        /// </summary>
        public IWordpressImportService WordpressImportService { get; }

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
