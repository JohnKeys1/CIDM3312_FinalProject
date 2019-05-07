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
                        new Post { heading= "iOS reportedly getting its very own swipe-to-type keyboard",content="Apple  may be bringing an Android favorite to iOS at its software developers conference next month.",author="Lucas"},
                        new Post { heading= "Gett raises $200M at $1.5B valuation for its B2B ride-hailing service, aims for 2020 IPO",content="As Uber gears up for an IPO, one of its smaller rivals has raised some money as it prepares to take its own turn on the public market",author="Ingrid Lunden"},
                        new Post { heading= "Google refreshes Android Auto with new features and a darker look",content="sghldghlhgslghlsdgs"},
                        new Post { heading= "Microsoft launches Visual Studio Online, an online code editor",content="sghldghlhgslghlsdgs"}
                        }

                    },
                    new Blog
                    {
                        Title = "Technology",
                        Post = new List<Post>{
                        new Post { heading= "Mike’s Dot Netting",content="Mikesdotnetting.com covers all things ASP.NET and is authored by Mike Brind, a perennial Microsoft MVP for ASP/ASP.NET."},
                        new Post { heading= "Ode to Code",content="Ode to Code is written by K. Scott Allen, a programmer and Pluralsight author who has over 25 years experience in the industry"},
                        new Post { heading= "Ruby Debugger Using Visual Studio Code",content="No matter how carefully coded, reviewed, and tested your Ruby code is, odds are good that at some point you’ll cause a catastrophic failure to at least one system you’re responsible for."},
                        new Post { heading= "Current trends in cybersecurity",content="sghldghlhgslghlsdgs"}
                        
                        }  
                    }
                    );
                
                context.SaveChanges();
            }
        }

    }

}