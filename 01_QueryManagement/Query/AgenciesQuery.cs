using _01_QueryManagement.Contracts.AgenciesInfo;
using Infrastructure;

namespace _01_QueryManagement.Query
{
    public class AgenciesQuery : IAgenciesQueryModel
    {
        private readonly BE_Context _context;
        public AgenciesQuery(BE_Context context)
        {
            _context = context;
        }
        public AgenciesQueryModel GetAgenciess()
        {
            var Agencies = _context.Agenciess.Select(x => new AgenciesQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                Mobile = x.Mobile,
                Responsible = x.Responsible
            }).FirstOrDefault();
            return Agencies;
        }
    }
}