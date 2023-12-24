using _0_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace Contracts.UsersContracts.RoleContracts
{
    public class RoleCreate
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string? Name { get; set; }
        public int Cod { get; set; }
        public string? NamePersian { get; set; }
    }
}