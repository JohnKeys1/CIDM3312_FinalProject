using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CIDM3312_FinalProjectBlog.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CIDM3312_FinalProjectBlog.Pages_Blogs
{
    public class IndexModel : PageModel
    {
        private readonly CIDM3312_FinalProjectBlog.Models.BlogDbContext _context;

        public IndexModel(CIDM3312_FinalProjectBlog.Models.BlogDbContext context)
        {
            _context = context;
        }

        public IList<Blog> Blogs { get;set; }
        public SelectList BlogsDropDown{ get; set; }
        public Blog b { get; set; }

       public IList<Blog> BlogPosts { get; set; }


        public void  OnGet()

        {
            //b = _context.Blog.Include(b => b.Post).Where(x => x.BlogId == b.BlogId).SingleOrDefault();
            Blogs = _context.Blog.Include(p=>p.Post).ToList();
            BlogsDropDown=new SelectList(Blogs, "BlogId", "Title");
        }

        public void OnPost()
        {
           // b = _context.Blog.Include(b => b.Post).Where(x => x.BlogId == b.BlogId);

            Blogs = _context.Blog.ToList();
            BlogsDropDown=new SelectList(Blogs, "BlogId", "Title");

          BlogPosts= _context.Blog.Include(b => b.Post).Where(x => x.BlogId == b.BlogId).ToList();
        }


    }
}
