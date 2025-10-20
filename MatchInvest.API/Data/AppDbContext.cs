using MatchInvest.API.Models;
using Microsoft.EntityFrameworkCore;

namespace MatchInvest.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Investor> Investors { get; set; }
        public DbSet<Assessor> Assessors { get; set; }
    }
}