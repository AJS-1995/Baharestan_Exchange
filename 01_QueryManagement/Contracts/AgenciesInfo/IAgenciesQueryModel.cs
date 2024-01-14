namespace _01_QueryManagement.Contracts.AgenciesInfo
{
    public interface IAgenciesQueryModel
    {
        AgenciesQueryModel GetAgenciess();
        AgenciesQueryModel GetAgenciess(int id);
    }
}