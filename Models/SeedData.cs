using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace CIDM3312_FinalProjectBlog.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BlogDbContext(serviceProvider.GetRequiredService<DbContextOptions<BlogDbContext>>()))
            {
                // Look for any blogs.
                if (context.Blog.Any())
                {
                    return; // DB has been seeded
                }
                
                context.Blog.AddRange(
                    new Blog
                    {
                        Title = "Business",
                        
                        Post = new List<Post>{
                        new Post { heading= "hsdlhlh",content="sghldghlhgslghlsdgs"},
                        new Post { heading= "hsdlhlh",content="sghldghlhgslghlsdgs"},
                        new Post { heading= "hsdlhlh",content="sghldghlhgslghlsdgs"},
                        new Post { heading= "hsdlhlh",content="sghldghlhgslghlsdgs"}
                        }

                    },
                    new Blog
                    {
                        Title = "Technology",
                        Post = new List<Post>{
                        new Post { heading= "hsdlhlh",content="sghldghlhgslghlsdgs"},
                        new Post { heading= "hsdlhlh",content="sghldghlhgslghlsdgs"},
                        new Post { heading= "hsdlhlh",content="sghldghlhgslghlsdgs"},
                        new Post { heading= "hsdlhlh",content="sghldghlhgslghlsdgs"}
                        
                        }  
                    }
                    );
                
                context.SaveChanges();
            }
        }

    }

}