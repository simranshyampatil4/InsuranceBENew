using InsuranceApp.Models;

namespace InsuranceApp.Services
{
    public interface ICommissionService
    {
        public List<Commission> GetAll();

        public Commission Get(int id);
        public Commission Check(int id);
        public int Add(Commission commission);
        public Commission Update(Commission commission);
        public void Delete(Commission commission);

    }
}
