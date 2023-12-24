using _0_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace Contracts.SafeBoxContracts
{
    public class SafeBoxCreate
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string? Name { get; set; }
        public string? Treasurer { get; set; }
        public string? Mobile { get; set; }
    }
}
