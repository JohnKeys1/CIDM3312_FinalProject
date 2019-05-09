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
        public int PageSize {get; set;} = 3;

        [BindProperty(SupportsGet = true)]
        public string CurrentSort {get; set;}
        public SelectList SortList {get; set;}
        
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;



        public void  OnGet()

        {
            //b = _context.Blog.Include(b => b.Post).Where(x => x.BlogId == b.BlogId).SingleOrDefault();
            Blogs = _context.Blog.Include(p=>p.Post).ToList();
            BlogPosts= _context.Blog.Include(b => b.Post).Where(x => x.BlogId == BlogID).ToList();
            // //  if (!string.IsNullOrEmpty(SearchString))
            // // {
            // //     Blogs = _context.Blog.Where(p => p.Post.Contains(SearchString));
            // // }
            
            // // if (!string.IsNullOrEmpty(MovieGenre))
            // // {
            // //     movies = movies.Where(x => x.Genre == MovieGenre);
            // // }

            // // Genres = new SelectList(await genreQuery.Distinct().ToListAsync());

            // // var query = _context.Movie.Select(m => m);
            // List<SelectListItem> sortItems = new List<SelectListItem> {
            //     new SelectListItem { Text = "Title Ascending", Value = "title_asc" },
            //     new SelectListItem { Text = "Title  Descending", Value = "title_desc"},
               

            // };
            // SortList = new SelectList(sortItems, "Value", "Text", CurrentSort);

            // switch (CurrentSort)
            // {
            //     case "title_asc":
            //        Blogs = _context.Blogs.OrderBy(m => m.Title);
            //         break;
            //     case "title_desc":
            //          Blogs = _context.Blog.OrderByDescending(m => m.Title);
            //         break;
            // }
            // Blogs = await Blogs.Skip((PageNum-1)*PageSize).Take(PageSize).ToListAsync();
            BlogsDropDown=new SelectList(Blogs, "BlogId", "Title");
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
