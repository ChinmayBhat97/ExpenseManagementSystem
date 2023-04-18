using System.ComponentModel.DataAnnotations;

namespace ExpenseManagementSystem.Models
{
    public class ClaimStatus
    {
        [Key]
        public int Id { get; set; }

        public string claimStatus { get; set; }
    }
}
