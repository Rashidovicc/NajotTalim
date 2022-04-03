using System;

namespace NajotTalim.Services.DTOs
{
    public class StudentForCreation
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public Guid GroupId { get; set; }
    }
}
