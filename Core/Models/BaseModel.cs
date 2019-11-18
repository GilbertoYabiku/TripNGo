using System;

namespace Core.Models
{
    public abstract class BaseModel
    {
        public Guid Id  { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreationDate { get; set; }
    }
}