using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace doannam4.Models
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        public long CommentID { get; set; }
        public long PostID { get; set; }
        public string? NameUs { get; set; }
        public string? Email { get; set; }
        public string? ContentCm { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
