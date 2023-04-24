
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ExpenseManagementSystem.Models
{
    public class PersonalClaim
    {
        [Key]
        public int claimID { get; set; }
        [DisplayName("Claimant Name")]
        public string? claimantName { get; set; }
        [DisplayName("Claimant Email-ID")]
        [EmailAddress]
        public string? claimantEmailID { get; set; }
        [DisplayName("Department")]
        public virtual int DeptID { get; set; }
        [ForeignKey("DeptID")]
        public virtual Department Department { get; set; }
        [DisplayName("Manager Name")]
        public string? managerName { get; set; }
        [DisplayName("Manager Email-ID")]
        [EmailAddress]
        public string? managerEmailID { get; set; }
        [DisplayName("Account Number")]
        public int accuntNumber { get; set; }
        [DisplayName("IFSC")]
        public string? IFSC { get; set; }
        [DisplayName("Claim Description")]
        public string? description { get; set; }
        [DisplayName("Billing Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime billingDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime claimingDate { get; set; }



        [AllowNull]
        public virtual int stusID { get; set; }
        [ForeignKey("stusID")]
        public virtual ClaimStatus? ClaimStatus  { get; set; }

        [NotMapped]
        [AllowNull]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Image Name")]
        public string? ImageName { get; set; }

        [DisplayName("Amount")]
        public int claimAmount { get; set; }

        [AllowNull]
        [DisplayName("Manager Remarks")]
        public string remarkManager { get; set; }

        [AllowNull]
        [DisplayName("Finance Manager Remarks")]
        public string remarkFinanace { get; set; }

    }
}
