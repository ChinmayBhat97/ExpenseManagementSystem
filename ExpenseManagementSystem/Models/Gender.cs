using System.ComponentModel.DataAnnotations;

namespace ExpenseManagementSystem.Models
{
    public class Gender
    {
        [Key] 
        public int Id { get; set; }

        public string empGender { get; set; }
    }
}
