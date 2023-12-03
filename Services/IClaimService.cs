using InsuranceApp.Models;

namespace InsuranceApp.Services
{
    public interface IClaimService
    {
        public List<Claim> GetAll();
        public Claim Get(int id);
        public Claim Check(int id);
        public int Add(Claim claim);
        public Claim Update(Claim claim);
        public void Delete(Claim claim);
    }
}
