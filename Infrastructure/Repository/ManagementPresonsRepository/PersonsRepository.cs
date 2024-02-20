using _0_Framework.Infrastructure;
using Contracts.ManagementPresonsContracts.PersonsContracts;
using Domin.ManagementPresonsDomin.PersonsDomin;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.ManagementPresonsRepository
{
    public class PersonsRepository : RepositoryBase<int, Persons>, IPersonsRepository
    {
        private readonly BE_Context _context;
        public PersonsRepository(BE_Context context) : base(context)
        {
            _context = context;
        }
        public PersonsEdit GetDetails(int id)
        {
            var Persons = _context.Personss.Select(x => new PersonsEdit
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                Company = x.Company,
                Guarantor = x.Guarantor,
                Personnel = x.Personnel,
                Mobile = x.Mobile,
                AgenciesId = x.AgenciesId,
            }).FirstOrDefault(x => x.Id == id);
            return Persons;
        }
        public List<PersonsViewModel> GetInActive()
        {
            return _context.Personss.Where(x => x.Status == false)
                .Include(x => x.Agenciess).Select(x => new PersonsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    Company = x.Company,
                    Guarantor = x.Guarantor,
                    Mobile = x.Mobile,
                    GuarantorPhoto = x.GuarantorPhoto,
                    Personnel = x.Personnel,
                    SaveDate = x.SaveDate,
                    Deleted = x.Deleted,
                    Status = x.Status,
                    UserId = x.UserId,
                    AgenciesId = x.AgenciesId,
                    AgenciesName = x.Agenciess.Name
                }).OrderByDescending(x => x.Id).ToList();
        }
        public List<PersonsViewModel> GetInActive(int agenciesId)
        {
            var query = _context.Personss.Where(x => x.Status == false && x.AgenciesId == agenciesId)
                .Include(x => x.Agenciess).Select(x => new PersonsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    Company = x.Company,
                    Guarantor = x.Guarantor,
                    Mobile = x.Mobile,
                    GuarantorPhoto = x.GuarantorPhoto,
                    Personnel = x.Personnel,
                    SaveDate = x.SaveDate,
                    Deleted = x.Deleted,
                    Status = x.Status,
                    UserId = x.UserId,
                    AgenciesId = x.AgenciesId,
                    AgenciesName = x.Agenciess.Name
                });
            var result = query.OrderByDescending(x => x.Id).ToList();
            return result;
        }
        public List<PersonsViewModel> GetRemove()
        {
            var query = _context.Personss.Where(x => x.Deleted == true)
                .Include(x => x.Agenciess).Select(x => new PersonsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    Company = x.Company,
                    Guarantor = x.Guarantor,
                    Mobile = x.Mobile,
                    GuarantorPhoto = x.GuarantorPhoto,
                    Personnel = x.Personnel,
                    SaveDate = x.SaveDate,
                    Deleted = x.Deleted,
                    Status = x.Status,
                    UserId = x.UserId,
                    AgenciesId = x.AgenciesId,
                    AgenciesName = x.Agenciess.Name
                });
            var result = query.OrderByDescending(x => x.Id).ToList();
            return result;
        }
        public List<PersonsViewModel> GetRemove(int agenciesId)
        {
            var query = _context.Personss.Where(x => x.Deleted == true && x.AgenciesId == agenciesId)
                .Include(x => x.Agenciess).Select(x => new PersonsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    Company = x.Company,
                    Guarantor = x.Guarantor,
                    Mobile = x.Mobile,
                    GuarantorPhoto = x.GuarantorPhoto,
                    Personnel = x.Personnel,
                    SaveDate = x.SaveDate,
                    Deleted = x.Deleted,
                    Status = x.Status,
                    UserId = x.UserId,
                    AgenciesId = x.AgenciesId,
                    AgenciesName = x.Agenciess.Name
                });
            var result = query.OrderByDescending(x => x.Id).ToList();
            return result;
        }
        public List<PersonsViewModel> GetViewModel()
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var query = _context.Personss.Where(x => x.Status == true && x.Deleted == false)
                .Include(x => x.Agenciess).Select(x => new PersonsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    Company = x.Company,
                    Guarantor = x.Guarantor,
                    Mobile = x.Mobile,
                    GuarantorPhoto = x.GuarantorPhoto,
                    Personnel = x.Personnel,
                    SaveDate = x.SaveDate,
                    Deleted = x.Deleted,
                    Status = x.Status,
                    UserId = x.UserId,
                    AgenciesId = x.AgenciesId,
                    AgenciesName = x.Agenciess.Name
                });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            return result;
        }
        public List<PersonsViewModel> GetViewModel(int agenciesId)
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var query = _context.Personss.Where(x => x.Status == true && x.Deleted == false && x.AgenciesId == agenciesId)
                .Include(x => x.Agenciess).Select(x => new PersonsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    Company = x.Company,
                    Guarantor = x.Guarantor,
                    Mobile = x.Mobile,
                    GuarantorPhoto = x.GuarantorPhoto,
                    Personnel = x.Personnel,
                    SaveDate = x.SaveDate,
                    Deleted = x.Deleted,
                    Status = x.Status,
                    UserId = x.UserId,
                    AgenciesId = x.AgenciesId,
                    AgenciesName = x.Agenciess.Name
                });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            return result;
        }
    }
}