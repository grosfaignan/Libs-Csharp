using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Sided
{

	/// <summary>
	/// Generic class for Left side of sided
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Left<T>
	{

		private T Side { get; set; }
		public void Set(T value)
		{
				this.Side = value;	
		}
		public T Get()
		{
			return this.Side;
		}
	}
	/// <summary>
	/// Generic Class for Right side of Sided
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Right<T>
	{
		private T Side { get; set; }

		public void Set(T value)
		{
			this.Side = value;
		}
		public T Get()
		{
			return this.Side;
		}
	}

	/// <summary>
	/// Pan manager for left-right side values
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Sided<T>
	{
		public Left<T> Left;// { get; private set; }
		public Right<T> Right;// { get; private set; }

		public Sided()
		{
			this.Instanciate();
		}
		// left and right point to the same object, need to correct that
		//public Sided(T both)
		//{
		//	this.Instanciate();
		//	this.Left.Set(both);
		//	this.Right.Set(both);
		//}
		public Sided(T left, T right)
		{
			this.Instanciate();
			this.Left.Set(left);
			this.Right.Set(right);

		}
		private void Instanciate()
		{
			this.Left = new Left<T>();
			this.Right = new Right<T>();
		}

		/// <summary>
		/// left right point to same reference objet, nee to correct that
		/// </summary>
		//public void SetBoth(T both)
		//{

		//	this.Left.Set(both);
		//	this.Right.Set(both);
		//}

		public void SetBoth(T left, T right)
		{
			this.Left.Set(left);
			this.Right.Set(right);
		}
		public void SetSide(Left<T> left)
		{
			this.Left = left;
		}
		public void SetSide(Right<T> right)
		{
			this.Right = right;
		}	
	}
}

