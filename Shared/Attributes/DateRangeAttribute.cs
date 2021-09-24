using System;
using System.ComponentModel.DataAnnotations;

namespace Duck.Shared.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DateRangeAttribute : ValidationAttribute
    {
        DateTime _from; // 1991-01-01
        DateTime _to; // DateTime.Now

        public DateRangeAttribute(string? from = null, string? to = null)
        {
            _from = DateTime.Parse(from ?? "1991-01-01");
            _to = DateTime.Parse(to ?? DateTime.Now.ToString("yyyy-MM-dd"));
        }

        public string GetErrorMessage() => $"The date must be between '{_from:yyyy-MM-dd}' and '{_to:yyyy-MM-dd}'";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is null)
            {
                return ValidationResult.Success;
            }

            var date = (DateTime)value;

            if (date < _from && date > _to)
            {
                return new ValidationResult(GetErrorMessage());
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}