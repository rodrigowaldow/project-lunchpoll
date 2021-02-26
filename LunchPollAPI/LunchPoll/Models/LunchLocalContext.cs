using System;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LunchPoll.Models
{
    public partial class LunchLocalContext : DbContext
    {
        public LunchLocalContext()
        {
        }

        public LunchLocalContext(DbContextOptions<LunchLocalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LunchLocal> LunchLocals { get; set; }
    }
}
