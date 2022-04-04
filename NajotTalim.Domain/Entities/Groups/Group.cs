using NajotTalim.Domain.Commons;
using NajotTalim.Domain.Enums;
using System;

namespace NajotTalim.Domain.Entities.Groups
{
    public class Group : IAuditable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public ItemState State { get; set; } = ItemState.Created;
        public string Image { get; set; }

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
