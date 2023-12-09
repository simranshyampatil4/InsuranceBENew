using System.ComponentModel.DataAnnotations;

namespace InsuranceApp.DTO
{
    public class DocumentDto
    {
        public int DocumentId { get; set; }
        public string DocumentType { get; set; }
        public string DocumentName { get; set; }
        // public byte[] DocumentFile { get; set; }
        public int CustomerId { get; set; }
        public IFormFile File { get; set; }
        public byte[]? DocumentFile { get; set; }
        public string Status { get; set; }


        //public bool IsActive { get; set; }
    }
}