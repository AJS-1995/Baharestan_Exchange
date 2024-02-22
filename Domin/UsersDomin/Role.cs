using _0_Framework.Domain;

namespace Domin.UsersDomin
{
	public class Role : EntityBase<int>
    {
        public string? Name { get; set; }
        public int Cod { get; set; }
        public string? NamePersian { get; set; }
        public List<User>? Users { get; set; }
        public Role() { }
        public Role(string name, string namepersian, int userId)
        {
            Name = name;
            NamePersian = namepersian;
            Cod = 1;
            Users = new List<User>();
            UserId = userId;
        }
        public void Edit(string name, string namepersian, int userId)
        {
            Name = name;
            NamePersian = namepersian;
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