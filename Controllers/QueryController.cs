using InsuranceApp.DTO;
using InsuranceApp.Exceptions;
using InsuranceApp.Models;
using InsuranceApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryController : ControllerBase
    {
        private IQueryService _queryService;
        public QueryController(IQueryService queryService)
        {
            _queryService = queryService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<QueryDto> queryDtos = new List<QueryDto>();
            var queries = _queryService.GetAll();
            if (queries.Count > 0)
            {
                foreach (var query in queries)
                    queryDtos.Add(ConvertToDto(query));
                return Ok(queryDtos);
            }
            throw new EntityNotFoundError("No claims created");
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var query = _queryService.Get(id);
            if (query != null)
                return Ok(ConvertToDto(query));
            throw new EntityNotFoundError("No such query Found");
        }
        [HttpPost]
        public IActionResult Add(QueryDto queryDto)
        {
            var query = ConvertToModel(queryDto);
            int id = _queryService.Add(query);
            if (id != null)
                return Ok(id);
            throw new EntityInsertError("Some issue while adding record");
        }
        [HttpPut]
        public IActionResult Update(QueryDto queryDto)
        {
            var existingQuery = _queryService.Check(queryDto.QueryId);
            if (existingQuery != null)
            {
                var query = ConvertToModel(queryDto);
                var modifiedQuery = _queryService.Update(query);
                return Ok(ConvertToDto(modifiedQuery));
            }
            throw new EntityNotFoundError("No such record exists");
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteById(int id)
        {
            var queryToDelete = _queryService.Check(id);
            if (queryToDelete != null)
            {
                _queryService.Delete(queryToDelete);
                return Ok(queryToDelete.QueryId);
            }
            throw new EntityNotFoundError("No such record exists");
        }
        private Query ConvertToModel(QueryDto queryDto)
        {
            return new Query()
            {
                QueryId = queryDto.QueryId,
                QueryTitle = queryDto.QueryTitle,
                QueryDate = queryDto.QueryDate,
                QueryMessage = queryDto.QueryMessage,
                Reply = queryDto.Reply,
                CustomerId = queryDto.CustomerId,
                IsActive = true
            };
        }
        private QueryDto ConvertToDto(Query query)
        {
            return new QueryDto()
            {
                QueryId = query.QueryId,
                QueryTitle = query.QueryTitle,
                QueryDate = query.QueryDate,
                QueryMessage = query.QueryMessage,
                Reply = query.Reply,
                CustomerId = query.CustomerId,

            };
        }
    }
}
