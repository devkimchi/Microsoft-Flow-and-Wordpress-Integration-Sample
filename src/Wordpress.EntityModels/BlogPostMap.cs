using System.Data.Entity.ModelConfiguration;

namespace Wordpress.EntityModels
{
    /// <summary>
    /// This represents the mapping entity for the <see cref="BlogPost"/> entity class.
    /// </summary>
    public class BlogPostMap : EntityTypeConfiguration<BlogPost>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlogPostMap"/> class.
        /// </summary>
        public BlogPostMap()
        {
            // Primary Key
            this.HasKey(p => p.BlogPostId);

            // Properties
            this.Property(p => p.BlogPostId).IsRequired();
            this.Property(p => p.PostId).IsRequired();
            this.Property(p => p.Author).IsRequired().HasMaxLength(64);
            this.Property(p => p.DatePublished).IsRequired();
            this.Property(p => p.DateModified).IsRequired();
            this.Property(p => p.Title).IsRequired().HasMaxLength(512);
            this.Property(p => p.Url).IsRequired().HasMaxLength(512);
            this.Property(p => p.Status).IsRequired().HasMaxLength(16);
            this.Property(p => p.PostType).IsRequired().HasMaxLength(16);
            this.Property(p => p.IsRewardIssued).IsRequired();
            this.Property(p => p.IsRewardDelivered).IsRequired();
            this.Property(p => p.DateCreated).IsRequired();
            this.Property(p => p.DateUpdated).IsOptional();

            // Table & Column Mappings
            this.ToTable("BlogPost");
            this.Property(p => p.BlogPostId).HasColumnName("BlogPostId");
            this.Property(p => p.PostId).HasColumnName("PostId");
            this.Property(p => p.Author).HasColumnName("Author");
            this.Property(p => p.DatePublished).HasColumnName("DatePublished");
            this.Property(p => p.DateModified).HasColumnName("DateModified");
            this.Property(p => p.Title).HasColumnName("Title");
            this.Property(p => p.Url).HasColumnName("Url");
            this.Property(p => p.Status).HasColumnName("Status");
            this.Property(p => p.PostType).HasColumnName("PostType");
            this.Property(p => p.IsRewardIssued).HasColumnName("IsRewardIssued");
            this.Property(p => p.IsRewardDelivered).HasColumnName("IsRewardDelivered");
            this.Property(p => p.DateCreated).HasColumnName("DateCreated");
            this.Property(p => p.DateUpdated).HasColumnName("DateUpdated");
        }
    }
}