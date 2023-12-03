using InsuranceApp.Models;
using InsuranceApp.Repository;

namespace InsuranceApp.Services
{
    public class DocumentService : IDocumentService
    {
        private IEntityRepository<Document> _entityRepository;

        public DocumentService(IEntityRepository<Document> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public List<Document> GetAll()
        {
            var documentQuery = _entityRepository.Get();
            var documents = documentQuery.ToList();
            return documents;
        }

        public Document Get(int id)
        {
            var documentQuery = _entityRepository.Get();
            var document = documentQuery.Where(document => document.DocumentId == id && document.IsActive)
                                      .FirstOrDefault();
            return document;
        }

        public int Add(Document document)
        {
            return _entityRepository.Add(document);
        }
        public Document Check(int id)
        {
            return _entityRepository.Get(id);
        }

        public Document Update(Document document)
        {
            return _entityRepository.Update(document);
        }

        public void Delete(Document document)
        {
            _entityRepository.Delete(document);
        }

    }
}



