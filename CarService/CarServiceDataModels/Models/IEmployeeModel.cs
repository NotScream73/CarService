namespace CarServiceDataModels.Models
{
    public interface IEmployeeModel : IId
    {
        string Name { get; }
        string Surname { get; }
        string Patronymic { get; }
        string Phone { get; }
    }
}