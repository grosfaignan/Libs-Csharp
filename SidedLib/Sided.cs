namespace Sided
{
	public class Left<T>
	{
		public T? Side { get; set; }
	}
	public class Right<T>
	{
		public T? Side { get; set; }
	}
	/// <summary>
	/// Pan manager for left-right side values
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Sided<T>
	{
		public Left<T>? Left { get; private set; }
		public Right<T>? Right { get; private set; }

		public Sided()
		{
			Left = new();
			Right = new();
		}
		public Sided(T left, T right)
		{
			Left = new();
			Right = new();
			SetBoth(left, right);
		}
		public void SetBoth(T left, T right)
		{
			Left.Side = left;
			Right.Side =right;
		}
		public void SetSide(Left<T> left)
		{
			Left = left;
		}
		public void SetSide(Right<T> right)
		{
			Right = right;
		}	
	}
}

