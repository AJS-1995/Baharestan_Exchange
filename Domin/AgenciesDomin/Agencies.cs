using _0_Framework.Application;

namespace Domin.AgenciesDomin
{
    public class Agencies
    {
        public int Id { get; private set; }
        public string? Name { get; private set; }
        public string? Address { get; private set; }
        public string? Mobile { get; private set; }
        public string? Responsible { get; private set; }
        public int CompanyId { get; private set; }
        public string? SaveDate { get; private set; }
        public bool Status { get; private set; }
        public bool Deleted { get; private set; }
        public int UserId { get; private set; }
        public Agencies() { }
        public Agencies(string? name, string? address, string? mobile, string? responsible, int companyId, int userId)
        {
            Name = name;
            Address = address;
            Mobile = mobile;
            Responsible = responsible;
            CompanyId = companyId;
            UserId = userId;
            SaveDate = DateTime.Now.ToFarsiFull();
            Status = true;
            Deleted = false;
        }
        public void Edit(string? name, string? address, string? mobile, string? responsible, int companyId, int userId)
        {
            Name = name;
            Address = address;
            Mobile = mobile;
            Responsible = responsible;
            CompanyId = companyId;
            UserId = userId;
        }
        public void InActive()
        {
            Status = false;
        }
        public void Active()
        {
            Status = true;
        }
        public void Remove()
        {
            Deleted = true;
        }
        public void Reset()
        {
            Deleted = false;
        }
    }
}