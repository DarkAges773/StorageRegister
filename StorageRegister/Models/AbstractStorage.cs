using StorageRegister.Models.Exceptions;

namespace StorageRegister.Models
{
	public abstract class AbstractStorage
	{
		private readonly List<IStorable> _children = new List<IStorable>();

		public abstract bool Fits(IStorable child);
		public List<IStorable> Children
		{
			get => new List<IStorable>(_children);
		}
		public void AddChild(IStorable child)
		{
			if (!Fits(child)) throw new NotFitsException();
			_children.Add(child);
		}
		public bool RemoveChild(IStorable child) => _children.Remove(child);
	}
}
