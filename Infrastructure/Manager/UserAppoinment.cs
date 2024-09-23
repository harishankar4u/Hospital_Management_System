using Hospitalpage.Infrastructure.Contract;
using Hospitalpage.Models;
using Microsoft.EntityFrameworkCore;
using Hospitalpage.Infrastructure.Response;

namespace Hospitalpage.Infrastructure.Manager
{
    public class UserAppoinment : IAppoinment
    {
        private readonly ApplicationDbContext _dbContext;
        public UserAppoinment(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> createAppoinmentAsync(Appoinment value)
        {
            await _dbContext.Set<Appoinment>().AddAsync(value);
            // Save changes to the database
            await _dbContext.SaveChangesAsync();
            return "Appointment created successfully!";
        }
        public async Task<IEnumerable<AppoinmentResponse>> GetAllAppoinmentAsync()
        {
            var appointments = await _dbContext.Set<Appoinment>().ToListAsync();
            // Map appointments to AppoinmentResponse if needed
            return appointments.Select(a => new AppoinmentResponse
            {
                // Map properties from Appoinment to AppoinmentResponse
                Id = a.Id,
                UserName = a.UserName,
                MobileNumber = a.MobileNumber,
                Age = a.Age,
                Sex = a.Sex,
                DoctorName = a.DoctorName,
                AppoinmentTime = a.AppoinmentTime,
                AppoinmentStatus = a.AppoinmentStatus
            });
        }
        //public async Task<AppoinmentResponse> GetAppoinmentAsync(int id)
        //{
        //    // Retrieve appointments by filtering with the given id
        //    var appointments = await _dbContext.Set<Appoinment>()
        //                                       .Where(a => a.Id == id)
        //                                       .ToListAsync();

        //    // Map appointments to AppoinmentResponse
        //    return appointments.Select(a => new AppoinmentResponse
        //    {
        //        Id = a.Id,
        //        UserName = a.UserName,
        //        MobileNumber = a.MobileNumber,
        //        Age = a.Age,
        //        Sex = a.Sex,
        //        DoctorName = a.DoctorName,
        //        AppoinmentTime = a.AppoinmentTime,
        //        AppoinmentStatus = a.AppoinmentStatus
        //    });
        //}
        public async Task<AppoinmentResponse> GetAppoinmentAsync(int id)
        {
            // Retrieve a single appointment by filtering with the given id
            var appointment = await _dbContext.Set<Appoinment>()
                                              .FirstOrDefaultAsync(a => a.Id == id);

            // If no appointment is found, return null or handle accordingly
            if (appointment == null)
            {
                return null;
            }

            // Map the Appoinment object to AppoinmentResponse
            return new AppoinmentResponse
            {
                Id = appointment.Id,
                UserName = appointment.UserName,
                MobileNumber = appointment.MobileNumber,
                Age = appointment.Age,
                Sex = appointment.Sex,
                DoctorName = appointment.DoctorName,
                AppoinmentTime = appointment.AppoinmentTime,
                AppoinmentStatus = appointment.AppoinmentStatus
            };
        }

    }
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) // Pass the options to the base constructor
        {
        }

        // DbSets for your entities
        public DbSet<Appoinment> Appoinments { get; set; }
        public DbSet<AppoinmentResponse> AppoinmentResponse { get; set; } = default!;

        // Other DbSets and configurations
    }

}
