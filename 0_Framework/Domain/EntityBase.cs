using _0_Framework.Application;

namespace _0_Framework.Domain
{
    public class EntityBase<T>
    {
        public T? Id { get; set; }
        public string? SaveDate { get; set; }
        public bool Status { get; set; }
        public bool Deleted { get; set; }
        public int UserId { get; set; }
        public int AgenciesId { get; set; }
        public EntityBase()
        {
            SaveDate = DateTime.Now.ToFarsiFull();
            Status = true;
            Deleted = false;
        }
    }
}