using Hospital.Data;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Controllers
{
    public class DoctorsController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();


        public IActionResult BookAppointment()
        {
            var doctors=context.doctors.ToList();
            return View(doctors);
        }

        public IActionResult CompleteBookAppointment(string DrName)
        {
            var doctor = context.doctors.FirstOrDefault(e=>e.Name==DrName);

            return View(doctor);
        }

        public IActionResult GetDataToPatient(string drName, string patientName, string date, string time)
        {
            var doctor = context.doctors.FirstOrDefault(e => e.Name == drName);

            var appointmentData = new Book
            {
                Name = patientName,
                AppointmentTime = time,
                AppointmentDate = DateTime.Parse(date),
                doctors=new List<Doctor> { doctor }
            };


            context.books.Add(appointmentData);
            context.SaveChanges();

            return RedirectToAction("CompleteBookAppointment", new { drName });
        }
       

        public IActionResult ShowBookAppointment(string drName)
        {
            var doctor = context.doctors.Include(d => d.books).FirstOrDefault(e => e.Name == drName);
            
            return View(doctor);
        }
    }
}
