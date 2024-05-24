using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Repositories.Interfaces;

namespace Server.Controllers
{
    [Route("api/roles")]
    //[ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRepository<Roles> _repository;
        public RolesController(IRepository<Roles> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("get_all")]
        public async Task<IEnumerable<Roles>> GetRoles(CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);
        }

        [HttpGet("get")]
        public async Task<Roles> GetRolesById(int id, CancellationToken cancellationToken)
        {
            return await _repository.GetById(id, cancellationToken);
        }

        [HttpPost("add")]
        public async Task AddRoles([FromBody] Roles roles, CancellationToken cancellationToken)
        {
            await _repository.Add(roles, cancellationToken);
        }

        [HttpPost("update")]
        public async Task UpdateRoles([FromBody] Roles roles, CancellationToken cancellationToken)
        {
            await _repository.Update(roles, cancellationToken);
        }

        [HttpPost("remove")]
        public async Task RemoveRoles([FromBody] Roles roles, CancellationToken cancellationToken)
        {
            await _repository.Remove(roles, cancellationToken);
        }
    }
}
