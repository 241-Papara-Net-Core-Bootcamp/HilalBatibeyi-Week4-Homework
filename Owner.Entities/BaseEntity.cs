using System;

namespace Owner.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? LastUpdateAt { get; set; }

        public string LastUpdateBy { get; set; }
        public bool Status { get; set; }
    }
}
