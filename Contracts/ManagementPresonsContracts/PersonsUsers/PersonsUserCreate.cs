using _0_Framework.Application;
using Contracts.AgenciesContracts;
using Contracts.ManagementPresonsContracts.PersonsContracts;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Contracts.ManagementPresonsContracts.PersonsUsers
{
	public class PersonsUserCreate
	{
		[Required(ErrorMessage = ValidationMessages.IsRequired)]
		public string? UserName { get; set; }
		[Required(ErrorMessage = ValidationMessages.IsRequired)]
		public string? Password { get; set; }
		[Required(ErrorMessage = ValidationMessages.IsRequired)]
		public int PersonsId { get; set; }
		public IFormFile? ProfilePhoto { get; set; }
		public int AgenciesId { get; set; }
		public int IdAgencies { get; set; }
		public List<PersonsViewModel>? Persons { get; set; }
		public List<AgenciesViewModel>? Agencies { get; set; }
	}
}