using NajotTalim.Domain.Commons;
using NajotTalim.Domain.Entities.Teachers;
using NajotTalim.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NajotTalim.Domain.Entities.Groups
{
    public class Group : IAuditable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public Guid TeacherId { get; set; }
        [ForeignKey(nameof(TeacherId))]
        public Teacher Teacher { get; set; }
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
