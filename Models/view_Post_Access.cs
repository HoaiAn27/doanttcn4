using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doannam4.Models
{
    [Table("view_Post_Access")]
    public class view_Post_Access
    {
        [Key]
        public long PostID { get; set; }
        public string? Title { get; set; }
        public string? Abstract { get; set; }
        public string? Contents { get; set; }
        public string? Images { get; set; }
        public string? Cre { get; set; }
        public string? Link { get; set; }
        public DateTime CreateDate { get; set; }
        public bool? IsActive { get; set; }
        public int PostOrder { get; set; }
        public int MenuID { get; set; }
        public int Status { get; set; }
        public long AccessCount { get; set; }

    }
}
