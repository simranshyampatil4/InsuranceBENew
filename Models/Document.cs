using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceApp.Models
{
    public class Document
    {
        [Key]
        public int DocumentId { get; set; }

        [Required(ErrorMessage = "Document type is required.")]
        [StringLength(50, ErrorMessage = "Document type must be no more than 50 characters.")]
        public string DocumentType { get; set; }

        [Required(ErrorMessage = "Document name is required.")]
        [StringLength(100, ErrorMessage = "Document name must be no more than 100 characters.")]
        public string DocumentName { get; set; }

        //[Required(ErrorMessage = "Document file is required.")]
        //[MaxLength(10 * 1024 * 1024, ErrorMessage = "Maximum file size is 10 MB.")]
        public byte[]? DocumentFile { get; set; } // Assuming a maximum file size of 10 MB

        [Required(ErrorMessage = "Customer is required.")]
        public Customer Customer { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Document status is required.")]
        public bool IsActive { get; set; }
    }
}