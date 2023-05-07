namespace CarServiceDataModels.Models
{
    public interface IClientModel : IId
    {
        string Name { get; }
        string Surname { get; }
        string Patronymic { get; }
        string Phone { get; }
    }
}