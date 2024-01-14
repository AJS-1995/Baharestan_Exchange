using _0_Framework.Application;
using Contracts.AgenciesContracts;
using Contracts.UsersContracts.RoleContracts;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Contracts.UsersContracts.UsersContracts
{
    public class UserCreate
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string? FullName { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string? UserName { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string? Password { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string? Mobile { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string? SecurityCod { get; set; }
        public int AgenciesId { get; set; }
        public int IdAgencies { get; set; }
        public int RoleId { get; set; }
        public IFormFile? ProfilePhoto { get; set; }
        public List<RoleViewModel>? Roles { get; set; }
        public List<AgenciesViewModel>? Agencies { get; set; }
        public List<int>? Permissions { get; set; }
    }

}