using _0_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace Contracts.ExchangeRateContracts
{
    public class ExchangeRateCreate
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public int MainMoneyId { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public int SecondaryMoneyId { get; set; }
    }
}