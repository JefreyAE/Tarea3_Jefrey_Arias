namespace API_Tarea3.Models
{
    public class Agenda
    {
        public int Id { get; set; }
        public int Hour { get; set; }
        public string Specialty { get; set; }
        public int AppointmentId { get; set; }
        public string? State { get; set; }
        public int UserId { get; set; }
        public Appointment? Appointment { get; set; }

        public Agenda() { }
        public Agenda(int id, int appointmentId, int hour, string state, string specialty, int userId, Appointment appointment)
        {
            Id = id;
            AppointmentId = appointmentId;
            Hour = hour;
            Specialty = specialty;
            State = state;
            UserId = userId;
            Appointment = appointment;
        }
    }
}
