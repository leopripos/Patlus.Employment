using Patlus.Employment.UseCase.Entities;

namespace Patlus.Employment.Rest.Features.Employees
{
    public class CreateForm
    {
        public string EId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }
    }
}
