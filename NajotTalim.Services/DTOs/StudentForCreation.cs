﻿using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace NajotTalim.Services.DTOs
{
    public class StudentForCreation
    {
        [Required]
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        [Required]

        public string Phone { get; set; }
        public Guid GroupId { get; set; }
        public IFormFile Image { get; set; }
    }
}
