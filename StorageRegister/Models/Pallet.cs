namespace StorageRegister.Models
{
	public class Pallet : AbstractStorage, IExpirable, IMaterial
	{
		public Pallet(int id, float weight, Dimensions dimensions)
		{
			Id = id;
			Weight = weight;
			Dimensions = dimensions;
		}
		public Pallet(int id, float weight, Dimensions dimensions, List<IStorable> children)
		{
			Id = id;
			Weight = weight;
			Dimensions = dimensions;
		}
		public int Id { get; set; }
		public float Weight { get; set; } = 30f; // base weight of the pallet is 30 kg
		public float NetChildrenWeight { get => Children.Cast<IMaterial>().Sum(c => c.Weight); }
		public float NetWeight { get => NetChildrenWeight + Weight; }
		public float Volume { get => Children.Cast<IMaterial>().Sum(c => c.Volume) + (Dimensions.Height * Dimensions.Width * Dimensions.Depth); }
		public Dimensions Dimensions { get; set; }
		public DateOnly? ExpirationDate { get => Children.Cast<IExpirable>().MinBy(e => e.ExpirationDate)?.ExpirationDate; }
		public override bool Fits(IStorable child) // pallets can hold only boxes of any height and with fitting width and depth
		{
			if (child == null) throw new ArgumentNullException();
			if (child is not Box) return false;
			var childBox = (Box)child;
			return Dimensions.Width >= childBox.Dimensions.Width 
				&& Dimensions.Depth >= childBox.Dimensions.Depth;
		}
	}
}
