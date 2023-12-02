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
        private readonly IRepository<Shelving> repository;
        public ShelvingController(IRepository<Shelving> dbContext)
        {
            repository = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        [HttpGet("get_all")]
        public async Task<IEnumerable<Shelving>> GetShelving(CancellationToken cancellationToken)
        {
            return await repository.GetAll(cancellationToken);
        }

        [HttpGet("get")]
        public async Task<Shelving> GetShelvingById(int id, CancellationToken cancellationToken)
        {
            return await repository.GetById(id, cancellationToken);
        }

        [HttpPost("add")]
        public async Task AddShelving([FromBody] Shelving shelving, CancellationToken cancellationToken)
        {
            await repository.Add(shelving, cancellationToken);
        }

        [HttpPost("update")]
        public async Task UpdateShelving([FromBody] Shelving shelving, CancellationToken cancellationToken)
        {
            await repository.Update(shelving, cancellationToken);
        }

        [HttpPost("remove")]
        public async Task RemoveShelving([FromBody] Shelving shelving, CancellationToken cancellationToken)
        {
            await repository.Remove(shelving, cancellationToken);
        }
    }
}
