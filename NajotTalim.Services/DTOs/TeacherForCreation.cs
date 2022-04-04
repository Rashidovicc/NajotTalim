using Microsoft.AspNetCore.Http;
using System;

namespace NajotTalim.Services.DTOs
{
    public class TeacherForCreation
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid GroupId { get; set; }
        public IFormFile Image { get; set; }
    }
}
