using InsuranceApp.Models;
using InsuranceApp.Repository;

namespace InsuranceApp.Services
{
    public class SchemeDetailsService:ISchemeDetailsService
    {
        private IEntityRepository<SchemeDetails> _entityRepository;
        public SchemeDetailsService(IEntityRepository<SchemeDetails> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public List<SchemeDetails> GetAll()
        {
            var schemeDetailsQuery = _entityRepository.Get();
            var schemeDetails = schemeDetailsQuery.Where(schemeDet => schemeDet.IsActive)
                .ToList();
            return schemeDetails;
        }
        public SchemeDetails Get(int id)
        {
            var schemeDetailsQuery = _entityRepository.Get();
            var schemeDetail = schemeDetailsQuery.Where(schemeDet => schemeDet.DetailId == id && schemeDet.IsActive).FirstOrDefault();
            return schemeDetail;
        }

        public SchemeDetails GetDetailBySchemeId(int id)
        {
            var schemeDetailData = _entityRepository.Get();
            var schemeDetail = schemeDetailData.Where(q => q.SchemeId == id).FirstOrDefault();
            return schemeDetail;
        }
        public SchemeDetails Check(int id)
        {
            return _entityRepository.Get(id);
        }
        public int Add(SchemeDetails schemeDetails)
        {
            return _entityRepository.Add(schemeDetails);
        }
        public SchemeDetails Update(SchemeDetails schemeDetails)
        {
            return _entityRepository.Update(schemeDetails);
        }
        public void Delete(SchemeDetails schemeDetails)
        {
            _entityRepository.Delete(schemeDetails);
        }
    }
}
