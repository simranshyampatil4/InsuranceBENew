using InsuranceApp.Models;
using InsuranceApp.Repository;

namespace InsuranceApp.Services
{
    public class ClaimService:IClaimService
    {
        private IEntityRepository<Claim> _entityRepository;
        public ClaimService(IEntityRepository<Claim> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public List<Claim> GetAll()
        {
            var claimQuery = _entityRepository.Get();
            var claims = claimQuery.Where(claim => claim.IsActive)
                .ToList();
            return claims;
        }
        public Claim Get(int id)
        {
            var claimQuery = _entityRepository.Get();
            var claim = claimQuery.Where(claim => claim.ClaimId == id && claim.IsActive).FirstOrDefault();
            return claim;
        }
        public Claim Check(int id)
        {
            return _entityRepository.Get(id);
        }
        public int Add(Claim claim)
        {
            return _entityRepository.Add(claim);
        }
        public Claim Update(Claim claim)
        {
            return _entityRepository.Update(claim);
        }
        public void Delete(Claim claim)
        {
            _entityRepository.Delete(claim);
        }
    }
}
