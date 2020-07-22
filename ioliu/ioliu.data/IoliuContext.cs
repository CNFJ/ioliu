using ioliu.domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace ioliu.data
{
    public class IoliuContext:DbContext
    {
        public IoliuContext(DbContextOptions<IoliuContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
        //public DbSet<SystemUser> systemUsers { get; set; }
        public DbSet<Resume> resumes { get; set; }
        public DbSet<Education> educations { get; set; }
        public DbSet<Work> works { get; set; }
        public DbSet<Img> imgs { get; set; }
        public DbSet<Blog> blogs { get; set; }
        public DbSet<Blog_Comment> blog_Comments { get; set; }
        public DbSet<Blog_Tag> blog_Tags { get; set; }
        public DbSet<Blog_Type> blog_Types { get; set; }
    }
}
