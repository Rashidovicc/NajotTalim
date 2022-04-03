using NajotTalim.Domain.Commons;
using NajotTalim.Domain.Enums;
using System;

namespace NajotTalim.Domain.Entities.Students
{
    public class Student : IAuditable
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public Guid GroupId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public ItemState State { get; set; } = ItemState.Created;

        public void Update()
        {
            UpdatedAt = DateTime.Now;
            State = ItemState.Updated;
        }

        public void Delete()
        {
            State = ItemState.Deleted;
        }
    }
}
