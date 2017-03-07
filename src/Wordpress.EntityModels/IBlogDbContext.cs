using System;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Wordpress.EntityModels
{
    /// <summary>
    /// This provides interfaces to the <see cref="BlogDbContext"/> class.
    /// </summary>
    public interface IBlogDbContext : IDisposable
    {
        /// <summary>
        /// Gets or sets a set of <see cref="BlogPost"/> instances.
        /// </summary>
        DbSet<BlogPost> BlogPosts { get; set; }

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>Returns the number of state entries written to the underlying database.</returns>
        int SaveChanges();

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>Returns the number of state entries written to the underlying database.</returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <param name="cancellationToken"><see cref="CancellationToken" /> instance to observe while waiting for the task to complete.</param>
        /// <returns>Returns the number of state entries written to the underlying database.</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}