using Sided;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Sided.Example
{
	public class TestClass
	{
		public string name { get; set; }
		public int age { get; set; }
		public Color color { get; set; }

		public TestClass() { }
		public TestClass(string s,  int age, Color color)
		{
			this.name = s;
			this.age = age;
			this.color = color;
		}
		public override string ToString()
		{
			return new StringBuilder()
				.Append(name)
				.Append(" ")
				.Append(age)
				.ToString();
		}
		public string SomeMethode()
		{
			return "SomeMethod";
		}
	}
	/// <summary>
	/// Example class
	/// 1) Create some class
	/// 2) Add a Generic Sided<T> property with right type
	/// 3) use paner and left/right method
	/// 4) use T type method (setted as TestClass here) 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ExampleUsage
	{
		public Sided<TestClass> Paner { get; set; }
		public ExampleUsage()
		{
			// create a new T typed variable (TestClass here)
			TestClass left = new TestClass("martin", 18, Color.AliceBlue);
			TestClass right = new TestClass("cojack", 72, Color.Blue);
			// instanciate Paner and add Created T variable
			this.Paner = new Sided<TestClass>(left, right);
			Console.WriteLine($"left paner value {this.Paner.Left.Side.ToString()}");
			Console.WriteLine($"right paner value {this.Paner.Right.Side.ToString()}");
			//use some methods :
			Console.WriteLine($"left paner method call :{this.Paner.Left.Side.SomeMethode()}");
			Console.WriteLine($"right paner method call :{this.Paner.Right.Side.SomeMethode()}");

			//modify values as this
			TestClass modified = new TestClass("scorcese", 4, Color.Bisque);
			this.Paner.Right.Side = modified;
			Console.WriteLine($"right paner modified value {this.Paner.Right.Side.ToString()}");

			//or as this
			TestClass another = new TestClass("luther king", 42, Color.Salmon);
			Left<TestClass> sidedValue = new Left<TestClass>();
			sidedValue.Side = another;
			this.Paner.SetSide(sidedValue);
			Console.WriteLine($"left paner modified value {this.Paner.Left.Side.ToString()}");
		}
	}
}
