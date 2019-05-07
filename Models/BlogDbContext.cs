using Microsoft.EntityFrameworkCore;

namespace CIDM3312_FinalProjectBlog.Models
{
	public class BlogDbContext : DbContext
	{
		public BlogDbContext (DbContextOptions<BlogDbContext> options)
			: base(options)
		{
		}
		public DbSet<Blog> Blog {get; set;}
		public DbSet<Post> Post {get; set;}
	}
}
