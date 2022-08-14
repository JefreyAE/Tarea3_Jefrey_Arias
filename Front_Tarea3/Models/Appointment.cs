namespace Front_Tarea3.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Appointment_date { get; set; }
        public DateTime Created_at { get; set; }
        //public List<Agenda>? Agendas { get; set; }
        public Appointment() { }
        public Appointment(int id, DateTime appointment_date)
        {
            Id = id;
            Appointment_date = appointment_date;
        }
    }
}
