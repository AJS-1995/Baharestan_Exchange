using _0_Framework.Infrastructure;
using Contracts.ManagementPresonsContracts.PersonsUsers;
using Domin.ManagementPresonsDomin.PersonsUsers;
using Domin.PersonsUsersDomin;

namespace Infrastructure.Repository.PersonsUsersRepository
{
    public class PersonsUserRepository : RepositoryBase<int, PersonsUser>, IPersonsUserRepository
    {
        private readonly BE_Context _context;
        public PersonsUserRepository(BE_Context context) : base(context)
        {
            _context = context;
        }
        public PersonsUser GetBy(string? PersonsUsername)
        {
            return _context.PersonsUsers.FirstOrDefault(x => x.UserName == PersonsUsername);
        }
        public PersonsUserEdit GetDetails(int id)
        {
            var role = _context.PersonsUsers.Select(x => new PersonsUserEdit
            {
                Id = x.Id,
                AgenciesId = x.AgenciesId,
                PersonsId = x.PersonsId,
                UserName = x.UserName,
            }).FirstOrDefault(x => x.Id == id);
            return role;
        }
        public List<PersonsUserViewModel> GetViewModel()
        {
            var agencies = _context.Agenciess.Select(x => new { x.Id, x.Name }).ToList();
            var persons = _context.Personss.Select(x => new { x.Id, x.Name }).ToList();
            var user = _context.Users.Select(x => new { x.Id, x.FullName }).ToList();
            var query = _context.PersonsUsers.Where(x => x.Status == true && x.Deleted == false).Select(x => new PersonsUserViewModel
            {
                Id = x.Id,
                PersonsId = x.PersonsId,
                UserName= x.UserName,
                User_Id = x.UserId,
                ProfilePhoto = x.ProfilePhoto,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                IdAgencies = x.AgenciesId
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.AgenciesName = agencies.FirstOrDefault(x => x.Id == item.IdAgencies)?.Name);
            result.ForEach(item => item.PersonsName = persons.FirstOrDefault(x => x.Id == item.PersonsId)?.Name);
            result.ForEach(item => item.UserName = user.FirstOrDefault(x => x.Id == item.User_Id)?.FullName);
            return result;
        }
        public List<PersonsUserViewModel> GetRemove()
        {
            var agencies = _context.Agenciess.Select(x => new { x.Id, x.Name }).ToList();
            var persons = _context.Personss.Select(x => new { x.Id, x.Name }).ToList();
            var user = _context.Users.Select(x => new { x.Id, x.FullName }).ToList();
            var query = _context.PersonsUsers.Where(x => x.Deleted == true).Select(x => new PersonsUserViewModel
            {
                Id = x.Id,
                PersonsId = x.PersonsId,
                UserName = x.UserName,
                User_Id = x.UserId,
                ProfilePhoto = x.ProfilePhoto,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                IdAgencies = x.AgenciesId
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.AgenciesName = agencies.FirstOrDefault(x => x.Id == item.IdAgencies)?.Name);
            result.ForEach(item => item.PersonsName = persons.FirstOrDefault(x => x.Id == item.PersonsId)?.Name);
            result.ForEach(item => item.UserName = user.FirstOrDefault(x => x.Id == item.User_Id)?.FullName);
            return result;
        }
        public List<PersonsUserViewModel> GetInActive()
        {
            var agencies = _context.Agenciess.Select(x => new { x.Id, x.Name }).ToList();
            var persons = _context.Personss.Select(x => new { x.Id, x.Name }).ToList();
            var user = _context.Users.Select(x => new { x.Id, x.FullName }).ToList();
            var query = _context.PersonsUsers.Where(x => x.Status == false).Select(x => new PersonsUserViewModel
            {
                Id = x.Id,
                PersonsId = x.PersonsId,
                UserName = x.UserName,
                User_Id = x.UserId,
                ProfilePhoto = x.ProfilePhoto,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                IdAgencies = x.AgenciesId
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.AgenciesName = agencies.FirstOrDefault(x => x.Id == item.IdAgencies)?.Name);
            result.ForEach(item => item.PersonsName = persons.FirstOrDefault(x => x.Id == item.PersonsId)?.Name);
            result.ForEach(item => item.UserName = user.FirstOrDefault(x => x.Id == item.User_Id)?.FullName);
            return result;
        }
        public List<PersonsUserViewModel> GetViewModel(int agenciesId)
        {
            var agencies = _context.Agenciess.Select(x => new { x.Id, x.Name }).ToList();
            var persons = _context.Personss.Select(x => new { x.Id, x.Name }).ToList();
            var user = _context.Users.Select(x => new { x.Id, x.FullName }).ToList();
            var query = _context.PersonsUsers.Where(x => x.Status == true && x.Deleted == false && x.AgenciesId == agenciesId).Select(x => new PersonsUserViewModel
            {
                Id = x.Id,
                PersonsId = x.PersonsId,
                UserName = x.UserName,
                User_Id = x.UserId,
                ProfilePhoto = x.ProfilePhoto,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                IdAgencies = x.AgenciesId
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.AgenciesName = agencies.FirstOrDefault(x => x.Id == item.IdAgencies)?.Name);
            result.ForEach(item => item.PersonsName = persons.FirstOrDefault(x => x.Id == item.PersonsId)?.Name);
            result.ForEach(item => item.UserName = user.FirstOrDefault(x => x.Id == item.User_Id)?.FullName);
            return result;
        }
        public List<PersonsUserViewModel> GetRemove(int agenciesId)
        {
            var agencies = _context.Agenciess.Select(x => new { x.Id, x.Name }).ToList();
            var persons = _context.Personss.Select(x => new { x.Id, x.Name }).ToList();
            var user = _context.Users.Select(x => new { x.Id, x.FullName }).ToList();
            var query = _context.PersonsUsers.Where(x => x.Deleted == true && x.AgenciesId == agenciesId).Select(x => new PersonsUserViewModel
            {
                Id = x.Id,
                PersonsId = x.PersonsId,
                UserName = x.UserName,
                User_Id = x.UserId,
                ProfilePhoto = x.ProfilePhoto,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                IdAgencies = x.AgenciesId
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.AgenciesName = agencies.FirstOrDefault(x => x.Id == item.IdAgencies)?.Name);
            result.ForEach(item => item.PersonsName = persons.FirstOrDefault(x => x.Id == item.PersonsId)?.Name);
            result.ForEach(item => item.UserName = user.FirstOrDefault(x => x.Id == item.User_Id)?.FullName);
            return result;
        }
        public List<PersonsUserViewModel> GetInActive(int agenciesId)
        {
            var agencies = _context.Agenciess.Select(x => new { x.Id, x.Name }).ToList();
            var persons = _context.Personss.Select(x => new { x.Id, x.Name }).ToList();
            var user = _context.Users.Select(x => new { x.Id, x.FullName }).ToList();
            var query = _context.PersonsUsers.Where(x => x.Status == false && x.AgenciesId == agenciesId).Select(x => new PersonsUserViewModel
            {
                Id = x.Id,
                PersonsId = x.PersonsId,
                UserName = x.UserName,
                User_Id = x.UserId,
                ProfilePhoto = x.ProfilePhoto,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                IdAgencies = x.AgenciesId
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.AgenciesName = agencies.FirstOrDefault(x => x.Id == item.IdAgencies)?.Name);
            result.ForEach(item => item.PersonsName = persons.FirstOrDefault(x => x.Id == item.PersonsId)?.Name);
            result.ForEach(item => item.UserName = user.FirstOrDefault(x => x.Id == item.User_Id)?.FullName);
            return result;
        }
    }
}