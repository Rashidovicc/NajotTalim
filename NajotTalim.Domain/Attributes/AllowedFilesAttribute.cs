using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NajotTalim.Domain.Attributes
{
    public class AllowedFilesAttribute : ValidationAttribute
    {
        private readonly string[] extensions;
        public AllowedFilesAttribute(string [] extensions) 
        {
            this.extensions = extensions;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                if (!extensions.Contains(extension.ToLower()))
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }
            return ValidationResult.Success;
        }      

        public string GetErrorMessage()
        {
            return $"Faqat ({string.Join(",", extensions)}) turidagi fayllar yuborish mumkin";
        }

    }
}
