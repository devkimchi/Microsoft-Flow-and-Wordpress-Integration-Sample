using System;

namespace Wordpress.EntityModels
{
    /// <summary>
    /// This represents the entity for blog post.
    /// </summary>
    public class BlogPost
    {
        /// <summary>
        /// Gets or sets a blog post Id.
        /// </summary>
        public Guid BlogPostId { get; set; }

        /// <summary>
        /// Gets or sets a post Id from wordpress.com.
        /// </summary>
        public int PostId { get; set; }

        /// <summary>
        /// Gets or sets an author from wordpress.com.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets a date when the post was published.
        /// </summary>
        public DateTimeOffset DatePublished { get; set; }

        /// <summary>
        /// Gets or sets a date when the post was modified the last.
        /// </summary>
        public DateTimeOffset DateModified { get; set; }

        /// <summary>
        /// Gets or sets a title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets a URL.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets a post status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets a post type.
        /// </summary>
        public string PostType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the reward for the post has been issued or not.
        /// </summary>
        public bool IsRewardIssued { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the reward for the post has been delivered or not.
        /// </summary>
        public bool IsRewardDelivered { get; set; }

        /// <summary>
        /// Gets or sets a date when the record was created.
        /// </summary>
        public DateTimeOffset DateCreated { get; set; }

        /// <summary>
        /// Gets or sets a date when the record was updated.
        /// </summary>
        public DateTimeOffset DateUpdated { get; set; }
    }
}
