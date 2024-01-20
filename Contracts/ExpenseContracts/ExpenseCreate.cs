using _0_Framework.Application;
using Contracts.AgenciesContracts;
using Contracts.MoneyContracts;
using Contracts.PersonnelContracts;
using Contracts.SafeBoxContracts;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Contracts.ExpenseContracts
{
    public class ExpenseCreate
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string? Description { get; set; }
        public int Collection_Id { get; set; }
        public string? N_Invoice { get; set; }
        public decimal Amount { get; set; }
        public string? Date { get; set; }
        public IFormFile? Ph_Invoice { get; set; }
        public int PersonnelId { get; set; }
        public int SafeBoxId { get; set; }
        public int MoneyId { get; set; }
        public int AgenciesId { get; set; }
        public int IdAgencies { get; set; }
        public List<AgenciesViewModel>? Agencies { get; set; }
        public List<CollectionViewModel>? Collections { get; set; }
        public List<PersonnelViewModel>? Personnels { get; set; }
        public List<SafeBoxViewModel>? SafeBoxs { get; set; }
        public List<MoneyViewModel>? Moneys { get; set; }
    }
}
