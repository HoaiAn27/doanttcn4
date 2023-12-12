using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace doannam4.Models
{
    [Table("Contact")]
    public class Contact
    {
        [Key]
        public long ContactID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
    }
}
