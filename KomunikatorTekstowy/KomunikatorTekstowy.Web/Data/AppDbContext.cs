using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KomunikatorTekstowy.Web.Models;

namespace KomunikatorTekstowy.Web.Data
{
    public class AppDbContext :DbContext
    {
        public DbSet<UserDetailData> UserDetailData { get; set; }
        public DbSet<UserMessage> UserMessage { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=komunikatorTekstowy;Trusted_Connection=True;");
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<UserMessage>().HasOne(x => x.Sender).WithMany(g => g.MSent)
        //        .HasForeignKey(x => x.SenderId).OnDelete(DeleteBehavior.Restrict);

        //    modelBuilder.Entity<UserMessage>().HasOne(x => x.Recipient).WithMany(g => g.MReceived)
        //        .HasForeignKey(x => x.RecipentId).OnDelete(DeleteBehavior.Restrict);
        //}
    }
}
