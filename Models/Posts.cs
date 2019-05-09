using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CIDM3312_FinalProjectBlog.Models
{
    public class Post
    {
        public int PostId {get; set;}
        public string heading {get; set;}
        public string content {get; set;}
        public string comment {get; set;}
        public int likes {get; set;}
        public string author {get; set;}
        public int BlogId {get; set;}//foreign key

        public Blog Blog {get; set;}//nav prop
      
    }
}