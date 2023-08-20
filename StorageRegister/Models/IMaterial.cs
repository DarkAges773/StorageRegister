namespace StorageRegister.Models
{
	internal interface IMaterial
	{
		public float Weight { get; set; }
		public Dimensions Dimensions { get; set; }
		public float Volume { get => (Dimensions.Height * Dimensions.Width * Dimensions.Depth); }
	}
}