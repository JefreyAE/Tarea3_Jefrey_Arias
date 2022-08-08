namespace Front_Tarea3.Models
{
    public class Agenda
    {
        public int Id { get; set; }
        public int Hour { get; set; }
        public int AppointmentId { get; set; }

        public Agenda() { }
        public Agenda(int id, int appointmentId, int hour)
        {
            Id = id;
            AppointmentId = appointmentId;
            Hour = hour;
        }
    }
}
