using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace LunchPoll.Models
{
    public partial class LunchLocal
    {
        [Key]
        public int LocalId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string LocalName { get; set; }

        [Column(TypeName = "int")]
        public int VoteCount { get; set; }

        public ICollection<LunchVote> UsersVote { get; set; }
    }
}
