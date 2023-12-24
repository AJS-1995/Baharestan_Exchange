using _0_Framework.Domain;

namespace Domin.PersonnelDomin
{
    public class Personnel : EntityBase<int>
    {
        public string? FullName { get; private set; }
        public string? Fathers_Name { get; private set; }
        public string? Mobile { get; private set; }
        public string? Address { get; private set; }
        public string? Cart_Id { get; private set; }
        public string? Photo { get; private set; }
        public Personnel(){}
        public Personnel(string? fullName, string? fathersName, string? mobile, string? address, string? cartId, string? photo, int userid, int agenciesId)
        {
            FullName = fullName;
            Fathers_Name = fathersName;
            Mobile = mobile;
            Address = address;
            Cart_Id = cartId;
            Photo = photo;
            UserId = userid;
            AgenciesId = agenciesId;
        }
        public void Edit(string? fullName, string? fathersName, string? mobile, string? address, string? cartId, string? photo, int userid, int agenciesId)
        {
            FullName = fullName;
            Fathers_Name = fathersName;
            Cart_Id = cartId;
            Mobile = mobile;
            Address = address;
            if (!string.IsNullOrWhiteSpace(photo))
                Photo = photo;
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