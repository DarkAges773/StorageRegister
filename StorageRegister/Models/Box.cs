namespace StorageRegister.Models
{
	public class Box : IStorable, IExpirable, IMaterial
	{
		private readonly int _expirationMargin = 100;
        public Box(float weight, Dimensions dimensions, DateOnly expirationDate)
        {
			Weight = weight;
			Dimensions = dimensions;
			ExpirationDate = expirationDate;
        }       
		public Box(float weight, Dimensions dimensions, DateOnly? expirationDate, DateOnly productionDate)
        {
			Weight = weight;
			Dimensions = dimensions;
			ProductionDate = productionDate;
			ExpirationDate = expirationDate ?? productionDate.AddDays(_expirationMargin);
        }
		public float Weight { get; set; }
		public DateOnly? ExpirationDate { get; set; }
		public DateOnly? ProductionDate { get; set; }
		public Dimensions Dimensions { get; set; }
	}
}
