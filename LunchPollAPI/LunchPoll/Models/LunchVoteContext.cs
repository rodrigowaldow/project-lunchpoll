using System;
using Microsoft.EntityFrameworkCore;

namespace LunchPoll.Models
{
    public partial class LunchVoteContext : DbContext
    {
        public LunchVoteContext()
        {
        }

        public LunchVoteContext(DbContextOptions<LunchVoteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LunchVote> LunchVotes { get; set; }
    }
}
