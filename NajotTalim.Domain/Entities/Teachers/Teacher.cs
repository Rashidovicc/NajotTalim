using NajotTalim.Domain.Commons;
using NajotTalim.Domain.Entities.Groups;
using NajotTalim.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NajotTalim.Domain.Entities.Teachers
{
    public class Teacher : IAuditable
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid GroupId { get; set; }
        [ForeignKey(nameof(GroupId))]
        public Group Group { get; set; }
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
