using Microsoft.EntityFrameworkCore;
using Video_Library.Data;

namespace Video_Library.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Member> Members { set; get; }

        public DbSet<Video> Videos { set; get; }

        public DbSet<BorrowData> BorrowDatas { set; get; }
    }
}
