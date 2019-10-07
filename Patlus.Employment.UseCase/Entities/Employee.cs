using Patlus.Common.UseCase.Entities;
using System;

namespace Patlus.Employment.UseCase.Entities
{
    public class Employee : IStandardEntity
    {
        public Guid Id { get; set; }
        public string EId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }

        public Guid CreatorId { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public bool Archived { get; set; }
    }
}
