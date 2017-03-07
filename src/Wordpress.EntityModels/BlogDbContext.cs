using System.Data.Entity;

namespace Wordpress.EntityModels
{
    /// <summary>
    /// This represents the database context entity for Wordpress blog.
    /// </summary>
    public class BlogDbContext : DbContext, IBlogDbContext
    {
        static BlogDbContext()
        {
            Database.SetInitializer<BlogDbContext>(null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogDbContext"/> class.
        /// </summary>
        public BlogDbContext()
            : base("Name=BlogDbContext")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogDbContext"/> class.
        /// </summary>
        /// <param name="connectionString">Connection string value.</param>
        public BlogDbContext(string connectionString)
            : base(connectionString)
        {
        }

        /// <summary>
        /// Gets or sets a set of <see cref="BlogPost"/> instances.
        /// </summary>
        public DbSet<BlogPost> BlogPosts { get; set; }

        /// <summary>
        /// Called when the model for a derived context has been initialized, but before the model has been locked down and used to initialize the context.
        /// </summary>
        /// <param name="builder"><see cref="DbModelBuilder"/> instance that defines the model for the context being created.</param>
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Configurations.Add(new BlogPostMap());
        }
    }
}