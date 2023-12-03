using InsuranceApp.Models;

namespace InsuranceApp.Services
{
    public interface IDocumentService
    {
        List<Document> GetAll();
        Document Get(int id);
        int Add(Document document);
        public Document Check(int id);

        Document Update(Document document);
        public void Delete(Document document);
    }
}
