using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;database=REALESTATEDB;Integrated Security=True;TrustServerCertificate=Yes");
        }
        public DbSet<Content> Contents { get; set; }
        public DbSet<ContentCategory> ContentCategories { get; set; }
        public DbSet<ContentInteraction> ContentInteractions { get; set; }
        public DbSet<FirmDoc> FirmDocs { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<ContentFavoriteMap> ContentFavoriteMap { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<MessageLine> MessageLine { get; set; }
        public DbSet<OutgoingMessage> OutgoingMessages { get; set; }
        public DbSet<IncomingMessage> IncomingMessages { get; set; }
        public DbSet<MessageRef> MessageRef { get; set; }
    }
}


