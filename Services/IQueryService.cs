using InsuranceApp.Models;

namespace InsuranceApp.Services
{
    public interface IQueryService
    {
        public List<Query> GetAll();
        public Query Get(int id);
        public int Add(Query query);
        public Query Check(int id);
        public Query Update(Query query);
        public void Delete(Query query);
    }
}
