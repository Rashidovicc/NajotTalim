using Microsoft.AspNetCore.Http;

namespace NajotTalim.Services.DTOs
{
    public class GroupForCreation
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public IFormFile Image { get; set; }

    }
}
