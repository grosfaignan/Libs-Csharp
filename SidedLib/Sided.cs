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
				Side = value;	
		}
		public T Get()
		{
			return Side;
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
			Side = value;
		}
		public T Get()
		{
			return Side;
		}
	}

	/// <summary>
	/// Pan manager for left-right side values
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Sided<T>
	{
		public Left<T> Left { get; private set; }
		public Right<T> Right { get; private set; }


		public Sided()
		{
			Left = new();
			Right = new();
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
			Left = new();
			Right = new();
			Left.Set(left);
			Right.Set(right);

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
			Left.Set(left);
			Right.Set(right);
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

