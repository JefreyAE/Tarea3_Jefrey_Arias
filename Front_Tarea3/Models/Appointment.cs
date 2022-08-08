namespace Front_Tarea3.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Appointment_date { get; set; }
        public string Specialty { get; set; }
        public string State { get; set; }

        public int UserId { get; set; }
        public Agenda? Agenda { get; set; }

        public Appointment()
        {

        }
      
        public Appointment(int id, DateTime appointment_date, string specialty, string state, int userId)
        {
            Id = id;
            Appointment_date = appointment_date;
            Specialty = specialty;
            State = state;
            UserId = userId;
        }
    }
}
