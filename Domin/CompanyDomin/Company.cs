namespace Domin.CompanyDomin
{
    public class Company
    {
        public int Id { get; private set; }
        public string? Name { get; private set; }
        public string? Address { get; private set; }
        public string? Mobile { get; private set; }
        public string? Responsible { get; private set; }
        public string? Logo { get; private set; }
        public Company() { }
        public Company(string? name, string? address, string? mobile, string? responsible, string? logo)
        {
            Name = name;
            Address = address;
            Mobile = mobile;
            Responsible = responsible;
            Logo = logo;
        }
        public void Edit(string? name, string? address, string? mobile, string? responsible, string? logo)
        {
            Name = name;
            Address = address;
            Mobile = mobile;
            Responsible = responsible;
            if (!string.IsNullOrWhiteSpace(logo))
                Logo = logo;
        }
    }
}