using Microsoft.EntityFrameworkCore;
using Repository_pattern.Models;

namespace Repository_pattern
{
    public class Databasecontext:DbContext
    {
        public Databasecontext(DbContextOptions<Databasecontext> opts) : base(opts) { }

        public DbSet<Diary> Diarys { get; set; }
    }
}
