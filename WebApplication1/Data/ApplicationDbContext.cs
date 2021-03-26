using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication1.Models;
using WebApps.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //App03
        public DbSet<Student> Students { get; set; }

        //App04
        public DbSet<Post> Posts { get; set; }
        public DbSet<MessagePost> MessagePosts { get; set; }
        public DbSet<PhotoPost> PhotoPosts { get; set; }
    }
}
