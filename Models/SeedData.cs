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
                        new Post { heading= "Non-invasive glucose monitor EasyGlucose takes home Microsoft’s Imagine Cup and $100K",content="Microsoft’s  yearly Imagine Cup student startup competition crowned its latest winner today: EasyGlucose, a non-invasive, smartphone-based method for diabetics to test their blood glucose. It and the two other similarly beneficial finalists presented today at Microsoft’s Build developers conference.",author="Devin Coldewey"},
                        new Post { heading= "Tencent replaces hit mobile game PUBG with a Chinese government-friendly alternative",content="China’s new rules on video games, introduced last month, are having an effect on the country’s gamers. Today, Tencent replaced hugely popular battle royale shooter game PUBG with a more government-friendly alternative that seems primed to pull in significant revenue.",author="Jon Russell"}
                        }// posts content source,techcrunch blog;https://techcrunch.com/2019/05/08

                    },
                    new Blog
                    {
                        Title = "Technology",
                        Post = new List<Post>{
                        new Post { heading= "Amazon Hit by Extensive Fraud With Hackers Siphoning Merchant Funds",content="Amazon.com Inc. said it was hit by an extensive fraud, revealing that unidentified hackers were able to siphon funds from merchant accounts over six months last year.",author="Jonathan Browning"},
                        new Post { heading= "Facebook Picks London to Drive WhatsApp Mobile Payments Globally",content="Facebook Inc. intends to drive a global expansion of mobile payments on WhatsApp from London, accelerating its efforts to make money off the popular messaging service.",author="Kurt Wagner"},
                        new Post { heading= "IBM Brings Blockbuster Bond Deal as Market Defies Trade Drag",content="International Business Machines Corp. kicked off a debt sale that’s likely to make this the corporate-bond market’s busiest week in at least eight months, a rare buying frenzy amid turbulent markets globally.",author="Molly Smith  and Natalya Doris"},
                        new Post { heading= "Brexit to Add to Europe’s Woes in AI Race, Sweden’s Borg Says",content="The loss of the U.K.’s financial power and expertise as a result of Brexit is likely to exacerbate the European Union’s lag in the global technological arms race, according to Anders Borg, a former Swedish finance minister and senior adviser at artificial intelligence company Ipsoft Inc.",author="Hanna Hoikkala  and Niclas Rolander"}
                        
                        }  // posts content source,bloomberg technology blog;https://www.bloomberg.com/news/articles/2019-05-08/
                    }
                    );
                
                context.SaveChanges();
            }
        }

    }

}