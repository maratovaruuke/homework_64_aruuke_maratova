using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Homework_64_aruuke_maratova.Models
{
    public class WebApiContext : DbContext
    {
        public DbSet<Country> CountriesNew { get; set; }

        public WebApiContext(DbContextOptions<WebApiContext> options) : base(options) {}
    }
}
