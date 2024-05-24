using System.ComponentModel.DataAnnotations;

namespace DataModel.Contracts
{	public record LoginUserRequest(
		[Required] string Login,
		[Required] string Password);
}