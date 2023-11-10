using WebApplication1.Abstractions;

namespace WebApplication1.Domain.Entity
{
    public class User : BaseEntity
    {
        public string FirstName { get;set;}
        public string LastName { get;set;}
        public string Email { get;set;}
    }
}
