using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CIDM3312_FinalProjectBlog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CIDM3312_FinalProjectBlog.Pages_Blogs
{
    public class CommentsModel : PageModel
    {
        private readonly CIDM3312_FinalProjectBlog.Models.BlogDbContext _context;
        private readonly ILogger _logger;

        [BindProperty]
        public int PostId {get; set;}
        [BindProperty]
        public string Comment {get; set;}
        public IList<Blog> AllPosts { get; set; }
        [BindProperty(SupportsGet = true)]
        public int PageNum { get; set;} = 1;

        [BindProperty(SupportsGet = true)]
        public int PageSize {get; set;} = 6;

        [BindProperty(SupportsGet = true)]
        public string CurrentSort {get; set;}
             
        public SelectList SortList {get; set;}
        
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
       
        public IList<Post> Post{ get; set; }
        public SelectList PostSelectList {get; set;}

        public CommentsModel(CIDM3312_FinalProjectBlog.Models.BlogDbContext context, ILogger<CommentsModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            // Get a list of posts.
            PostSelectList = new SelectList(_context.Post.Include(p=>p.Blog).ToList(), "PostId", "heading");
            AllPosts=_context.Blog.Include(p=>p.Post).ToList();

             var blogs= from b in _context.Post
                 select b;
             if (!string.IsNullOrEmpty(SearchString))
            {  
                 blogs = _context.Post.Where(p => p.heading.Contains(SearchString));
             }
               
             

             //var query = _context.Post.Select(p => p);
            List<SelectListItem> sortItems = new List<SelectListItem> {
                new SelectListItem { Text = "Posts Ascending", Value = "post_asc" },
                new SelectListItem { Text = "Posts Descending", Value = "post_desc"},
               

            };
            SortList = new SelectList(sortItems, "Value", "Text", CurrentSort);

            switch (CurrentSort)
            {
                case "post_asc":
                   blogs = blogs.OrderBy(m => m.heading);
                    break;
                case "post_desc":
                  blogs = blogs.OrderByDescending(m => m.heading);
                    break;
            }
            Post = blogs.Skip((PageNum-1)*PageSize).Take(PageSize).ToList();

           return Page();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            _logger.LogInformation($"Add a comment. Post.Comment = '{Comment}'");
            _logger.LogWarning($"id= '{PostId}'");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Post PostToModify = _context.Post.Where(p => p.PostId == PostId).FirstOrDefault();
            PostToModify.comment = Comment;

            
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}