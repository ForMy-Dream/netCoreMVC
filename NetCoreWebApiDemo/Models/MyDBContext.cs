

using Microsoft.EntityFrameworkCore;
using System;

namespace NetCoreWebApiDemo.Models
{
    using Microsoft.EntityFrameworkCore;

    public class MyDBContext : DbContext
    {
     
      

        public MyDBContext()
        {
        }

        public MyDBContext(DbContextOptions<MyDBContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 配置实体与数据库表之间的映射关系
            modelBuilder.Entity<Person>().ToTable("Person");
        }
        public virtual DbSet<Person> Person { get; set; } = null!;
    }   

}
