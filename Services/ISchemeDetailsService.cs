using InsuranceApp.Models;

namespace InsuranceApp.Services
{
    public interface ISchemeDetailsService
    {
        public List<SchemeDetails> GetAll();
        public SchemeDetails Get(int id);
        public SchemeDetails Check(int id);
        public int Add(SchemeDetails schemeDetails);
        public SchemeDetails Update(SchemeDetails schemeDetails);
        public void Delete(SchemeDetails schemeDetails);
        public SchemeDetails GetDetailBySchemeId(int id);
    }
}
