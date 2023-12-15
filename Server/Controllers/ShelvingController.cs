using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Repositories.Interfaces;

namespace Server.Controllers
{
    [Route("api/shelving")]
    //[ApiController]
    public class ShelvingController : ControllerBase
    {
        private readonly IRepository<Shelving> _repository;
        public ShelvingController(IRepository<Shelving> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("get_all")]
        public async Task<IEnumerable<Shelving>> GetShelving(CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);
        }

        [HttpGet("get")]
        public async Task<Shelving> GetShelvingById(int id, CancellationToken cancellationToken)
        {
            return await _repository.GetById(id, cancellationToken);
        }

        [HttpPost("add")]
        public async Task AddShelving([FromBody] Shelving shelving, CancellationToken cancellationToken)
        {
            await _repository.Add(shelving, cancellationToken);
        }

        [HttpPost("update")]
        public async Task UpdateShelving([FromBody] Shelving shelving, CancellationToken cancellationToken)
        {
            await _repository.Update(shelving, cancellationToken);
        }

        [HttpPost("remove")]
        public async Task RemoveShelving([FromBody] Shelving shelving, CancellationToken cancellationToken)
        {
            await _repository.Remove(shelving, cancellationToken);
        }
    }
}
