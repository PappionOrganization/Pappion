namespace Pappion.Domain.Entities
{
    public class PhoneNumber
    {
        public Guid Id { get; set; }
        public string Phone { get; set; }

        //n:1
        public Guid UserId { get; set; }
        public User User { get; set; }

    }
}
