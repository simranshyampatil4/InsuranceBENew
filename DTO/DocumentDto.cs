using System.ComponentModel.DataAnnotations;

namespace InsuranceApp.DTO
{
    public class DocumentDto
    {
        public int DocumentId { get; set; }

        [Required(ErrorMessage = "Document type is required.")]
        [StringLength(50, ErrorMessage = "Document type must be no more than 50 characters.")]
        public string DocumentType { get; set; }

        [Required(ErrorMessage = "Document name is required.")]
        [StringLength(100, ErrorMessage = "Document name must be no more than 100 characters.")]
        public string DocumentName { get; set; }

        [MaxLength(10 * 1024 * 1024, ErrorMessage = "Maximum file size is 10 MB.")]
        public byte[] ? DocumentFile { get; set; }
        public string Status { get; set; }
        public int CustomerId { get; set; }
        //public bool IsActive { get; set; }
    }
}