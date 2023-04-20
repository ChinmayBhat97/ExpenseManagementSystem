using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseManagementSystem.Models
{
    public class Employee: IdentityUser
    {
        [Key]

        public int empID { get; set; }

        public string empName { get; set; }

        public string empUserName { get; set; }
        [EmailAddress]
        public string empEmailID { get; set; }
        [Phone]
        public ulong empPhoneNum { get; set; }

        public virtual int DeptID { get; set; }
        [ForeignKey("DeptID")]
        public virtual Department Department { get; set; }

        public string designation { get; set; }

        public virtual int gendID { get; set; }
        [ForeignKey("gendID")]
        public virtual Gender Gender { get; set; }

        public ulong adhaarCardNum  { get; set; }
        
        public DateTime DateOfJoining { get; set; }

        public string passWord { get; set; }

        public bool keepLoggedIn { get; set; }

    }
}
