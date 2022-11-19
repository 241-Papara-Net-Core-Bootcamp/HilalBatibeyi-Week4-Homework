using Owner.Core.Entities;
using System;

namespace Owner.Entities.DTOs
{
    public class OwnerDto : IDto
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }
    }
}
