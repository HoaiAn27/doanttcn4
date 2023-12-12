using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace doannam4.Models
{
    [Table("Dangky")]
    public class Dangky
    {
        [Key]
        public long DkyID { get; set; }
        public string? Emaildky { get; set; }
    }
}
