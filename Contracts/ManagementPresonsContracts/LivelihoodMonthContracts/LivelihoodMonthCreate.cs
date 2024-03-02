using _0_Framework.Application;
using Contracts.AgenciesContracts;
using Contracts.ManagementPresonsContracts.LivelihoodContracts;
using Contracts.MoneyContracts;
using System.ComponentModel.DataAnnotations;

namespace Contracts.ManagementPresonsContracts.LivelihoodMonthContracts
{
    public class LivelihoodMonthCreate
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public int Year { get; set; }
        public int Month { get; set; }
        public int LivelihoodId { get; set; }
        public int PersonsId { get; set; }
        public decimal Amount { get; set; }
        public int MoneyId { get; set; }
        public int AgenciesId { get; set; }
        public int IdAgencies { get; set; }
        public List<AgenciesViewModel>? Agencies { get; set; }
        public List<LivelihoodViewModel>? Livelihoods { get; set; }
        public List<MoneyViewModel>? Money { get; set; }
        public string? PersonName { get; set; }
    }
}