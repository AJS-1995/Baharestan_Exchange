using _0_Framework.Application;
using Contracts.MoneyContracts;
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
        public decimal PriceBey { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public decimal PriceSell { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public int SecondaryMoneyId { get; set; }
        public string? DateDay { get; set; }
        public List<MoneyViewModel>? Moneys { get; set; }
    }
}