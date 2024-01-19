using _0_Framework.Infrastructure;
using Contracts.PersonnelContracts;
using Domin.PersonnelDomin;

namespace Infrastructure.Repository
{
    public class PersonnelRepository : RepositoryBase<int, Personnel>, IPersonnelRepository
    {
        private readonly BE_Context _context;
        public PersonnelRepository(BE_Context context) : base(context)
        {
            _context = context;
        }
        public List<PersonnelViewModel> GetAll()
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var agencies = _context.Agenciess.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.Personnels.Where(x => x.Deleted == false).Select(x => new PersonnelViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                Fathers_Name = x.Fathers_Name,
                Cart_Id = x.Cart_Id,
                Address = x.Address,
                Mobile = x.Mobile,
                Photo = x.Photo,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                User_Id = x.UserId,
                AgenciesId = x.AgenciesId,
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.User_Name = ((users.FirstOrDefault(x => x.Id == item.User_Id)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.User_Id)?.UserName));
            result.ForEach(item => item.NameAgencies = agencies.FirstOrDefault(x => x.Id == item.AgenciesId)?.Name);
            return result;
        }
        public PersonnelEdit GetDetails(int id)
        {
            var Personnel = _context.Personnels.Select(x => new PersonnelEdit
            {
                Id = x.Id,
                FullName = x.FullName,
                Fathers_Name = x.Fathers_Name,
                Cart_Id = x.Cart_Id,
                Address = x.Address,
                Mobile = x.Mobile,
                AgenciesId = x.AgenciesId,
            }).FirstOrDefault(x => x.Id == id);
            return Personnel;
        }
        public List<PersonnelViewModel> GetInActive()
        {
            var agencies = _context.Agenciess.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.Personnels.Where(x => x.Status == false).Select(x => new PersonnelViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                Fathers_Name = x.Fathers_Name,
                Cart_Id = x.Cart_Id,
                Address = x.Address,
                Mobile = x.Mobile,
                Photo = x.Photo,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                User_Id = x.UserId,
                AgenciesId = x.AgenciesId,
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.NameAgencies = agencies.FirstOrDefault(x => x.Id == item.AgenciesId)?.Name);
            return result;
        }
        public List<PersonnelViewModel> GetInActive(int agenciesId)
        {
            var agencies = _context.Agenciess.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.Personnels.Where(x => x.Status == false && x.AgenciesId == agenciesId).Select(x => new PersonnelViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                Fathers_Name = x.Fathers_Name,
                Cart_Id = x.Cart_Id,
                Address = x.Address,
                Mobile = x.Mobile,
                Photo = x.Photo,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                User_Id = x.UserId,
                AgenciesId = x.AgenciesId,
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.NameAgencies = agencies.FirstOrDefault(x => x.Id == item.AgenciesId)?.Name);
            return result;
        }
        public List<PersonnelViewModel> GetRemove()
        {
            var agencies = _context.Agenciess.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.Personnels.Where(x => x.Deleted == true).Select(x => new PersonnelViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                Fathers_Name = x.Fathers_Name,
                Cart_Id = x.Cart_Id,
                Address = x.Address,
                Mobile = x.Mobile,
                Photo = x.Photo,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                User_Id = x.UserId,
                AgenciesId = x.AgenciesId,
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.NameAgencies = agencies.FirstOrDefault(x => x.Id == item.AgenciesId)?.Name);
            return result;
        }
        public List<PersonnelViewModel> GetRemove(int agenciesId)
        {
            var agencies = _context.Agenciess.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.Personnels.Where(x => x.Deleted == true && x.AgenciesId == agenciesId).Select(x => new PersonnelViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                Fathers_Name = x.Fathers_Name,
                Cart_Id = x.Cart_Id,
                Address = x.Address,
                Mobile = x.Mobile,
                Photo = x.Photo,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                User_Id = x.UserId,
                AgenciesId = x.AgenciesId,
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.NameAgencies = agencies.FirstOrDefault(x => x.Id == item.AgenciesId)?.Name);
            return result;
        }
        public List<PersonnelViewModel> GetViewModel()
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var agencies = _context.Agenciess.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.Personnels.Where(x => x.Status == true && x.Deleted == false).Select(x => new PersonnelViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                Fathers_Name = x.Fathers_Name,
                Cart_Id = x.Cart_Id,
                Address = x.Address,
                Mobile = x.Mobile,
                Photo = x.Photo,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                User_Id = x.UserId,
                AgenciesId = x.AgenciesId,
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.User_Name = ((users.FirstOrDefault(x => x.Id == item.User_Id)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.User_Id)?.UserName));
            result.ForEach(item => item.NameAgencies = agencies.FirstOrDefault(x => x.Id == item.AgenciesId)?.Name);
            return result;
        }
        public List<PersonnelViewModel> GetViewModel(int agenciesId)
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var agencies = _context.Agenciess.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.Personnels.Where(x => x.Status == true && x.Deleted == false && x.AgenciesId == agenciesId).Select(x => new PersonnelViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                Fathers_Name = x.Fathers_Name,
                Cart_Id = x.Cart_Id,
                Address = x.Address,
                Mobile = x.Mobile,
                Photo = x.Photo,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                User_Id = x.UserId,
                AgenciesId = x.AgenciesId,
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.User_Name = ((users.FirstOrDefault(x => x.Id == item.User_Id)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.User_Id)?.UserName));
            result.ForEach(item => item.NameAgencies = agencies.FirstOrDefault(x => x.Id == item.AgenciesId)?.Name);
            return result;
        }
    }
}