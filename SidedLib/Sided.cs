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

		/// <summary>
		/// left side setter
		/// </summary>
		/// <param name="value"></param>
		public void Set(T value)
		{
			Side = value;	
		}
		/// <summary>
		/// left side getter
		/// </summary>
		/// <returns></returns>
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

		/// <summary>
		/// Right side setter
		/// </summary>
		/// <param name="value"></param>
		public void Set(T value)
		{
			Side = value;
		}
		/// <summary>
		/// right side getter
		/// </summary>
		/// <returns></returns>
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

		/// <summary>
		/// empty constructor with both side init
		/// </summary>
		public Sided()
		{
			Left = new();
			Right = new();
		}

		/// <summary>
		/// constructor with both side setting option
		/// </summary>
		/// <param name="left"></param>
		/// <param name="right"></param>
		public Sided(T left, T right)
		{
			Left = new();
			Right = new();
			SetBoth(left, right);
		}

		/// <summary>
		/// set both side object
		/// </summary>
		/// <param name="left"></param>
		/// <param name="right"></param>
		public void SetBoth(T left, T right)
		{
			Left.Set(left);
			Right.Set(right);
		}
		/// <summary>
		/// set left side object
		/// </summary>
		/// <param name="left"></param>
		public void SetSide(Left<T> left)
		{
			Left = left;
		}
		/// <summary>
		/// set right side object
		/// </summary>
		/// <param name="left"></param>
		public void SetSide(Right<T> right)
		{
			Right = right;
		}	
	}
}

