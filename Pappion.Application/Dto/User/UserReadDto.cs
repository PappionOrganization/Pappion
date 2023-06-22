using Pappion.Domain.Constants;

namespace Pappion.Application.Dto.User
{
    public class UserReadDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal Rating { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Location { get; set; }
        public UserRoles Role { get; set; }
    }
}
