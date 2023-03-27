namespace CarServiceDataModels.Models
{
	public interface ICarModel : IId
	{
		string Number { get; }
	}
}