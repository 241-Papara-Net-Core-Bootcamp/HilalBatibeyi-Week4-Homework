using Owner.Entities;
using System;

namespace Owner.API.Model
{

    public class OwnerModel : BaseEntity
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }
    }
}
