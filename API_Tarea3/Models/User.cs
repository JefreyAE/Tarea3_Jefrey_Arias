using Microsoft.AspNetCore.Identity;

namespace API_Tarea3.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int UserId { get; set; }
        public DateTime Birthday { get; set; }  
        public string? Payment_method { get; set; }  

        //public List<Appointment>? Appointments { get; set; }

        public User()
        {

        }
        public User(int id, string name, int userId, DateTime birthday, string payment_method)
        {
            Id = id;
            Name = name;
            UserId = userId;
            Birthday = birthday;
            Payment_method = payment_method;
        }
    }
}
