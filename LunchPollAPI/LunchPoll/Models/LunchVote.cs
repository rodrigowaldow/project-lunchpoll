using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LunchPoll.Models
{
    public partial class LunchVote
    {
        [Key]
        public int VoteId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string UserEmail { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("LunchLocal")]
        public int LocalId { get; set; }
        public LunchLocal LunchLocal { get; set; }
    }
}
