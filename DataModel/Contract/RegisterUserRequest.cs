using System.ComponentModel.DataAnnotations;

namespace DataModel.Contracts
{
	public record RegisterUserRequest(
		[Required] string Login,
		[Required] string Password,
		[Required] int Role);
}