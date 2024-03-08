using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Pkcs;
using WheelWander.Consts;
using WheelWander.Models;

namespace WheelWander.Vailidation;

public class CustomValidationBikeAttribute: ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var dbContext = (WheelWanderDbContext)validationContext.GetService(typeof(WheelWanderDbContext));
        string inputValue = (string)value;
        
        if (validationContext.ObjectType.GetProperty("status") != null)
        {
            if (!Status.IsValidStatus(inputValue))
            {
                return new ValidationResult(ErrorMessage);
            }
        }
        else if (validationContext.ObjectType.GetProperty("currentStationId") != null)
        {
            bool stationExists = dbContext.Stations.Any(s => s.Id == inputValue);
           
            if (!stationExists)
            {
                return new ValidationResult(ErrorMessage);
            }
        }
        else
        {
            throw new InvalidOperationException("Validation attribute used in unsupported context.");
        }

        return ValidationResult.Success;
    }
}