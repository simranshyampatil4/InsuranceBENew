using InsuranceApp.Models;
using InsuranceApp.Repository;

namespace InsuranceApp.Services
{
    public class QueryService:IQueryService
    {
        private IEntityRepository<Query> _entityRepository;
        public QueryService(IEntityRepository<Query> entityRepository)
        {
            _entityRepository = entityRepository;
        }
        public List<Query> GetAll()
        {
            var querySqlQuery = _entityRepository.Get();
            return querySqlQuery.Where(query => query.IsActive).ToList();
        }
        public Query Get(int id)
        {
            var querySqlQuery = _entityRepository.Get();
            return querySqlQuery.Where(query => query.IsActive && query.QueryId == id).FirstOrDefault();
        }
        public int Add(Query query)
        {
            return _entityRepository.Add(query);
        }
        public Query Check(int id)
        {
            return _entityRepository.Get(id);
        }
        public Query Update(Query query)
        {
            return _entityRepository.Update(query);
        }
        public void Delete(Query query)
        {
            _entityRepository.Delete(query);
        }
    }
}
