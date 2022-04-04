using System;
using System.ComponentModel.DataAnnotations;

namespace NajotTalim.Services.DTOs
{
    public class StudentForUpdating
    {
        [Required]
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        [Required]

        public string Phone { get; set; }
        public Guid GroupId { get; set; }
    }
}
