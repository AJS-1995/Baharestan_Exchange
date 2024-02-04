using _0_Framework.Domain;
using Domin.ManagementPresonsDomin.PersonsReceiptDomin;

namespace Domin.SafeBoxDomin
{
    public class SafeBox : EntityBase<int>
    {
        public string? Name { get; private set; }
        public string? Treasurer { get; private set; }
        public string? Mobile { get; private set; }
        public List<PersonsReceipt>? PersonsReceipts { get; }
        public SafeBox()
        {
            PersonsReceipts = new List<PersonsReceipt>();
        }
        public SafeBox(string? name, string? treasurer, string? mobile, int userid, int agenciesId)
        {
            Name = name;
            Treasurer = treasurer;
            Mobile = mobile;
            UserId = userid;
            AgenciesId = agenciesId;
        }
        public void Edit(string? name, string? treasurer, string? mobile, int userid, int agenciesId)
        {
            Name = name;
            Treasurer = treasurer;
            Mobile = mobile;
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