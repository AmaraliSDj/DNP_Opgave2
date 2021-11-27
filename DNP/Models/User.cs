using System.ComponentModel.DataAnnotations;

namespace ToDo.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Domain { get; set; } 
        public string City { get; set; } 
        public int BirthYear { get; set; } 
        public string Role { get; set; } 
        public int SecurityLevel { get; set; }
        public string Password { get; set; }
    }
}