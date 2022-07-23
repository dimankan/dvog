using Dvog.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dvog.DataAccess
{
    public class DvogDbContext : DbContext
    {
        public DvogDbContext(DbContextOptions<DvogDbContext> options) : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Author> Authors { get; set; }

    }
}
