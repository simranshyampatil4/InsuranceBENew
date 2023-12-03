using InsuranceApp.DTO;
using InsuranceApp.Exceptions;
using InsuranceApp.Models;
using InsuranceApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet("get")]
        public IActionResult Get()
        {
            List<DocumentDto> documentDtos = new List<DocumentDto>();
            var documents = _documentService.GetAll();
            if (documents.Count > 0)
            {
                foreach (var document in documents)
                    documentDtos.Add(ConvertToDto(document));
                return Ok(documentDtos);
            }

            throw new EntityNotFoundError("No documents created");
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var document = _documentService.Get(id);
            if (document != null)
                return Ok(ConvertToDto(document));
            throw new EntityNotFoundError("No such document found");
        }

        [HttpPost]
        public IActionResult Add(DocumentDto documentDto)
        {
            var documentModel = ConvertToModel(documentDto);
            int id = _documentService.Add(documentModel);
            if (id != 0)
                return Ok(id);
            throw new EntityInsertError("Some issue while adding the document");
        }

        [HttpPut]
        public IActionResult Update(DocumentDto documentDto)
        {
            var existingDocument = _documentService.Check(documentDto.DocumentId);
            if (existingDocument != null)
            {
                var document = ConvertToModel(documentDto);
                var modifiedDocument = _documentService.Update(document);
                return Ok(ConvertToDto(modifiedDocument));
            }
            throw new EntityNotFoundError("No such document record exists");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteById(int id)
        {
            var documentToDelete = _documentService.Check(id);
            if (documentToDelete != null)
            {
                _documentService.Delete(documentToDelete);
                return Ok(documentToDelete.DocumentId);
            }
            throw new EntityNotFoundError("No such record exists");
        }

        private DocumentDto ConvertToDto(Document document)
        {
            return new DocumentDto()
            {
                DocumentId = document.DocumentId,
                DocumentType = document.DocumentType,
                DocumentName = document.DocumentName,
                DocumentFile = document.DocumentFile,
                CustomerId = document.CustomerId,
                Status = document.Status,
                //IsActive = document.IsActive
            };
        }

        private Document ConvertToModel(DocumentDto documentDto)
        {
            return new Document()
            {
                DocumentId = documentDto.DocumentId,
                DocumentType = documentDto.DocumentType,
                DocumentName = documentDto.DocumentName,
                DocumentFile = documentDto.DocumentFile,
                CustomerId = documentDto.CustomerId,
                Status = documentDto.Status,
                IsActive = true
            };
        }
    }
}

