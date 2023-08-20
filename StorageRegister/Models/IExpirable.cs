namespace StorageRegister.Models
{
	public interface IExpirable
	{
		public DateOnly? ExpirationDate { get; }
	}
}