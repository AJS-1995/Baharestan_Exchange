using _0_Framework.Infrastructure;
using Contracts.PersonsContracts;
using Domin.PersonsDomin;

namespace Infrastructure.Repository
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
                Mobile = x.Mobile,
            }).FirstOrDefault(x => x.Id == id);
            return Persons;
        }
        public List<PersonsViewModel> GetInActive()
        {
            var query = _context.Personss.Where(x => x.Status == false).Select(x => new PersonsViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                Company = x.Company,
                Guarantor = x.Guarantor,
                Mobile = x.Mobile,
                GuarantorPhoto = x.GuarantorPhoto,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                UserId = x.UserId,
            }).OrderByDescending(x => x.Id).ToList();
            return query;
        }
        public List<PersonsViewModel> GetRemove()
        {
            var query = _context.Personss.Where(x => x.Deleted == true).Select(x => new PersonsViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                Company = x.Company,
                Guarantor = x.Guarantor,
                Mobile = x.Mobile,
                GuarantorPhoto = x.GuarantorPhoto,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                UserId = x.UserId,
            }).OrderByDescending(x => x.Id).ToList();
            return query;
        }
        public List<PersonsViewModel> GetViewModel()
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var query = _context.Personss.Where(x => x.Status == true && x.Deleted == false).Select(x => new PersonsViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                Company = x.Company,
                Guarantor = x.Guarantor,
                Mobile = x.Mobile,
                GuarantorPhoto = x.GuarantorPhoto,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                UserId = x.UserId,
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            return result;
        }
    }
}