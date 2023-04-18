using System.ComponentModel.DataAnnotations;

namespace ExpenseManagementSystem.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        public string departmentName { get; set; }
    }
}
