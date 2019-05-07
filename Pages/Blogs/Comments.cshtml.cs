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
        
        // [BindProperty]
        //public Post Post{ get; set; }

        // Drop down SelectList of Posts
        public SelectList PostSelectList {get; set;}

        public CommentsModel(CIDM3312_FinalProjectBlog.Models.BlogDbContext context, ILogger<CommentsModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult OnGet(int? id)
        {
            // Get a list of posts.
            PostSelectList = new SelectList(_context.Post.Include(p=>p.Blog).ToList(), "PostId", "heading",id);
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

            //_context.Post.Add(Comment); 
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}