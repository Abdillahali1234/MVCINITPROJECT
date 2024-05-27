namespace Hospital.Models
{
    public class Book
    {

        public int BookId { get; set; }
        public string Name { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }

       public  List <Doctor> doctors {  get; set; }


    }
}
