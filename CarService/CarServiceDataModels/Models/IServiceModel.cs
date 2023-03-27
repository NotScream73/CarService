namespace CarServiceDataModels.Models
{
	public interface IServiceModel : IId
	{
		string Title { get; }
		double Price { get; }
	}
}