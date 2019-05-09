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
            [BindProperty]
        public int BlogID  { get; set; }
         [BindProperty]
        public int PostId  { get; set; }

       public IList<Blog> BlogPosts { get; set; }
       public Post selectedPost { get; set; }

       [BindProperty(SupportsGet = true)]
        public int PageNum { get; set;} = 1;
        public int PageSize {get; set;} = 6;

        [BindProperty(SupportsGet = true)]
        public string CurrentSort {get; set;}
        public SelectList SortList {get; set;}
        
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public IList<Post> Post{ get; set; }



        public void  OnGet()

        {
            //b = _context.Blog.Include(b => b.Post).Where(x => x.BlogId == b.BlogId).SingleOrDefault();
            Blogs = _context.Blog.Include(p=>p.Post).ToList();
            BlogPosts= _context.Blog.Include(b => b.Post).Where(x => x.BlogId == BlogID).ToList();
           
            BlogsDropDown=new SelectList(Blogs, "BlogId", "Title");
            var blogs= from b in _context.Post
                 select b;
            Post = blogs.Skip((PageNum-1)*PageSize).Take(PageSize).ToList();

        }

        public void OnPost()
        {
         //  b = _context.Blog.Include(b => b.Post).Where(x => x.BlogId == b.BlogId).SingleOrDefault();

            Blogs = _context.Blog.ToList();
            BlogsDropDown=new SelectList(Blogs, "BlogId", "Title");

          BlogPosts= _context.Blog.Include(b => b.Post).Where(x => x.BlogId == BlogID).ToList();
          
          selectedPost=_context.Post.Where(x => x.PostId == PostId).SingleOrDefault();
          if (selectedPost != null)
          {
          selectedPost.likes+=1;
         _context.SaveChanges();
          }
        }


    }
}
