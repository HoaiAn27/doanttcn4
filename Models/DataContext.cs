using doannam4.Models;
using doannam4.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace doannam4.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Comment> Comments{ get; set; }
        public DbSet<PostAccessCount> PostAccessCounts { get; set; }
        public DbSet<view_Post_Access> PostAccesses { get; set; }
        public DbSet<Dangky> Dangkys { get; set; }
        public DbSet<view_Post_Menu> PostMenus { get; set; }
        public DbSet<AdminMenu> AdminMenus { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }

    }
}
