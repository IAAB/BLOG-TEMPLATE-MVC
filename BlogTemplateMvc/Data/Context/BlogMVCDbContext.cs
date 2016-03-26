﻿using BlogTemplateMvc.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogTemplateMvc.Context
{
    public class BlogMVCDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public DbSet<Message> Messages { get; set; }
    }
}