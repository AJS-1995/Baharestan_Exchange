using _0_Framework.Infrastructure;
using Contracts.ExpenseContracts;
using Domin.ExpenseDomin;

namespace Infrastructure.Repository
{
    public class CollectionRepository : RepositoryBase<int, Collection>, ICollectionRepository
    {
        private readonly BE_Context _context;
        public CollectionRepository(BE_Context context) : base(context)
        {
            _context = context;
        }
        public CollectionEdit GetDetails(int id)
        {
            var Collection = _context.Collectionss.Select(x => new CollectionEdit
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).FirstOrDefault(x => x.Id == id);
            return Collection;
        }
        public List<CollectionViewModel> GetInActive()
        {
            return _context.Collectionss.Where(x => x.Status == false).Select(x => new CollectionViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                UserId = x.UserId,
            }).OrderBy(x => x.Id).ToList();
        }
        public List<CollectionViewModel> GetRemove()
        {
            return _context.Collectionss.Where(x => x.Deleted == true).Select(x => new CollectionViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                UserId = x.UserId,
            }).OrderBy(x => x.Id).ToList();
        }
        public List<CollectionViewModel> GetViewModel()
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var query = _context.Collectionss.Where(x => x.Status == true && x.Deleted == false).Select(x => new CollectionViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
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
