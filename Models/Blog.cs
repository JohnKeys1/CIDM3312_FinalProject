using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CIDM3312_FinalProjectBlog.Models
{
    public class Blog
    {
        public int BlogId {get; set;}
        public string Title {get; set;}
        public List <Post> Post{get; set;} 
    }
}