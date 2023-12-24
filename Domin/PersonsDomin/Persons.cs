using _0_Framework.Domain;

namespace Domin.PersonsDomin
{
    public class Persons : EntityBase<int>
    {
        public string? Name { get; private set; }
        public string? Mobile { get; private set; }
        public string? Address { get; private set; }
        public string? Company { get; private set; }
        public string? Guarantor { get; private set; }
        public string? GuarantorPhoto { get; private set; }
        public Persons(){}
        public Persons(string? name, string? mobile, string? address, string? company, string? guarantor, string? guarantorPhoto, int userid, int agenciesId)
        {
            Name = name;
            Mobile = mobile;
            Address = address;
            Company = company;
            Guarantor = guarantor;
            GuarantorPhoto = guarantorPhoto;
            UserId = userid;
            AgenciesId = agenciesId;
        }
        public void Edit(string? name, string? mobile, string? address, string? company, string? guarantor, string? guarantorPhoto, int userid, int agenciesId)
        {
            Name = name;
            Mobile = mobile;
            Address = address;
            Company = company;
            Guarantor = guarantor;
            if (!string.IsNullOrWhiteSpace(guarantorPhoto))
                GuarantorPhoto = guarantorPhoto;
            UserId = userid;
            AgenciesId = agenciesId;
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