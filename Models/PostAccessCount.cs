using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doannam4.Models
{
    [Table("PostAccessCount")]
    public class PostAccessCount
    {
        [Key]
        public long AccessID { get; set; }
        public long PostID { get; set; }
        public long AccessCount { get; set; }
    }
}
