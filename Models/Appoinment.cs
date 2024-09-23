using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospitalpage.Models
{
    public class Appoinment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // This ensures auto-increment
        [Column("A_Id")]
        public int Id { get; set; }
        [Column("A_UserName", TypeName = "varchar(200)")]
        public string UserName { get; set; }
        [Column("A_MobileNumber")]
        public double MobileNumber { get; set; }
        [Column("A_Age", TypeName="varchar(200)")]
        public string Age { get; set; }
        [Column("A_Sex", TypeName="varchar(10)")]
        public string Sex { get; set; }
        [Column("A_DoctorName", TypeName="varchar(200)")]
        public string DoctorName { get; set; }
        [Column("A_AppoinmentTime")]
        public DateTime AppoinmentTime { get; set; } = DateTime.Now;
        [Column("A_AppoinmentStatus", TypeName = "tinyint")]
        public Boolean AppoinmentStatus { get; set; } 
    }
}
