using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Http;
namespace HR.Utailites
{

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class ValidateImageAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is IFormFile file)
            {
                if (file.ContentType != "image/jpeg" && file.ContentType != "image/png")
                {
                    ErrorMessage = "Please upload a valid image (JPEG or PNG).";
                    return false;
                }

                if (file.Length > 5 * 1024 * 1024) // 5MB
                {
                    ErrorMessage = "The image size should be less than 5MB.";
                    return false;
                }

                return true;
            }

            return false;
        }
    }

}
