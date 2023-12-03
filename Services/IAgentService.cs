using InsuranceApp.Models;

namespace InsuranceApp.Services
{
    public interface IAgentService
    {
        List<Agent> GetAll();
        Agent Get(int id);
        int Add(Agent agent);
        public Agent Check(int id);

        Agent Update(Agent agent);
        public void Delete(Agent agent);
    }
}
