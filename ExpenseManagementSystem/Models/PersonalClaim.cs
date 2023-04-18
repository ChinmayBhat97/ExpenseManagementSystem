using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExpenseManagementSystem.Models
{
    public class PersonalClaim
    {
        [Key]
        public int claimID { get; set; }
        [DisplayName("Claimant Name")]
        public string claimantName { get; set; }
        [DisplayName("Claimant Email-ID")]
        [EmailAddress]
        public string claimantEmailID { get; set; }
        [DisplayName("Department")]
        public virtual int DeptID { get; set; }
        [ForeignKey("DeptID")]
        public virtual Department Department { get; set; }
        [DisplayName("Manager Name")]
        public string managerName { get; set; }
        [DisplayName("Manager Email-ID")]
        [EmailAddress]
        public string managerEmailID { get; set; }
        [DisplayName("Account Number")]
        public uint accuntNumber { get; set; }
        [DisplayName("IFSC")]
        public string IFSC { get; set; }
        [DisplayName("Claim Description")]
        public string description { get; set; }
        [DisplayName("Billing Date")]
        public DateTime billingDate { get; set; }

        public DateTime claimingDate { get; set; }

        
        [DisplayName("Upload File")]
        [Column(TypeName ="nvarchar(200)")]
        public string ImageFile { get; set; }

        public virtual int stusID { get; set; }
        [ForeignKey("stusID")]
        public virtual ClaimStatus ClaimStatus  { get; set; }

        
    }
}
