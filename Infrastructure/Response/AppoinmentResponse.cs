using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hospitalpage.Infrastructure.Response
{
    public class AppoinmentResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public double MobileNumber { get; set; }
        public string Age { get; set; }
        public string Sex { get; set; }
        public string DoctorName { get; set; }
        public DateTime AppoinmentTime { get; set; }
        public Boolean AppoinmentStatus { get; set; }
    }
}
