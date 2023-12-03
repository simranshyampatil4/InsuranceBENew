using InsuranceApp.Models;
using InsuranceApp.Repository;
using Microsoft.EntityFrameworkCore;

namespace InsuranceApp.Services
{
    public class AgentService : IAgentService
    {
        private IEntityRepository<Agent> _entityRepository;

        public AgentService(IEntityRepository<Agent> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public List<Agent> GetAll()
        {
            var agentQuery = _entityRepository.Get();
            var agents = agentQuery.Where(agent => agent.IsActive)
                                  .Include(agent => agent.Customers)
                                  .ToList();
            return agents;
        }

        public Agent Get(int id)
        {
            var agentQuery = _entityRepository.Get();
            var agent = agentQuery.Where(agent => agent.AgentId == id && agent.IsActive).FirstOrDefault();
            return agent;
        }
        public Agent Check(int id)
        {
            return _entityRepository.Get(id);
        }


        public int Add(Agent agent)
        {
            return _entityRepository.Add(agent);
        }

        public Agent Update(Agent agent)
        {
            return _entityRepository.Update(agent);
        }

        public void Delete(Agent agent)
        {
            _entityRepository.Delete(agent);
        }

    }
}



    

